namespace HandyverwaltungWebApp3BHWII.Models;

public class Kunde
{
    public int KundeId { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Postleitzahl{ get; set; }
    public string Strasse { get; set; }
    public string Hausnummer { get; set; }
    public DateTime Geburtsdatum { get; set; }
    
}