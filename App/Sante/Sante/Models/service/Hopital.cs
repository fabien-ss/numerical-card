namespace Sante.Models.service;
using System.Data.SqlClient;

class Hopital{

    int id {get; set;}
    string nom {get; set;}

    public void getHopitalById(){
        string connectionString = "Data Source=<nom du serveur>;Initial Catalog=<nom de la base de données>;User ID=<nom d'utilisateur>;Password=<mot de passe>;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM Hopital WHERE Id = @id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", this.id);
                using (SqlDataReader reader = command.ExecuteReader())
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