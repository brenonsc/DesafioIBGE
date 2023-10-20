using DesafioIBGE.Model;

namespace DesafioIBGE.Service;

public interface IUserService
{
    Task<User?> GetByUsuario(string usuario);
    
    Task<User?> Create(User usuario);
}