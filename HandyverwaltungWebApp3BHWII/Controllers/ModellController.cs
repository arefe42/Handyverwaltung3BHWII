using HandyverwaltungWebApp3BHWII.Models;
using HandyverwaltungWebApp3BHWII.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HandyverwaltungWebApp3BHWII.Controllers;

public class ModellController : Controller
{
    public IActionResult Index()
    {
        ModellRepository repo = new ModellRepository();
        List<Modell> myModelle = repo.GetAllModell();
        
        return View(myModelle);
    }
    
    public IActionResult New()
    {
        ProduzentRepository potRepo = new ProduzentRepository();
        List <Produzent> alleProduzenten = potRepo.GetAllProduzenten();

        ViewData["alleProduzenten"] = alleProduzenten;
        return View();
    }
    
    public IActionResult Edit(int ModellId)
    {
        //repo holen
        ModellRepository repo = new ModellRepository();
        //kunde mit KundenId aus DB holen
        Modell meinModell = repo.GetModell(ModellId);
        //kunde der View übergeben
        return View(meinModell);
    }
    
    [HttpPost]
    public IActionResult SaveModell(Modell modell)
    {
        //Repository holen
        ModellRepository repo = new ModellRepository();
        
        //Kunde speichern
        repo.CreateModell(modell);
        
        //zurück zu Übersicht
        return Redirect(url: "/Modell");
    }
    
    [HttpPost]
    public IActionResult UpdateModell(Modell modell)
    {
        //Repository holen
        ModellRepository repo = new ModellRepository();
        
        //Kunde speichern
        repo.UpdateModell(modell);
        
        //zurück zu Übersicht
        return Redirect(url: "/Modell");
    }
    
    public IActionResult Delete(int ModellId)
    {
        //repo holen
        ModellRepository repo = new ModellRepository();
        //kunde mit KundenId aus DB holen
        Modell meinModell = repo.GetModell(ModellId);
        //kunde der View übergeben
        return View(meinModell);
    }
    
    [HttpPost]
    public IActionResult DeleteModell(Modell modell)
    {
        //Repository holen
        ModellRepository repo = new ModellRepository();
        
        //Kunde speichern
        repo.DeleteModell(modell.ModellId);
        
        //zurück zu Übersicht
        return Redirect(url: "/Modell");
    }
    
    
    

}