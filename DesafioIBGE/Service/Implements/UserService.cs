using DesafioIBGE.Data;
using DesafioIBGE.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioIBGE.Service.Implements;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    
    public UserService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetById(long id)
    {
        try
        {
            var usuario = await _context.Users
                .FirstAsync(i => i.Id == id);
            
            usuario.Senha = "";
            
            return usuario;
        }
        catch
        {
            return null;
        }
    }
    
    public async Task<User?> GetByUsuario(string usuario)
    {
        try
        {
            var buscaUsuario = await _context.Users
                .Where(u => u.Usuario == usuario).FirstOrDefaultAsync();

            return buscaUsuario;
        }
        catch
        {
            return null;
        }
    }

    public async Task<User?> Create(User usuario)
    {
        var buscaUsuario = await GetByUsuario(usuario.Usuario);
        
        if(buscaUsuario is not null)
            return null;

        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha, workFactor: 10);
        
        await _context.Users.AddAsync(usuario);
        await _context.SaveChangesAsync();
        
        return usuario;
    }
}