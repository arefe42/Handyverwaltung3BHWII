using HandyverwaltungWebApp3BHWII.Models;
using HandyverwaltungWebApp3BHWII.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HandyverwaltungWebApp3BHWII.Controllers;

public class VerkaufController : Controller
{
    public IActionResult Index()
    {
        VerkaufRepository repo = new VerkaufRepository();
        List<Verkauf> myVerkauf = repo.GetAllVerkaufen();
        
        return View(myVerkauf);
    }
    
    public IActionResult New()
    {
        KundeRepository kunRepo = new KundeRepository();
        List <Kunde> alleKunden = kunRepo.GetAllKunden();

        ViewData["alleKunden"] = alleKunden;
        return View();
    }
    
    public IActionResult Edit(int VerkaufId)
    {
        //repo holen
        VerkaufRepository repo = new VerkaufRepository();
        //kunde mit KundenId aus DB holen
        Verkauf meinVerkauf = repo.GetVerkauf(VerkaufId);
        //kunde der View übergeben
        return View(meinVerkauf);
    }
    
    [HttpPost]
    public IActionResult SaveVerkauf(Verkauf verkauf)
    {
        //Repository holen
        VerkaufRepository repo = new VerkaufRepository();
        
        //Kunde speichern
        repo.CreateVerkauf(verkauf);
        
        //zurück zu Übersicht
        return Redirect(url: "/Verkauf");
    }
    
    [HttpPost]
    public IActionResult UpdateVerkauf(Verkauf verkauf)
    {
        //Repository holen
        VerkaufRepository repo = new VerkaufRepository();
        
        //Kunde speichern
        repo.UpdateVerkauf(verkauf);
        
        //zurück zu Übersicht
        return Redirect(url: "/Verkauf");
    }
    
    public IActionResult Delete(int VerkaufId)
    {
        //repo holen
        VerkaufRepository repo = new VerkaufRepository();
        //kunde mit KundenId aus DB holen
        Verkauf meinVerkauf = repo.GetVerkauf(VerkaufId);
        //kunde der View übergeben
        return View(meinVerkauf);
    }
    
    [HttpPost]
    public IActionResult DeleteVerkauf(Verkauf verkauf)
    {
        //Repository holen
        VerkaufRepository repo = new VerkaufRepository();
        
        //Kunde speichern
        repo.DeleteVerkauf(verkauf.VerkaufId);
        
        //zurück zu Übersicht
        return Redirect(url: "/Verkauf");
    }
    
    
    

}