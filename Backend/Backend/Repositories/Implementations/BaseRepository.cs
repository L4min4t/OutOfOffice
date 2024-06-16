using System.Linq.Expressions;
using Backend.Contexts;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Implementations;

public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> DbSet;
    
    public BaseRepository(ApplicationContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }
    
    public virtual async Task<List<T>?> FindAllAsync()
    {
        return await DbSet.ToListAsync();
    }
    
    public virtual async Task<T?> FindByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }
    
    public virtual async Task<List<T>?> FindByConditionAsync
        (Expression<Func<T, bool>> expression)
    {
        return await DbSet.AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
    
    public virtual async Task CreateAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }
    
    public virtual async Task UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        Context.Entry(entity)
            .State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
    
    public virtual async Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }
}
