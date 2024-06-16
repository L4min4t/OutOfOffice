using Backend.Models.Token;
using Backend.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class JwtController : ControllerBase
{
    private readonly IJwtService _service;
    
    public JwtController(IJwtService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenModel param)
    {
        var result = await _service.RefreshTokenAsync(param);
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.ErrorMessages);
    }
}