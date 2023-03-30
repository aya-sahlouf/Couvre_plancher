using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using couvre_plancher.Models;
using couvre_plancher.Data;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

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
    {  HttpContext.Session.SetInt32("ademmander",0);
   
     var couvre = _db.Couvreplancher.ToList();
  var promotion = _db.Promotion.Include(i=>i.id_couvre).ToList();
    ViewBag.couvre=couvre;
   
        return View(promotion);
    }
    
 

[HttpGet]
 public IActionResult Commande (int lar, int Long ,int idcouvre,int? id)
    {  HttpContext.Session.SetInt32("lar",lar);
     HttpContext.Session.SetInt32("long",Long);
     HttpContext.Session.SetInt32("idcouvre",idcouvre);
   
         var couvre = _db.Couvreplancher.ToList();

    // ViewBag.couvre=couvre;
    if (idcouvre!=0){

        HttpContext.Session.SetInt32("ademmander",1);
       var data = _db.Couvreplancher.Where(s => s.Id_couvre == idcouvre).ToList();



 ViewBag.data=data;}

        return View(couvre);
    }

   
[HttpPost]
   public IActionResult Client_info(ClientModel obj)
   { Console.WriteLine(obj.Cin);
    _db.Client.Add(obj);
    _db.SaveChanges();
    return RedirectToAction("Index");
   }

 
    
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
