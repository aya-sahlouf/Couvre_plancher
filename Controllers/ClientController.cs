using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using couvre_plancher.Models;

namespace couvre_plancher.Controllers;

public class ClientController : Controller
{
    private readonly ILogger <ClientController> _logger;

    public ClientController(ILogger <ClientController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
