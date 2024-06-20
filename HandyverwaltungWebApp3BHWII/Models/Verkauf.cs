namespace HandyverwaltungWebApp3BHWII.Models;

public class Verkauf
{
    public int VerkaufId { get; set; }
    public double Verkaufspreis{ get; set; }
    public DateTime Verkauffdatum{ get; set; }
    public int Menge{ get; set; }
    public string Zahlungsmethode{ get; set; }
    public int kundeid { get; set; }

}