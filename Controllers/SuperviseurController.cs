using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using couvre_plancher.Models;
using couvre_plancher.Data;
using Microsoft.EntityFrameworkCore;

namespace couvre_plancher.Controllers;

public class SuperviseurController : Controller
{
    private readonly ILogger<SuperviseurController> _logger;
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
    public IActionResult Gestion()
    {
        int rowCountPack = _db.Pack.Count();
        int rowCountCouvre = _db.Couvreplancher.Count();
        int rowCountClient = _db.Client.Count();
        int rowCountCommande = _db.Commande.Count();

        ViewBag.RowCountPack = rowCountPack;
        ViewBag.RowCountCouvre = rowCountCouvre;
        ViewBag.RowCountClient = rowCountClient;
        ViewBag.rowCountCommande = rowCountCommande;
        var packs = _db.Pack.Include(s => s.id_couvre).ToList();
        IEnumerable<PackModel> pack = _db.Pack;
        var couvreplanchers = _db.Couvreplancher.ToList();
        var clients = _db.Client.ToList();
        var commande = _db.Commande.ToList();
        var promotion = _db.Promotion.Include(s => s.id_couvre).ToList();
        IEnumerable<PromotionModel> promotions = _db.Promotion;
        var model = (pack, couvreplanchers, clients, commande, promotions);

        return View(model);
    }

    public IActionResult Gestion_promotion()
    {

        var promotion = _db.Promotion.Include(s => s.id_couvre).ToList();

        return View(promotion);
    }
    public IActionResult Gestion_pack()
    {

        var packs = _db.Pack.Include(s => s.id_couvre).ToList();
        IEnumerable<PackModel> pack = _db.Pack;
        return View(pack);
    }
    public IActionResult Commande()
    {

        var couvre = _db.Commande.Include(s => s.id_couvre).ToList();
        var client = _db.Commande.Include(s => s.id_client).ToList();

        return View();
    }
    public IActionResult Delete_Pack(int? id)
    {
        var obj = _db.Pack.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Pack.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Gestion");

    }
    public IActionResult Delete_Commande(int? id)
    {
        var obj = _db.Commande.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Commande.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Gestion");

    }
    public IActionResult Edit_Pack(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var obj = _db.Pack.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        return View(obj);
    }

    [HttpPost]
    public IActionResult Edit_Pack(PackModel pack)
    {
        if (ModelState.IsValid)
        {
            _db.Pack.Update(pack);
            _db.SaveChanges();
            TempData["success"] = "Pack updated successfully";
            return RedirectToAction("Gestion");
        }

        return View(pack);
    }
    public IActionResult Gestion_couvre()
    {

        return View(_db.Couvreplancher.ToList());
    }
    public IActionResult Client()
    {

        return View(_db.Client.ToList());
    }
    public IActionResult Delete_Couvre(int? id)
    {
        var obj = _db.Couvreplancher.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Couvreplancher.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Gestion");

    }
    public IActionResult Add_pack()
    {
        var couvres = _db.Couvreplancher.ToList();


        ViewBag.Couvre = couvres;

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add_pack(PackModel obj)
    {

        _db.Pack.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Gestion");

    }
    [HttpPost]
    public IActionResult Add_couvre(CouvreplancherModel model, IFormFile formFile)
    {
        // Validate form data
        String fileName = Path.GetFileName(formFile.FileName);

        string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

        var filestream = new FileStream(uploadfilepath, FileMode.Create);

        formFile.CopyToAsync(filestream);

        string uploadedDBpath = "images\\" + fileName;
        model.image_couvre = uploadedDBpath;
        // Add model to list of couvreplancher models
        _db.Couvreplancher.Add(model);
        _db.SaveChanges();
        // Redirect to parent view
        return RedirectToAction("Gestion");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(string Email, string Password)
    {
        if (ModelState.IsValid)
        {
            var data = _db.Superviseur.Where(s => s.Email.Equals(Email) && s.Password.Equals(Password)).ToList();
            if (data.Count() > 0)
            {
                HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                HttpContext.Session.SetInt32("id", data.FirstOrDefault().Id_sup);

                return RedirectToAction("Gestion");
            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Index");
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
