using HandyverwaltungWebApp3BHWII.Models;
using Npgsql;

namespace HandyverwaltungWebApp3BHWII.Repositories;

public class VerkaufRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=Handyverwaltung;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
       
        connection.Open();
        return connection;
    }
    
    public Verkauf GetVerkauf(int verkaufId)
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen
        
        using NpgsqlCommand cmd = new NpgsqlCommand("select * from verkauf where verkaufid = :v1;", myConnection);
        cmd.Parameters.AddWithValue("v1", verkaufId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        Verkauf newVerkauf = new Verkauf();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            newVerkauf.VerkaufId = (int) reader["VerkaufId"];
            newVerkauf.Verkaufspreis = (double) reader["Verkaufspreis"];
            newVerkauf.Verkauffdatum = (DateTime) reader["Verkauffdatum"];
            newVerkauf.Menge = (int) reader["Menge"];
            newVerkauf.Zahlungsmethode = (string) reader["Zahlungsmethode"];
            
            
            if (reader["kundeid"] != System.DBNull.Value)
            {
                newVerkauf.kundeid = (int)reader["kundeid"];
            }

            
            
        }
        
        myConnection.Close();
        //mit return zurückgeben
        return newVerkauf;
    }
    
    public List<Verkauf> GetAllVerkaufen() //Methode read
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.verkauf;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Verkauf> verkauf = new List<Verkauf>();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            Verkauf newVerkauf = new Verkauf();
            newVerkauf.VerkaufId = (int) reader["VerkaufId"];
            newVerkauf.Verkaufspreis = (double) reader["Verkaufspreis"];
            newVerkauf.Verkauffdatum = (DateTime) reader["Verkauffdatum"];
            newVerkauf.Menge = (int) reader["Menge"];
            newVerkauf.Zahlungsmethode = (string) reader["Zahlungsmethode"];
            
            if (reader["kundeid"] != System.DBNull.Value)
            {
                newVerkauf.kundeid = (int)reader["kundeid"];
            }

            
            verkauf.Add(newVerkauf);
            
        }
        //mit return zurückgeben
        
        myConnection.Close();
        return verkauf;
    }
    
    public void CreateVerkauf(Verkauf verkauf) //Methode create
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "INSERT INTO verkauf (Verkaufspreis, Verkauffdatum, Menge,Zahlungsmethode,kundeid) VALUES (:v1,:v2,:v3,:v4,:v5)", myConnection);
        
        cmd.Parameters.AddWithValue("v1", verkauf.Verkaufspreis);
        cmd.Parameters.AddWithValue("v2", verkauf.Verkauffdatum);
        cmd.Parameters.AddWithValue("v3", verkauf.Menge);
        cmd.Parameters.AddWithValue("v4", verkauf.Zahlungsmethode);
        cmd.Parameters.AddWithValue("v5", verkauf.kundeid);


        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
    public void UpdateVerkauf(Verkauf verkauf) //Methode Update
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "UPDATE verkauf SET verkaufspreis=:v1,verkauffdatum=:v2,menge=:v3,zahlungsmethode=:v4,kundeid=:v5 " +
            "WHERE VerkaufId=:v6", myConnection);
        
        cmd.Parameters.AddWithValue("v1", verkauf.Verkaufspreis);
        cmd.Parameters.AddWithValue("v2", verkauf.Verkauffdatum);
        cmd.Parameters.AddWithValue("v3", verkauf.Menge);
        cmd.Parameters.AddWithValue("v4", verkauf.Zahlungsmethode);
        cmd.Parameters.AddWithValue("v5", verkauf.kundeid);
        cmd.Parameters.AddWithValue("v6", verkauf.VerkaufId);

       
        
        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
    public void DeleteVerkauf(int verkaufId) //Methode delete
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "Delete From verkauf where VerkaufId =:v1", myConnection);
        
        cmd.Parameters.AddWithValue("v1", verkaufId);
      
        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
        
    }


}