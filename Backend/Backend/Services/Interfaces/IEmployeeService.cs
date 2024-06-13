using System.Linq.Expressions;
using Backend.Lists.Employees;

namespace Backend.Services.Interfaces;

public interface IEmployeeService : IBaseService<Employee>
{
    Task<List<Employee>?> FindByConditionAsync(Expression<Func<Employee, bool>> expression);
}