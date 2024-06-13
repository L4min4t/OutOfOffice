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
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IJwtService tokenService,
        SignInManager<User> signInManager,
        UserManager<User> userManager, IEmployeeRepository employeeRepository)
    {
        _signInManager = signInManager;
        _jwtService = tokenService;
        _userManager = userManager;
        _employeeRepository = employeeRepository;
    }

    public async Task<Result<(IdentityResult, Employee)>> RegisterUserAsync(RegisterModel model)
    {
        string userId;
        try
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user is not null)
                return Result<(IdentityResult, Employee)>.Failure(HttpStatusCode.BadRequest,
                    $"User with {model.Email} already exists!");

            user = new User
            {
                FullName = model.Name,
                UserName = model.Email,
                Email = model.Email
            };
            userId = user.Id;

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                var applicationResult = await CreateEmployee(user);

                return applicationResult.IsSuccess
                    ? Result<(IdentityResult, Employee)>.Success((identityResult, applicationResult.Value))
                    : Result<(IdentityResult, Employee)>.Failure(applicationResult.StatusCode,
                        applicationResult.ErrorMessage);
            }
            else
            {
                return Result<(IdentityResult, Employee)>.Failure(HttpStatusCode.BadRequest,
                    $"Register failed: {identityResult.Errors.FirstOrDefault().Description}");
            }
        }
        catch (Exception ex)
        {
            return Result<(IdentityResult, Employee)>.Failure(HttpStatusCode.BadRequest,
                $"Register failed!"
            );
        }
    }

    public async Task<Result<TokenModel>> LoginUserAsync(LoginModel model)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(model.Email);


            if (user is null)
                return Result<TokenModel>.Failure(HttpStatusCode.BadRequest,
                    $"The user with {model.Email} doesn't exist!");

            var signInResult = await _signInManager.PasswordSignInAsync(
                user: user,
                password: model.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            return signInResult.Succeeded
                ? await _jwtService.GenerateTokenPairAsync(user)
                : Result<TokenModel>.Failure(HttpStatusCode.BadRequest, $"Invalid password!");
        }
        catch (Exception ex)
        {
            return Result<TokenModel>.Failure(HttpStatusCode.BadRequest, $"Login failed!");
        }
    }

    public async Task<Result<TokenModel>> ChangePasswordAsync(ChangePasswordModel model)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user is null)
                return Result<TokenModel>.Failure(HttpStatusCode.BadRequest,
                    $"The user with {model.Email} doesn't exist!");

            var passwordCheck =
                _userManager.PasswordHasher.VerifyHashedPassword(user!, user.PasswordHash!, model.OldPassword);

            if (passwordCheck is PasswordVerificationResult.Failed)
                return Result<TokenModel>.Failure(HttpStatusCode.BadRequest, $"The old password is not correct!");

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);

            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded) return await _jwtService.GenerateTokenPairAsync(user);
            else return Result<TokenModel>.Failure(HttpStatusCode.BadRequest, "Invalid change password attempt!");
        }
        catch (Exception ex)
        {
            return Result<TokenModel>.Failure(HttpStatusCode.BadRequest, $"Change password failed!");
        }
    }

    private async Task<Result<Employee>> CreateEmployee(User user)
    {
        try
        {
            var entity = (await _employeeRepository.FindByConditionAsync(e => e.IdentityId == user.Id))
                .FirstOrDefault();
            if (entity is null)
            {
                var employee = new Employee()
                {
                    FullName = user.UserName,
                    IdentityId = user.Id
                };

                await _employeeRepository.CreateAsync(employee);

                return Result<Employee>.Success(employee);
            }
            else
            {
                return Result<Employee>.Failure(HttpStatusCode.BadRequest, $"User already exists!");
            }
        }
        catch (Exception ex)
        {
            return Result<Employee>.Failure(HttpStatusCode.BadRequest, $"Service Server Fail!");
        }
    }
}