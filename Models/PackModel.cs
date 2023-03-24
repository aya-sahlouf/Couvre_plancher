using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace couvre_plancher.Models;

public class PackModel
{
    [Key]
    public int Id_pack { get; set; }
    
    [Required]

    public float superficie{ get; set; }

    [Required]

    public int reduction { get; set; }
    [ForeignKey("Id_couvre")]
    public CouvreplancherModel? id_couvre { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}