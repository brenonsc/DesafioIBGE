using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioIBGE.Model;

public class Location
{
    [Key]
    [Column(TypeName = "varchar")]
    [StringLength(7)]
    public string id { get; set; }
    
    [Column(TypeName = "varchar")]
    [StringLength(2)]
    public string state { get; set; }  = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(80)]
    public string city { get; set; } = string.Empty;
}