using System;
using API.Models;

namespace API.Data;

public interface IUserRepository
{
    void CreateUser(User user);

    List<User> Listar();
    
    User? searceUser(int Id);
}
