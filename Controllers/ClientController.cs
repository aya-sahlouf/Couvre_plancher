using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using couvre_plancher.Models;
using couvre_plancher.Data;

namespace couvre_plancher.Controllers;

public class ClientController : Controller
{
 private readonly ILogger<ClientController> _logger;
    private readonly AplicationDbContext _db;

    public ClientController(ILogger<ClientController> logger, AplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    { IEnumerable<CouvreplancherModel> couvre = _db.Couvreplancher;
        return View(couvre);
    }

//    [HttpGet]
//  public IActionResult Index(int lar, int Long ,int idcouvre)
//     {
//         // double CalculSuperficie = lar*Long;
//         // double CalculHTMateriaux =  12.9 * CalculSuperficie;
//         // double CalculHTMainOeuvre= 20 * CalculSuperficie;
//         // double CalculTaxeMateriaux= CalculHTMateriaux* 0.15;
//         //  double CalculTaxeMainOeuvre= CalculHTMainOeuvre* 0.15;  
//         //  double CalculTotalHT =CalculHTMateriaux+CalculHTMainOeuvre;
//         //   double CalculTotalTTC = CalculTotalHT + CalculTaxeMainOeuvre +CalculTaxeMateriaux;
       

//         return View(facture);
//     }

   

   

 
    
    public IActionResult Validation()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
