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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _employeeService.FindByIdAsync(id);
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
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEmployeeDto model)
    {
        var result = await _employeeService.UpdateAsync(model);
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.ErrorMessages);
    }
}
