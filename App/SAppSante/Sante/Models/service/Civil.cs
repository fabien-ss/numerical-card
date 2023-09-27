using System.Data;

namespace Sante.Models.service;

using Npgsql;

public class Civil
{

    public string cin { get; set; }
    public string nom { get; set; }
    public string firstName { get; set; }
    public DateTime dateOfBirth { get; set; }
    public string birthPlace { get; set; }
    public string adresse { get; set; }
    public Civil father { get; set; }
    public Civil mother { get; set; }
    public DateTime deliveryDate { get; set; }
    public List<PersonDesease> deseases { get; set; }
    
    public void GetCivilByCin()
    {
        var connection = Connection.GetConnection();
        connection.Open();
        const string sql = "SELECT * FROM Civil WHERE cin = @cin";
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@cin", this.cin); // Add parameters this way
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read()) // si il y a un résultat
                {
                    this.nom = (string) reader["nom"];
                    this.firstName = (string) reader["first_name"];
                    this.dateOfBirth = (DateTime) reader["date_of_birth"];
                    this.birthPlace = (string) reader["place_of_birth"];
                    this.adresse = (string) reader["address_local"];
                    if (!reader.IsDBNull(reader.GetOrdinal("father"))) // Check for null values
                    { // si le cin du père est présent
                        this.father = new Civil { cin = (string) reader["father"] };
                        this.father.GetCivilByCin();
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("mother"))) // Check for null values
                    { // si le cin de la mère est présent
                        this.mother = new Civil { cin = (string)reader["mother"] };
                        this.mother.GetCivilByCin();
                    }
                    this.deliveryDate = (DateTime) reader["date_delivery"];
                    var pd = new PersonDesease { civil = this };
                    this.deseases = pd.GetAllDeseasePerCivil();
                }
                else // not person for that cin
                {
                    throw new DataException("No cin match.");
                }
            }
        }
        connection.Close();
    }
}