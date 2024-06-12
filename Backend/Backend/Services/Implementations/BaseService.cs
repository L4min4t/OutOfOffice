using System.Linq.Expressions;
using Backend.Lists;
using Backend.Repositories.Interfaces;
using Backend.ResultPattern;
using Backend.Servises.Interfaces;

namespace Backend.Servises.Implementations;

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
            if (!entities.Any())
            {
                return Result<List<B>?>.Failure(HttpStatusCode.NoContent, "There is no data!");
            }

            return Result<List<B>?>.Success(entities);
        }
        catch (Exception ex)
        {
            return Result<List<B>?>.Failure(HttpStatusCode.InternalServerError, ex.Message);
        }
    }


    public async Task<Result<B?>> FindByIdAsync(int id)
    {
        try
        {
            var entity = await Repository.FindByIdAsync(id);
            if (entity is null)
            {
                return Result<B?>.Failure(HttpStatusCode.NoContent, "There is no data!");
            }

            return Result<B?>.Success(entity);
        }
        catch (Exception ex)
        {
            return Result<B?>.Failure(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Result<int>> DeleteAsync(int id)
    {
        try
        {
            var entity = await Repository.FindByIdAsync(id);
            if (entity is null)
            {
                return Result<int>.Failure(HttpStatusCode.NoContent, "There is no data!");
            }

            await Repository.DeleteAsync(entity);

            return Result<int>.Success(entity.Id);
        }
        catch (Exception ex)
        {
            return Result<int>.Failure(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}