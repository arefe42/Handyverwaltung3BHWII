using HandyverwaltungWebApp3BHWII.Models;
using Npgsql;

namespace HandyverwaltungWebApp3BHWII.Repositories;

public class ModellRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=Handyverwaltung;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
       
        connection.Open();
        return connection;
    }
    
    public Modell GetModell(int modellId)
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen
        
        using NpgsqlCommand cmd = new NpgsqlCommand("select * from modell where modellId = :v1;", myConnection);
        cmd.Parameters.AddWithValue("v1", modellId);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        Modell newModell = new Modell();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            newModell.ModellId = (int) reader["ModellId"];
            newModell.Mname = (string) reader["Mname"];
            newModell.Preis= (double) reader["Preis"];
            newModell.Veroeffentlichungsjahr = (DateTime) reader["Veroeffentlichungsjahr"];
            newModell.Farbe = (string) reader["Farbe"];

            if (reader["produzentid"] != System.DBNull.Value)
            {
                newModell.produzentid = (int)reader["produzentid"];
            }
            

        }
        
        myConnection.Close();
        //mit return zurückgeben
        return newModell;
    }
    
    public List<Modell> GetAllModell() //Methode read
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM public.modell;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Modell> modell = new List<Modell>();
        while (reader.Read())
        {
            //Datensätze in Objekte umwandeln
            Modell newModell = new Modell();
            newModell.ModellId = (int) reader["ModellId"];
            newModell.Mname = (string) reader["Mname"];
            newModell.Preis= (double) reader["Preis"];
            newModell.Veroeffentlichungsjahr = (DateTime) reader["Veroeffentlichungsjahr"];
            newModell.Farbe = (string) reader["Farbe"];
            
            if (reader["produzentid"] != System.DBNull.Value)
            {
                newModell.produzentid = (int)reader["produzentid"];
            }
            

            
            modell.Add(newModell);
            
        }
        //mit return zurückgeben
        
        myConnection.Close();
        return modell;
    }
    
    public void CreateModell(Modell modell) //Methode create
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "INSERT INTO modell (Mname, Preis, Veroeffentlichungsjahr,Farbe,produzentid) VALUES (:v1,:v2,:v3,:v4,:v5)", myConnection);
        
        cmd.Parameters.AddWithValue("v1", modell.Mname);
        cmd.Parameters.AddWithValue("v2", modell.Preis);
        cmd.Parameters.AddWithValue("v3", modell.Veroeffentlichungsjahr);
        cmd.Parameters.AddWithValue("v4", modell.Farbe);
        cmd.Parameters.AddWithValue("v5", modell.produzentid);


        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
    public void UpdateModell(Modell modell) //Methode Update
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "UPDATE modell SET mname=:v1,preis=:v2,veroeffentlichungsjahr=:v3,farbe=:v4,produzentid=:v5," +
            "WHERE ModellId=:v6", myConnection);
        
        cmd.Parameters.AddWithValue("v1", modell.Mname);
        cmd.Parameters.AddWithValue("v2", modell.Preis);
        cmd.Parameters.AddWithValue("v3", modell.Veroeffentlichungsjahr);
        cmd.Parameters.AddWithValue("v4", modell.Farbe);
        cmd.Parameters.AddWithValue("v4", modell.produzentid);
        cmd.Parameters.AddWithValue("v6", modell.ModellId);

       
        
        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }
    
    public void DeleteModell(int modellId) //Methode delete
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "Delete From modell where ModellId =:v1", myConnection);
        
        cmd.Parameters.AddWithValue("v1", modellId);
      
        

        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
        
    }


}