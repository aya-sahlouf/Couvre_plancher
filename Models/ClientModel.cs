using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace couvre_plancher.Models;

public class ClientModel
{
    [Key]
    public int Cin { get; set; }
    
    [Required]

    public string nom { get; set; }

    [Required]

    public string  adresse { get; set; }
    [Required]

    public string  num { get; set; }
   

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}