using System;

namespace revisao.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    [HttpGet("list")]
    public IActionResult Listar()
    {}

    [HttpGet("list/{id}")]
    public IActionResult Listar()
    {}

    [HttpPost("create")]
    public IActionResult Listar()
    {}

    [HttpPut("update/{id}")]
    public IActionResult Listar()
    {}
    
    [HttpDelete("delete/{id}")]
    public IActionResult Listar()
    {}


}
