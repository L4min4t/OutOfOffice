using Backend.Lists.Employees;
using Backend.ResultPattern;

namespace Backend.Services.Interfaces;

public interface IEmployeeService : IBaseService<Employee>
{
    Task<Result<EmployeeDto>> CreateAsync(CreateEmployeeDto dto);
    Task<Result<EmployeeDto>> UpdateAsync(UpdateEmployeeDto dto);
    
    Task<Result<EmployeeDto?>> FindByIdAsync(int id);
}
