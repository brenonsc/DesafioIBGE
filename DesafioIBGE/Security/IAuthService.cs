using DesafioIBGE.Model;

namespace DesafioIBGE.Security;

public interface IAuthService
{
    Task<UserLogin?> Autenticar(UserLogin userLogin);
}