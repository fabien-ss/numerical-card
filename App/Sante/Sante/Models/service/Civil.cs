namespace Sante.Models.service;
using System.Data.SqlClient;

class Civil
{
    private string cin;
    string nom;
    string firstName;
    DateTime dateOfBirth;
    string birthPlace;
    string adresse;
    Civil father;
    Civil mother;
    DateTime deliveryDate;
    List<PersonDesease> deseases;
    
    public string getCin(){ return this.cin; }
    
    public void getCivilByCin(){
        string connectionString = "Data Source=<nom du serveur>;Initial Catalog=<nom de la base de données>;User ID=<nom d'utilisateur>;Password=<mot de passe>;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM Civil WHERE cin = @cin";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@cin", this.cin);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.nom = (string) reader["nom"];
                        this.firstName = (string) reader["first_name"];
                        this.dateOfBirth = (DateTime) reader["date_of_birth"];
                        this.birthPlace = (string) reader["place_of_birth"];
                        this.adresse = (string) reader["address_local"];
                        if(reader["father"] != null){
                            this.father.cin = (string) reader["father"];
                            this.father.getCivilByCin();
                        }
                        if(reader["mother"] != null){
                            this.mother.cin = (string) reader["mother"];
                            this.mother.getCivilByCin();
                        }
                        this.deliveryDate = (DateTime) reader["date_delivery"];
                        PersonDesease pd = new PersonDesease();
                        pd.setCivil(this);
                        this.deseases = pd.getAllDeseasePerCivil();
                    }
                }
            }
            connection.Close();
        }
    }
}