using Backend.Lists.Employees;
using Microsoft.EntityFrameworkCore.Update;

namespace Backend.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
}