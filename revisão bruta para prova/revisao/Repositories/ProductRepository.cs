using System;
using revisao.Models;
using revisao.Data;
using Microsoft.AspNetCore.Mvc;

namespace revisao.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    //Essa construção injeta a instância do AppDbContext
    //no repositório para permitir o acesso ao banco de dados.
    public ProductRepository( AppDbContext context)
    {
        _context = context;
    }

    public List<Product> List()
    {
        return _context.Products.ToList();
    }

    public Product? SearchId(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }

}
