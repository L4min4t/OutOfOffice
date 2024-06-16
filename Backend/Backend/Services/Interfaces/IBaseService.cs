using Backend.ResultPattern;

namespace Backend.Services.Interfaces;

public interface IBaseService<T>
    where T : class
{
    Task<Result<List<T>?>> FindAllAsync();
    Task<Result<T?>> FindByIdAsync(int id);
    Task<Result<int>> DeleteAsync(int id);
}
