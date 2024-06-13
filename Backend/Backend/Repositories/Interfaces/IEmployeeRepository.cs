using System.Linq.Expressions;
using Backend.Lists.Employees;
using Microsoft.EntityFrameworkCore.Update;

namespace Backend.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<List<Employee>?> FindByConditionAsync(Expression<Func<Employee, bool>> expression);
    Task CreateAsync(Employee entity);
}