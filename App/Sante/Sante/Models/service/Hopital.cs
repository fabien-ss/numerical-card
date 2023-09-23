using Npgsql;
using Sante.Models.bdd;

namespace Sante.Models.service;
using System.Data.SqlClient;

public class Hopital{

    public int id {get; set;}
    public string nom {get; set;}

    public void GetHopitalById()
    {
        using var connection = Connection.GetConnection();
        connection.Open();
        const string sql = "SELECT * FROM Hospital WHERE Id = @id";
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@id", this.id);
            using (var reader = command.ExecuteReader())
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