using HandyverwaltungWebApp3BHWII.Models;
using HandyverwaltungWebApp3BHWII.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HandyverwaltungWebApp3BHWII.Controllers;

public class KundeController : Controller
{
    // GET
    public IActionResult Index()
    {
        KundeRepository repo = new KundeRepository();
        List<Kunde> myKunde = repo.GetAllKunden();
        
        return View(myKunde);
    }

    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaveKunde(Kunde kunde)
    {
        //Repository holen
        KundeRepository repo = new KundeRepository();
        
        //Kunde speichern
        repo.CreateKunde(kunde);
        
        //zurück zu Übersicht
        return Redirect(url: "/Kunde");
    }
}