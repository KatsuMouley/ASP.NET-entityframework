using Microsoft.AspNetCore.Mvc;
using revisao.Models;
using revisao.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace revisao.Controllers;

[ApiController]
[Route("api/User")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;

    public UserController(IUserRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    [HttpPost("signup")]
    public IActionResult Signup([FromBody] User user)
    {
        _repository.SignUp(user);
        _repository.Save();
        return CreatedAtAction(nameof(ListById), new { id = user.Id }, user);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        var foundUser = _repository.Login(user.Email, user.Password);
        if (foundUser == null)
            return Unauthorized("Credenciais inválidas.");

        var token = GenerateToken(foundUser);
        return Ok(new { token });
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

    [ApiExplorerSettings(IgnoreApi = true)]//Esta linha é utilizada quando queremos que nosso código ignore um endpoint
    private string GenerateToken(User user)
      {
          var claims = new[]
          {
              new Claim(ClaimTypes.Name, user.Email),
              new Claim(ClaimTypes.Role, user.Role.ToString())
          };

          var chave = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!);
          var credenciais = new SigningCredentials(
              new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256);

          var token = new JwtSecurityToken(
              claims: claims,
              expires: DateTime.UtcNow.AddSeconds(30),
              signingCredentials: credenciais);

          return new JwtSecurityTokenHandler().WriteToken(token);
      }
}
