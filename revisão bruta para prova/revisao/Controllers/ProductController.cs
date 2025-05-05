using Microsoft.AspNetCore.Mvc;
using revisao.Models;
using revisao.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace revisao.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("list")]
    public IActionResult ListAll()
    {
        var produtos = _repository.List();
        return Ok(produtos);
    }

    [HttpGet("list/{id}")]
    public IActionResult ListById(int id)
    {
        var produto = _repository.SearchId(id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }
        return Ok(produto);
    }
    
    [Authorize(Roles = "admin")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Product product)
    {
        _repository.Create(product);
        _repository.Save();
        return CreatedAtAction(nameof(ListById), new { id = product.Id }, product);
    }
    
    [Authorize]
    [HttpPut("update/{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        var existente = _repository.SearchId(id);
        if (existente == null)
        {
            return NotFound("Produto não encontrado.");
        }

        existente.Name = product.Name;

        _repository.Update(existente);
        _repository.Save();

        return Ok(existente);
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _repository.SearchId(id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        _repository.Delete(produto);
        _repository.Save();

        return NoContent();
    }
}
