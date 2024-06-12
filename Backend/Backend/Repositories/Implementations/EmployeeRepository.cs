using System.Linq.Expressions;
using Backend.Contexts;
using Backend.Lists.Employees;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Implementations;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context) : base(context)
    {
    }
    
    public virtual async Task<List<Employee>?> FindByConditionAsync(Expression<Func<Employee, bool>> expression) =>
        await DbSet.AsNoTracking().Where(expression).ToListAsync();
}