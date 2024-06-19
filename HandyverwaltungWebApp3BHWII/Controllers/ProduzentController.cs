using HandyverwaltungWebApp3BHWII.Models;
using HandyverwaltungWebApp3BHWII.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HandyverwaltungWebApp3BHWII.Controllers;

public class ProduzentController : Controller
{
    public IActionResult Index()
    {
        ProduzentRepository repo = new ProduzentRepository();
        List<Produzent> myProduzenten = repo.GetAllProduzenten();
        
        return View(myProduzenten);
    }
    
    public IActionResult New()
    {
        return View();
    }
    
    public IActionResult Edit(int ProduzentId)
    {
        //repo holen
        ProduzentRepository repo = new ProduzentRepository();
        //kunde mit KundenId aus DB holen
        Produzent meinProduzent = repo.GetProduzent(ProduzentId);
        //kunde der View übergeben
        return View(meinProduzent);
    }
    
    [HttpPost]
    public IActionResult SaveProduzent(Produzent produzent)
    {
        //Repository holen
        ProduzentRepository repo = new ProduzentRepository();
        
        //Kunde speichern
        repo.CreateProduzent(produzent);
        
        //zurück zu Übersicht
        return Redirect(url: "/Produzent");
    }
    
    [HttpPost]
    public IActionResult UpdateProduzent(Produzent produzent)
    {
        //Repository holen
        ProduzentRepository repo = new ProduzentRepository();
        
        //Kunde speichern
        repo.UpdateProduzent(produzent);
        
        //zurück zu Übersicht
        return Redirect(url: "/Produzent");
    }
    
    public IActionResult Delete(int ProduzentId)
    {
        //repo holen
        ProduzentRepository repo = new ProduzentRepository();
        //kunde mit KundenId aus DB holen
        Produzent meinProduzent = repo.GetProduzent(ProduzentId);
        //kunde der View übergeben
        return View(meinProduzent);
    }
    
    [HttpPost]
    public IActionResult DeleteProduzent(Produzent produzent)
    {
        //Repository holen
        ProduzentRepository repo = new ProduzentRepository();
        
        //Kunde speichern
        repo.DeleteProduzent(produzent.ProduzentId);
        
        //zurück zu Übersicht
        return Redirect(url: "/Produzent");
    }
    
    
    

}