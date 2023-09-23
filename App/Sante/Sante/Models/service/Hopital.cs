using Npgsql;
using Sante.Models.bdd;

namespace Sante.Models.service;
using System.Data.SqlClient;

public class Hopital{

    public int id {get; set;}
    public string nom {get; set;}

    public void GetHopitalById(){
        using (NpgsqlConnection connection = Connection.GetConnection())
        {
            connection.Open();
            string sql = "SELECT * FROM Hospital WHERE Id = @id";
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", this.id);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.id = (int) reader["id"];
                        this.nom = (string) reader["nom"];
                    }
                }
            }
            connection.Close();
        }
    }
    public void setId(int id)
    {
        this.id = id;
    }

    public int getId()
    {
        return this.id;
    }

    public void setNom(string nom)
    {
        this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
    }

    public string getNom()
    {
        return this.nom;
    }
}