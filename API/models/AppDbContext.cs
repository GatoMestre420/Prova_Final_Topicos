using Microsoft.EntityFrameworkCore;

namespace API.models;
public class AppDbContext : DbContext
{
    public DbSet<Usuario> usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=nomeDoSeuBanco.db");
    }
}

