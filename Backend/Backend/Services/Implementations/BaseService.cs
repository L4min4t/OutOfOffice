using Backend.Lists;
using Backend.Repositories.Interfaces;
using Backend.ResultPattern;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class BaseService<B> : IBaseService<B>
    where B : class, IEntity
{
    protected readonly IBaseRepository<B> Repository;
    
    public BaseService(IBaseRepository<B> repository)
    {
        Repository = repository;
    }
    
    public virtual async Task<Result<List<B>?>> FindAllAsync()
    {
        try
        {
            var entities = await Repository.FindAllAsync();
            return entities.Any()
                ? Result.Success(entities)
                : Result.Success(new List<B>());
        }
        catch (Exception ex)
        {
            return Result<List<B>?>.Fail(ex.Message);
        }
    }
    
    public async Task<Result<B?>> FindByIdAsync(int id)
    {
        try
        {
            var entity = await Repository.FindByIdAsync(id);
            return entity is null
                ? Result<B?>.Success(null)
                : Result<B?>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<B?>.Fail(ex.Message);
        }
    }
    
    public async Task<Result<int>> DeleteAsync(int id)
    {
        try
        {
            var entity = await Repository.FindByIdAsync(id);
            
            if (entity is null)
                return Result<int>.Fail("No data to delete found!");
            
            await Repository.DeleteAsync(entity);
            
            return Result<int>.Success(id);
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }
}
