using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DesafioIBGE.Model;
using DesafioIBGE.Service;
using Microsoft.IdentityModel.Tokens;

namespace DesafioIBGE.Security.Implements;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;

    public AuthService(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<UserLogin?> Autenticar(UserLogin userLogin)
    {
        if(userLogin is null || string.IsNullOrEmpty(userLogin.Usuario) || string.IsNullOrEmpty(userLogin.Senha))
            return null;
        
        var buscaUsuario = await _userService.GetByUsuario(userLogin.Usuario);
        
        if(buscaUsuario is null)
            return null;
        
        if(!BCrypt.Net.BCrypt.Verify(userLogin.Senha, buscaUsuario.Senha))
            return null;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(Settings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userLogin.Usuario)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        userLogin.Id = buscaUsuario.Id;
        userLogin.Usuario = buscaUsuario.Usuario;
        userLogin.Token = "Bearer " + tokenHandler.WriteToken(token).ToString();
        userLogin.Senha = "";
        
        return userLogin;
    }
}