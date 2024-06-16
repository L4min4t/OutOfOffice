using Backend.Lists;
using Backend.Models.Token;
using Backend.ResultPattern;

namespace Backend.Services.Implementations;

public interface IJwtService
{
    Task<Result<TokenModel>> GenerateTokenPairAsync(User user);
    Task<Result<TokenModel>> RefreshTokenAsync(RefreshTokenModel tokenModel);
}
