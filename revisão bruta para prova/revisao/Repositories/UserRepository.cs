using System;
using revisao.Models;
using revisao.Data;
using Microsoft.AspNetCore.Mvc;

namespace revisao.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    //Essa construção injeta a instância do AppDbContext
    //no repositório para permitir o acesso ao banco de dados.
    public UserRepository( AppDbContext context)
    {
        _context = context;
    }

    public void SignUp(User user)
    {
        _context.Users.Add(user);
    }
    public User? Login(string email, string password)
    {
        return _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
    }
    public List<User> List()
    {
        return _context.Users.ToList();
    }

    public User? SearchId(int id)
    {
        return _context.Users.FirstOrDefault(p => p.Id == id);
    }
    
    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}
