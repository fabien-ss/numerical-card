using System.Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sante.Models.service;

using Npgsql;

[Table("civil")]
public class Civil
{
    [Key]
    [Column("cin")]
    public string cin { get; set; }
    [Column("nom")]
    public string nom { get; set; }
    [Column("first_name")]
    public string firstName { get; set; }
    [Column("date_of_birth")]
    public DateTime dateOfBirth { get; set; }
    [Column("place_of_birth")]
    public string birthPlace { get; set; }
    [Column("address_local")]
    public string adresse { get; set; }
    [NotMapped]
    public Civil father { get; set; }
    [NotMapped]
    public Civil mother { get; set; }
    [Column("date_delivery")]
    public DateTime deliveryDate { get; set; }
    [NotMapped]
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