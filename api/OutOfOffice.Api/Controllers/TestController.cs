using Microsoft.AspNetCore.Mvc;

namespace OutOfOffice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("test");
    }
}
