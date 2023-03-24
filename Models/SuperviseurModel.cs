using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace couvre_plancher.Models;

public class SuperviseurModel
{
    [Key]
    public int Id_sup { get; set; }
    
   [Required]
    [EmailAddress]
    public string Email { get; set; }
 [Required]
    [DataType(DataType.Password)]

    public string Password { get; set; }

}