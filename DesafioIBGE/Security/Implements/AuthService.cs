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
        if(userLogin is null || string.IsNullOrEmpty(userLogin.usuario) || string.IsNullOrEmpty(userLogin.senha))
            return null;
        
        var buscaUsuario = await _userService.GetByUsuario(userLogin.usuario);
        
        if(buscaUsuario is null)
            return null;
        
        if(!BCrypt.Net.BCrypt.Verify(userLogin.senha, buscaUsuario.senha))
            return null;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(Settings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userLogin.usuario)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        userLogin.id = buscaUsuario.id;
        userLogin.usuario = buscaUsuario.usuario;
        userLogin.token = tokenHandler.WriteToken(token).ToString();
        userLogin.senha = "";
        
        return userLogin;
    }
}