using Npgsql;
using Sante.Models.bdd;
using ArgumentNullException = System.ArgumentNullException;

namespace Sante.Models.service;

public class Disease{

    public int id { get; set; }

    public string nom { get; set; }

    public void GetDiseaseById()
    {
        using (NpgsqlConnection connection = Connection.GetConnection())
        {
            connection.Open();
            string sql = "SELECT * FROM disease WHERE Id = @id";
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", this.id);
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.id = (int)reader["id"];
                        this.nom = (string)reader["nom"];
                    }
                }
            }

            connection.Close();
        }
    }
}