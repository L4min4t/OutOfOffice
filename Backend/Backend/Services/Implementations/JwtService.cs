using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.Lists;
using Backend.Models.Jwt;
using Backend.Models.Token;
using Backend.ResultPattern;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.Implementations;

public class JwtService : IJwtService
{
    private readonly JwtOptions _jwtOptions;
    private readonly JwtBearerOptions _jwtBearerOptions;
    private readonly UserManager<User> _userManager;
    private readonly IEmployeeService _employeeService;

    public JwtService(IOptions<JwtOptions> jwtSettings, UserManager<User> userManager,
        IOptions<JwtBearerOptions> jwtBearerOptions, IEmployeeService employeeService)
    {
        _jwtOptions = jwtSettings.Value;
        _userManager = userManager;
        _employeeService = employeeService;
        _jwtBearerOptions = jwtBearerOptions.Value;
    }

    public async Task<Result<TokenModel>> GenerateTokenPairAsync(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = await GenerateUserClaims(user);

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(Constants.Constants.AccessTokenLifetimeInMinutes),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience
        };

        var securityToken = tokenHandler.CreateToken(descriptor);

        var accessToken = tokenHandler.WriteToken(securityToken);

        var refreshToken = GenerateRefreshToken();

        user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(Constants.Constants.RefreshTokenLifetimeInMinutes);
        user.RefreshToken = refreshToken;
        await _userManager.UpdateAsync(user);

        return Result<TokenModel>.Success(new TokenModel()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }

    public async Task<Result<TokenModel>> RefreshTokenAsync(RefreshTokenModel tokenModel)
    {
        var principal = GetPrincipalFromExpiredToken(tokenModel.AccessToken);
        
        if (principal?.FindFirstValue(ClaimTypes.Email) is null)
        {
            return Result<TokenModel>.Failure(HttpStatusCode.BadRequest, "The provided token is not valid!");
        }
        
        var user = await _userManager.FindByNameAsync(principal.FindFirstValue(ClaimTypes.Email)!);
        
        if (user is null)
        {
            return Result<TokenModel>.Failure(HttpStatusCode.BadRequest,
                $"The user with email {principal.FindFirstValue(ClaimTypes.Email)!} was not found!");
        }
        
        if (user.RefreshToken != tokenModel.RefreshToken)
            return Result<TokenModel>.Failure(HttpStatusCode.BadRequest, "The provided refresh token is not valid.");
        
        if (user.RefreshTokenExpiryTime <= DateTime.Now)
            return Result<TokenModel>.Failure(HttpStatusCode.BadRequest, "The provided refresh token is expired.");

        return await GenerateTokenPairAsync(user);
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    private async Task<List<Claim>> GenerateUserClaims(User user)
    {
        var employee = (await _employeeService.FindByConditionAsync(
            e => e.IdentityId == user.Id)).FirstOrDefault();
        
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new("id", employee.Id.ToString())
        };
        
        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        return claims;
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(token,
            _jwtBearerOptions.TokenValidationParameters,
            out var securityToken);

        return CheckSecurityToken(securityToken) ? principal : null;
    }

    private static bool CheckSecurityToken(SecurityToken securityToken) =>
        securityToken is JwtSecurityToken jwtSecurityToken &&
        jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
}