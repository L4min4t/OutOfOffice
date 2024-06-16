using Backend.Lists;
using Backend.Lists.Employees;
using Backend.Models.Auth;
using Backend.Models.Token;
using Backend.Repositories.Interfaces;
using Backend.ResultPattern;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IJwtService _jwtService;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    
    public AuthService(
        IJwtService tokenService, SignInManager<User> signInManager, UserManager<User> userManager,
        IEmployeeRepository employeeRepository
    )
    {
        _signInManager = signInManager;
        _jwtService = tokenService;
        _userManager = userManager;
        _employeeRepository = employeeRepository;
    }
    
    public async Task<Result<(IdentityResult, Employee)>> RegisterUserAsync(RegisterModel model)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            
            if (user is not null)
                return Result<(IdentityResult, Employee)>.Fail($"User with {model.Email} already exists!");
            
            user = new User { FullName = model.Name, UserName = model.Email, Email = model.Email };
            
            var identityResult = await _userManager.CreateAsync(user, model.Password);
            
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                
                var applicationResult = await CreateEmployee(user);
                
                return applicationResult.IsSuccess
                    ? Result.Success((identityResult, applicationResult.Value))
                    : Result<(IdentityResult, Employee)>.Fail(applicationResult.ErrorMessages);
            }
            
            return Result<(IdentityResult, Employee)>.Fail($"Register failed: {identityResult.Errors}");
        }
        catch (Exception)
        {
            return Result<(IdentityResult, Employee)>.Fail("Register failed!");
        }
    }
    
    public async Task<Result<TokenModel>> LoginUserAsync(LoginModel model)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            
            if (user is null)
                return Result<TokenModel>.Fail($"The user with {model.Email} doesn't exist!");
            
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            
            return signInResult.Succeeded
                ? await _jwtService.GenerateTokenPairAsync(user)
                : Result<TokenModel>.Fail("Invalid password!");
        }
        catch (Exception)
        {
            return Result<TokenModel>.Fail("Login failed!");
        }
    }
    
    public async Task<Result<TokenModel>> ChangePasswordAsync(ChangePasswordModel model)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            
            if (user is null)
                return Result<TokenModel>.Fail($"The user with {model.Email} doesn't exist!");
            
            var passwordCheck = _userManager.PasswordHasher.VerifyHashedPassword(
                user, user.PasswordHash!, model.OldPassword
            );
            
            if (passwordCheck is PasswordVerificationResult.Failed)
                return Result<TokenModel>.Fail("The old password is not correct!");
            
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            
            var updateResult = await _userManager.UpdateAsync(user);
            
            if (updateResult.Succeeded) return await _jwtService.GenerateTokenPairAsync(user);
            
            return Result<TokenModel>.Fail("Invalid change password attempt!");
        }
        catch (Exception)
        {
            return Result<TokenModel>.Fail("Change password failed!");
        }
    }
    
    private async Task<Result<Employee>> CreateEmployee(User user)
    {
        try
        {
            var entity =
                (await _employeeRepository.FindByConditionAsync(e => e.IdentityId == user.Id))?.FirstOrDefault();
            if (entity is null)
            {
                var employee = new Employee { FullName = user.UserName ?? "name to setted", IdentityId = user.Id };
                
                await _employeeRepository.CreateAsync(employee);
                
                return Result<Employee>.Success(employee);
            }
            
            return Result<Employee>.Fail("User already exists!");
        }
        catch (Exception)
        {
            return Result<Employee>.Fail("Creating employee failed!");
        }
    }
}