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

     public double CalculSuperficie(double langueur,double largeur)
        {
            return langueur * largeur;
        }

        public double CalculHTMateriaux(double langueur,double largeur)
        {
            return this.materieaux * this.CalculSuperficie(langueur,largeur);
        }

        public double CalculHTMainOeuvre(double langueur,double largeur)
        {
            return this.main_oeuvre * this.CalculSuperficie(langueur,largeur);
        }

        public double CalculTaxeMateriaux(double langueur,double largeur)
        {
            return this.CalculHTMateriaux(langueur,largeur) * 0.15;
        }

        public double CalculTaxeMainOeuvre(double langueur,double largeur)
        {
            return this.CalculHTMainOeuvre(langueur,largeur) * 0.15;
        }

        public double CalculTotalHT(double langueur,double largeur)
        {
            return this.CalculHTMateriaux(langueur,largeur) + this.CalculHTMainOeuvre(langueur,largeur);
        }

        public double CalculTotalTTC(double langueur,double largeur)
        {
            return this.CalculTotalHT(langueur,largeur) + this.CalculTaxeMainOeuvre(langueur,largeur) + this.CalculTaxeMateriaux(langueur,largeur);
        }
       
    }






