using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioIBGE.Model;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long id { get; set; }
    
    [Column(TypeName = "varchar")]
    [StringLength(255)]
    public string usuario { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    [StringLength(255)]
    public string senha { get; set; } = string.Empty;
}