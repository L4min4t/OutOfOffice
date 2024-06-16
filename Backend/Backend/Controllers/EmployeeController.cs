using Backend.Lists.Employees;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _employeeService.FindAllAsync();
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.ErrorMessages);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeDto model)
    {
        var result = await _employeeService.CreateAsync(model);
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.ErrorMessages);
    }
}