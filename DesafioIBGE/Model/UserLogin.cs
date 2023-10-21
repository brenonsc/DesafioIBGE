namespace DesafioIBGE.Model;

public class UserLogin
{
    public long Id { get; set; }

    public string Usuario { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;
    
    public string Token { get; set; } = string.Empty;
}