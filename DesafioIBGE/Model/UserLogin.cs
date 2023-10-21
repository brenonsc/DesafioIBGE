namespace DesafioIBGE.Model;

public class UserLogin
{
    public long id { get; set; }

    public string usuario { get; set; } = string.Empty;

    public string senha { get; set; } = string.Empty;
    
    public string token { get; set; } = string.Empty;
}