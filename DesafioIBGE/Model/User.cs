using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DesafioIBGE.Filters;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace DesafioIBGE.Model;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [SwaggerIgnore]
    public long id { get; set; }
    
    /// <summary>
    /// E-mail do usuário
    /// </summary>
    /// <example>example@email.com</example>
    [Column(TypeName = "varchar")]
    [StringLength(255)]
    public string usuario { get; set; } = string.Empty;
    
    /// <summary>
    /// Senha do usuário
    /// </summary>
    /// <example>Y0ur$tr0ngP@ssw0rd</example>
    [Column(TypeName = "varchar")]
    [StringLength(255)]
    public string senha { get; set; } = string.Empty;
}