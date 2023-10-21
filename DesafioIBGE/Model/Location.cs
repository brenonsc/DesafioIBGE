using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioIBGE.Model;

public class Location
{
    [Key]
    [Column(TypeName = "varchar")]
    [StringLength(7)]
    public string Id { get; set; }
    
    [Column(TypeName = "varchar")]
    [StringLength(2)]
    public string State { get; set; }  = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(80)]
    public string City { get; set; } = string.Empty;
}