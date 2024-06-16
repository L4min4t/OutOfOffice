using Backend.Lists.Projects;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _projectService.FindAllAsync();
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.ErrorMessages);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _projectService.FindByIdAsync(id);
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.ErrorMessages);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectDto model)
    {
        var result = await _projectService.CreateAsync(model);
        return result.IsSuccess
            ? Ok()
            : BadRequest(result.ErrorMessages);
    }
}
