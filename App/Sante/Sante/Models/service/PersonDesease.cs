namespace Sante.Models.service;
using System.Data.SqlClient;
class PersonDesease{

    private Civil civil;
    private Disease disease;
    public DateTime startDate;
    public DateTime endDate;
    private Hopital hopital;
    
    public List<PersonDesease> getAllDeseasePerCivil(){
        this.civil.getCivilByCin();
        List<PersonDesease> diseases = new List<PersonDesease>();
        string connectionString = "Data Source=<nom du serveur>;Initial Catalog=<nom de la base de données>;User ID=<nom d'utilisateur>;Password=<mot de passe>;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * person_desease WHERE cin = @id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", this.civil.getCin());
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PersonDesease pd = new PersonDesease();
                        pd.civil = this.civil;
                        this.disease.setId((int) reader["id_desease"]);
                        this.disease.getDiseaseById();
                        this.hopital.setId((int) reader["idHopital"]);
                        this.hopital.getHopitalById();
                        this.startDate = (DateTime) reader["date_start"];
                        this.endDate = (DateTime) reader["date_end"];
                        diseases.Add(pd);
                    }
                }
            }
            connection.Close();
        }
        return diseases;
    }
    
    Hopital getHopital()
    {
        return this.hopital;
    }
    Disease getDesease()
    {
        return this.disease;
    }
    Civil getCivil()
    {
        return this.civil;
    }
    public void setHopital(Hopital hopital)
    {
        this.hopital = hopital ?? throw new ArgumentException("No hopital set");
    }
    public void setEnDate(DateTime dateTime)
    {
        this.endDate = dateTime;
    }
    public void setStartDate(DateTime dateTime)
    {
        this.startDate = dateTime;
    }
    public void setDisease(Disease disease)
    {
        this.disease = disease ?? throw new ArgumentException("No desease set");
    }
    public void setCivil(Civil civil)
    {
        this.civil = civil ?? throw new ArgumentException("Not civil set");
    }
}