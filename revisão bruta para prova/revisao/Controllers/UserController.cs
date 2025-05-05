using Microsoft.AspNetCore.Mvc;
using revisao.Models;
using revisao.Repositories;

namespace revisao.Controllers;

[ApiController]
[Route("api/User")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("signup")]
    public IActionResult Signup([FromBody] User user)
    {
        _repository.SignUp(user);
        _repository.Save();
        return CreatedAtAction(nameof(ListById), new { id = user.Id }, user);
    }

    [HttpGet("login")]
    public IActionResult Login([FromQuery] string email, [FromQuery] string password)
    {
        var user = _repository.Login(email, password);
        if (user == null)
            return Unauthorized("Credenciais inválidas.");

        return Ok(user);
    }

    [HttpGet("list")]
    public IActionResult ListAll()
    {
        var users = _repository.List();
        return Ok(users);
    }

    [HttpGet("list/{id}")]
    public IActionResult ListById(int id)
    {
        var user = _repository.SearchId(id);
        if (user == null)
            return NotFound("Usuário não encontrado.");
        return Ok(user);
    }

    [HttpPut("update/{id}")]
    public IActionResult Update(int id, [FromBody] User updatedUser)
    {
        var existing = _repository.SearchId(id);
        if (existing == null)
            return NotFound("Usuário não encontrado.");

        existing.Email = updatedUser.Email;
        existing.Password = updatedUser.Password;

        _repository.Update(existing);
        _repository.Save();

        return Ok(existing);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var user = _repository.SearchId(id);
        if (user == null)
            return NotFound("Usuário não encontrado.");

        _repository.Delete(user);
        _repository.Save();

        return NoContent();
    }
}
