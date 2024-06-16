using Backend.Lists.Employees;
using Backend.Models.Auth;
using Backend.Models.Token;
using Backend.ResultPattern;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.Interfaces;

public interface IAuthService
{
    Task<Result<(IdentityResult, Employee)>> RegisterUserAsync
        (RegisterModel model);
    
    Task<Result<TokenModel>> LoginUserAsync(LoginModel model);
    Task<Result<TokenModel>> ChangePasswordAsync(ChangePasswordModel model);
}
