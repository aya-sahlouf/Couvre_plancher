using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using couvre_plancher.Models;
using couvre_plancher.Data;

namespace couvre_plancher.Controllers;

public class SuperviseurController : Controller
{
    private readonly ILogger <SuperviseurController> _logger;
     private readonly AplicationDbContext _db;

     public SuperviseurController(ILogger<SuperviseurController> logger, AplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public ActionResult login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult login(string Email, string Password)
    {
        if (ModelState.IsValid)
        {            var data = _db.Superviseur.Where(s => s.Email.Equals(Email) && s.Password.Equals(Password)).ToList();
            if (data.Count() > 0)
            {
                HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                HttpContext.Session.SetInt32("id", data.FirstOrDefault().Id_sup);
               
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("login");
            }
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
