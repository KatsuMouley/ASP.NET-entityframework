using System;

namespace API.Models;

public class User
{
    public int Id { get; set; }
    public int Idade { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; } = DateTime.Now;

}
