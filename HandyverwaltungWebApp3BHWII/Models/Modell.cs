namespace HandyverwaltungWebApp3BHWII.Models;

public class Modell
{
    public int ModellId { get; set; }
    public string Mname{ get; set; }
    public double Preis{ get; set; }
    public DateTime Veroeffentlichungsjahr{ get; set; }
    public string Farbe{ get; set; }
    
    public int produzentid { get; set; }

    

}