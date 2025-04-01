
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDataContext : DbContext
{

     public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }
    public DbSet<User> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure outras propriedades do modelo, se necessário
        }
}
