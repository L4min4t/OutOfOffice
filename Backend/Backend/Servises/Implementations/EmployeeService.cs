using Backend.Lists.Employees;
using Backend.Repositories.Interfaces;
using Backend.Servises.Interfaces;

namespace Backend.Servises.Implementations;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    public EmployeeService(IBaseRepository<Employee> repository) : base(repository)
    {
    }
}