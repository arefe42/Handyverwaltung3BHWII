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

    public Kunde GetKunde(int kundeId)
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen
        
        using NpgsqlCommand cmd = new NpgsqlCommand("select * from kunde where kundeid = :v1;", myConnection);
        cmd.Parameters.AddWithValue("v1", kundeId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        Kunde newKunde = new Kunde();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            newKunde.KundeId = (int) reader["KundeId"];
            newKunde.Vorname = (string) reader["Vorname"];
            newKunde.Nachname= (string) reader["Nachname"];
            newKunde.Postleitzahl= (string) reader["Postleitzahl"];
            newKunde.Strasse = (string) reader["Strasse"];
            newKunde.Hausnummer = (string) reader["Hausnummer"];
            
            newKunde.Geburtsdatum = (DateTime) reader["Geburtsdatum"];
        }
        
        myConnection.Close();
        //mit return zurückgeben
        return newKunde;
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
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "INSERT INTO kunde (Vorname, Nachname, Postleitzahl, Strasse, Hausnummer, Geburtsdatum) VALUES (:v1,:v2,:v3,:v4,:v5,:v6)", myConnection);
        
        cmd.Parameters.AddWithValue("v1", kunde.Vorname);
        cmd.Parameters.AddWithValue("v2", kunde.Nachname);
        cmd.Parameters.AddWithValue("v3", kunde.Postleitzahl);
        cmd.Parameters.AddWithValue("v4", kunde.Strasse);
        cmd.Parameters.AddWithValue("v5", kunde.Hausnummer);
        cmd.Parameters.AddWithValue("v6", kunde.Geburtsdatum);
        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }

    public void DeleteKunde(int kundeId) //Methode delete
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "Delete From kunde where KundeId =:v1", myConnection);
        
        cmd.Parameters.AddWithValue("v1", kundeId);
      
        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
        
    }

    public void UpdateKunde(Kunde kunde) //Methode Update
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "UPDATE kunde SET vorname=:v1,nachname=:v2,postleitzahl=:v3,strasse=:v4,hausnummer=:v5,geburtsdatum=:v6 " +
            "WHERE kundeId=:v7", myConnection);
        
        cmd.Parameters.AddWithValue("v1", kunde.Vorname);
        cmd.Parameters.AddWithValue("v2", kunde.Nachname);
        cmd.Parameters.AddWithValue("v3", kunde.Postleitzahl);
        cmd.Parameters.AddWithValue("v4", kunde.Strasse);
        cmd.Parameters.AddWithValue("v5", kunde.Hausnummer);
        cmd.Parameters.AddWithValue("v6", kunde.Geburtsdatum);
        cmd.Parameters.AddWithValue("v7", kunde.KundeId);
        
        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
}