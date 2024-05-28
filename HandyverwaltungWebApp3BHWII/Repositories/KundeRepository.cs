using HandyverwaltungWebApp3BHWII.Models;
using Npgsql;

namespace HandyverwaltungWebApp3BHWII.Repositories;

public class KundeRepository
{
    private NpgsqlConnection ConnectToDB()
    {
       string connectionString = "Host=localhost;Database=Handyverwaltung;User Id=dbuser;Password=dbuser;";
       NpgsqlConnection connection = new NpgsqlConnection(connectionString);
       
       connection.Open();
       return connection;
    }
    
    public List<Kunde> GetAllKunden() //Methode read
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen
        
        using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.kunde;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Kunde> kunde = new List<Kunde>();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            Kunde newKunde = new Kunde();
            newKunde.KundeId = (int) reader["KundeId"];
            newKunde.Vorname = (string) reader["Vorname"];
            newKunde.Nachname= (string) reader["Nachname"];
            newKunde.Postleitzahl= (string) reader["Postleitzahl"];
            newKunde.Strasse = (string) reader["Strasse"];
            newKunde.Hausnummer = (string) reader["Hausnummer"];
            
            newKunde.Geburtsdatum = (DateTime) reader["Geburtsdatum"];
            
            kunde.Add(newKunde);
        }
        //mit return zurückgeben
        
        myConnection.Close();
        return kunde;
    }

    public void CreateKunde(Kunde kunde) //Methode create
    {
        
    }

    public void DeleteKunde(int kundeId) //Methode delete
    {
        
    }

    public void UpdateKunde(Kunde kunde) //Methode Update
    {
        
    }
    
}