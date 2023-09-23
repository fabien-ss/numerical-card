namespace Sante.Models.service;
using Npgsql;
using Sante.Models.bdd;

public class Civil
{
    public Civil(){}
    public Civil(string cin, string nom, string firstName, DateTime dateOfBirth, string birthPlace, string adresse, Civil father, Civil mother, DateTime deliveryDate, List<PersonDesease> deseases)
    {
        this.cin = cin;
        this.nom = nom;
        this.firstName = firstName;
        this.dateOfBirth = dateOfBirth;
        this.birthPlace = birthPlace;
        this.adresse = adresse;
        this.father = father;
        this.mother = mother;
        this.deliveryDate = deliveryDate;
        this.deseases = deseases;
    }

    public string cin { get; set; }
    public string nom{ get; set; }
    public string firstName{ get; set; }
    public DateTime dateOfBirth{ get; set; }
    public string birthPlace{ get; set; }
    public string adresse{ get; set; }
    public Civil father { get; set; }
    public Civil mother { get; set; }
    public DateTime deliveryDate { get; set; }
    public List<PersonDesease> deseases { get; set; }
    
    public void GetCivilByCin()
    {
        using (NpgsqlConnection connection = Connection.GetConnection())
        {
            connection.Open();
            const string sql = "SELECT * FROM Civil WHERE cin = @cin";
            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@cin", this.cin); // Add parameters this way
                using (var reader = command.ExecuteReader())
                {
                  
                    if (reader.Read())
                    {
                        this.nom = (string)reader["nom"];
                        this.firstName = (string)reader["first_name"];
                        this.dateOfBirth = (DateTime)reader["date_of_birth"];
                        this.birthPlace = (string)reader["place_of_birth"];
                        this.adresse = (string)reader["address_local"];
                        if (!reader.IsDBNull(reader.GetOrdinal("father"))) // Check for null values
                        {
                            this.father.cin = (string)reader["father"];
                            this.father.GetCivilByCin();
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("mother"))) // Check for null values
                        {
                            this.mother.cin = (string)reader["mother"];
                            this.mother.GetCivilByCin();
                        }
                        this.deliveryDate = (DateTime)reader["date_delivery"];
                        var pd = new PersonDesease
                        {
                            civil = this
                        };
                        this.deseases = pd.getAllDeseasePerCivil();
                    }
                }
            }
            connection.Close();
        }
    }
}