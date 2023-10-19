using Microsoft.EntityFrameworkCore;

namespace DesafioIBGE.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}