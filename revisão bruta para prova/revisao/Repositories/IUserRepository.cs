using System;
using revisao.Models;

namespace revisao.Repositories;

public interface IUserRepository
{
    void SignUp(User user);
    User? Login(string email, string password);
    List<User> List();
    User? SearchId(int id);
    void Update(User user);
    void Delete(User user);
    void Save();
}
