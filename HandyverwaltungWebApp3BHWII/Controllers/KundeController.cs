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
    
    public IActionResult Edit(int KundeId)
    {
        //repo holen
        KundeRepository repo = new KundeRepository();
        //kunde mit KundenId aus DB holen
        Kunde meinKunde = repo.GetKunde(KundeId);
        //kunde der View übergeben
        return View(meinKunde);
    }
    
    public IActionResult Delete(int KundeId)
    {
        //repo holen
        KundeRepository repo = new KundeRepository();
        //kunde mit KundenId aus DB holen
        Kunde meinKunde = repo.GetKunde(KundeId);
        //kunde der View übergeben
        return View(meinKunde);
    }
    
    public IActionResult DeleteKunde(Kunde kunde)
    {
        //Repository holen
        KundeRepository repo = new KundeRepository();
        
        //Kunde speichern
        repo.DeleteKunde(kunde.KundeId);
        
        //zurück zu Übersicht
        return Redirect(url: "/Kunde");
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
    
    public IActionResult UpdateKunde(Kunde kunde)
    {
        //Repository holen
        KundeRepository repo = new KundeRepository();
        
        //Kunde speichern
        repo.UpdateKunde(kunde);
        
        //zurück zu Übersicht
        return Redirect(url: "/Kunde");
    }
}