using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace couvre_plancher.Models;

public class CommandeModel
{
    [Key]
    public int Id_cmd { get; set; }
    
    [Required]

    public DateTime date_cmd{ get; set; }

  
    [ForeignKey("Cin")]
    public ClientModel? id_client { get; set; }
[ForeignKey("Id_couvre")]
    public CouvreplancherModel? id_couvre { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}