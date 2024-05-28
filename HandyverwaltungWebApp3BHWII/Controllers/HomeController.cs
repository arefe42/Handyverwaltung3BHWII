using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HandyverwaltungWebApp3BHWII.Models;
using HandyverwaltungWebApp3BHWII.Repositories;

namespace HandyverwaltungWebApp3BHWII.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        KundeRepository repo = new KundeRepository();
        List<Kunde> myKunde = repo.GetAllKunden();
        
        return View(myKunde);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}