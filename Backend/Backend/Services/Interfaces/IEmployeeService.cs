using Backend.Lists.Employees;
using Backend.ResultPattern;

namespace Backend.Services.Interfaces;

public interface IEmployeeService : IBaseService<Employee>
{
    Task<Result<Employee>> CreateAsync(CreateEmployeeDto dto);
}