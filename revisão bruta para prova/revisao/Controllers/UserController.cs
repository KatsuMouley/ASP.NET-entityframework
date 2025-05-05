using System;

namespace revisao.Controllers;

[ApiController]
[Route("api/User")]
public class UserController : ControllerBase
{
    [HttpPost("signup")]
    public IActionResult Listar()
    {}
    
    [HttpGet("login")]
    public IActionResult Listar()
    {}

    [HttpGet("list")]
    public IActionResult Listar()
    {}

    [HttpGet("list/{id}")]
    public IActionResult Listar()
    {}

    [HttpPut("update/{id}")]
    public IActionResult Listar()
    {}
    
    [HttpDelete("delete/{id}")]
    public IActionResult Listar()
    {}

}
