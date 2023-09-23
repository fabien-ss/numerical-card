namespace Sante.Models.service;
using Npgsql;
using Sante.Models.bdd;

public class Civil
{
    public string cin { get; set; }
    public string nom{ get; set; }
    public string firstName{ get; set; }
    public DateTime dateOfBirth{ get; set; }
    public string birthPlace{ get; set; }
    public string adresse{ get; set; }
    public Civil father { get; set; }
    public Civil mother{ get; set; }
    public DateTime deliveryDate{ get; set; }
    public List<PersonDesease> deseases{ get; set; }

    public string Cin
    {
        get{ return this.cin; }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("aeaerzer")
                ;
            this.cin = value;
        }
    } 
    
    public string Nom { get; set; }

    public string getNom()
    {
        return this.nom;
    }
    public List<PersonDesease> getDeseases()
    {
        return this.deseases;
    }
    public void setCin(string cin)
    {
        this.cin = cin ?? throw new ArgumentException("Cin invalide");
    }
    public string getCin(){ return this.cin; }
    
    public void GetCivilByCin()
    {
        using (NpgsqlConnection connection = Connection.GetConnection())
        {
            connection.Open();
            string sql = "SELECT * FROM Civil WHERE cin = @cin";
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@cin", this.cin); // Add parameters this way
                using (NpgsqlDataReader reader = command.ExecuteReader())
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
                        PersonDesease pd = new PersonDesease();
                        pd.civil = this;
                        this.deseases = pd.getAllDeseasePerCivil();
                        var data = pd;
                        // Console.WriteLine(this.nom);
                    }
                }
            }
            connection.Close();
        }
    }
}