using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public ProdutoController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // [HttpGet]
    // public IActionResult helloworld1(){
    //     return Ok("Katsu Mouley has been here");
    // }

    // [HttpGet("hello")]
    // public IActionResult helloworld2(){
    //     return Ok("Hello world");
    // }

    [HttpPost("new_user")]
    public IActionResult CreateUser([FromBody] User user)
    {
        _userRepository.CreateUser(user);
        return Created("", user);
    }

    
    [HttpGet("list_users")]
    public IActionResult ListUsers()
    {
        return Ok(_userRepository.Listar());
    }

    
    // [HttpPut("update_user/{Id}")]
    // public IActionResult UpdateUser([FromBody] User user, FromRouteAttribute Id)
    // {
    //     return Ok();
    // }
    
    // [HttpDelete("delete_user/{Id}")]
    // public IActionResult DeleteUser(FromRouteAttribute Id)
    // {
    //     return Ok();
    // }
}