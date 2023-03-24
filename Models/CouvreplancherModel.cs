using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace couvre_plancher.Models;
public class CouvreplancherModel
{
    [Key]
    public int Id_couvre { get; set; }
    [Required]
    [DataType(DataType.ImageUrl)]
    public string image_couvre { get; set; }
    [Required]
    [MaxLength(35)]
    public string Nom { get; set; }
    [Required]

    public Double main_oeuvre { get; set; }

    [Required]

    public Double materieaux { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}