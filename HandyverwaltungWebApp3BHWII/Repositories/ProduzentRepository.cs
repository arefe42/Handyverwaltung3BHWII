using HandyverwaltungWebApp3BHWII.Models;
using Npgsql;

namespace HandyverwaltungWebApp3BHWII.Repositories;

public class ProduzentRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=Handyverwaltung;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
       
        connection.Open();
        return connection;
    }
    
    public Produzent GetProduzent(int produzentId)
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen
        
        using NpgsqlCommand cmd = new NpgsqlCommand("select * from produzent where produzentid = :v1;", myConnection);
        cmd.Parameters.AddWithValue("v1", produzentId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        Produzent newProduzent = new Produzent();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            newProduzent.ProduzentId = (int) reader["ProduzentId"];
            newProduzent.Pname = (string) reader["Pname"];
            newProduzent.Hauptsitz= (string) reader["Hauptsitz"];
            newProduzent.Gruendungsjahr = (DateTime) reader["Gruendungsjahr"];
            
            
            
        }
        
        myConnection.Close();
        //mit return zurückgeben
        return newProduzent;
    }
    
    public List<Produzent> GetAllProduzenten() //Methode read
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.produzent;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Produzent> produzent = new List<Produzent>();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            Produzent newProduzent = new Produzent();
            newProduzent.ProduzentId = (int) reader["ProduzentId"];
            newProduzent.Pname = (string) reader["Pname"];
            newProduzent.Hauptsitz= (string) reader["Hauptsitz"];
            newProduzent.Gruendungsjahr = (DateTime) reader["Gruendungsjahr"];
            
            produzent.Add(newProduzent);
            
        }
        //mit return zurückgeben
        
        myConnection.Close();
        return produzent;
    }
    
    public void CreateProduzent(Produzent produzent) //Methode create
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "INSERT INTO produzent (Pname, Hauptsitz, Gruendungsjahr) VALUES (:v1,:v2,:v3)", myConnection);
        
        cmd.Parameters.AddWithValue("v1", produzent.Pname);
        cmd.Parameters.AddWithValue("v2", produzent.Hauptsitz);
        cmd.Parameters.AddWithValue("v3", produzent.Gruendungsjahr);
        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
    public void UpdateProduzent(Produzent produzent) //Methode Update
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "UPDATE produzent SET pname=:v1,hauptsitz=:v2,gruendungsjahr=:v3 " +
            "WHERE ProduzentId=:v4", myConnection);
        
        cmd.Parameters.AddWithValue("v1", produzent.Pname);
        cmd.Parameters.AddWithValue("v2", produzent.Hauptsitz);
        cmd.Parameters.AddWithValue("v3", produzent.Gruendungsjahr);
        cmd.Parameters.AddWithValue("v4", produzent.ProduzentId);
       
        
        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
    public void DeleteProduzent(int produzentId) //Methode delete
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "Delete From produzent where ProduzentId =:v1", myConnection);
        
        cmd.Parameters.AddWithValue("v1", produzentId);
      
        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
        
    }


}