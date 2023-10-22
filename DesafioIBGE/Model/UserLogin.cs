using DesafioIBGE.Filters;

namespace DesafioIBGE.Model;

public class UserLogin
{
    [SwaggerIgnore]
    public long id { get; set; }
    
    /// <summary>
    /// E-mail do usuário
    /// </summary>
    /// <example>example@email.com</example>
    public string usuario { get; set; } = string.Empty;

    /// <summary>
    /// Senha do usuário
    /// </summary>
    /// <example>Y0ur$tr0ngP@ssw0rd</example>
    public string senha { get; set; } = string.Empty;
    
    [SwaggerIgnore]
    public string token { get; set; } = string.Empty;
}