namespace Backend.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<List<T>?> FindAllAsync();
    Task<T?> FindByIdAsync(int id);
    Task DeleteAsync(T entity);
}