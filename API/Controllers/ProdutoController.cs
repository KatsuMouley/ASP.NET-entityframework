using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly AppDataContext _context;
    public ProdutoController(AppDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult helloworld1(){
        return Ok("Katsu Mouley has been here");
    }

    //
    [HttpGet("hello")]
    public IActionResult helloworld2(){
        return Ok("Hello world");
    }

    [HttpPost("new_user")]
    public IActionResult CreateUser([FromBody] User user)
    {
        _context.users.Add(user);
        _context.SaveChanges();
        return Created("", user);
    }
}