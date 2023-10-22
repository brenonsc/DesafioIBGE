using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioIBGE.Model;

public class Location
{
    /// <summary>
    /// Código de 7 dígitos do IBGE
    /// </summary>
    /// <example>1234567</example>
    [Key]
    [Column(TypeName = "varchar")]
    [StringLength(7)]
    public string id { get; set; }
    
    /// <summary>
    /// Sigla do estado
    /// </summary>
    /// <example>SP</example>
    [Column(TypeName = "varchar")]
    [StringLength(2)]
    public string state { get; set; }  = string.Empty;
    
    /// <summary>
    /// Nome da cidade
    /// </summary>
    /// <example>Cidade exemplo</example>
    [Column(TypeName = "varchar")]
    [StringLength(80)]
    public string city { get; set; } = string.Empty;
}