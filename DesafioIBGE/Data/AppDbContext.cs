using DesafioIBGE.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioIBGE.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Location>().ToTable("ibge");
    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
}