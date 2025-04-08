using System;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDataContext _context;
    public UserRepository(AppDataContext context)
    {
        _context = context;
    }
    
    public void CreateUser(User user)
    {
        _context.users.Add(user);
        _context.SaveChanges();
    }

    public List<User> Listar()
    {
        return _context.users.ToList();
    }

    public User? searceUser(int id)
    {
        return _context.users.FirstOrDefault(p => p.Id == id);
    }
}
