using System.Linq.Expressions;
using Backend.Lists.Employees;

namespace Backend.Servises.Interfaces;

public interface IEmployeeService : IBaseService<Employee>
{
    Task<List<Employee>?> FindByConditionAsync(Expression<Func<Employee, bool>> expression);
}