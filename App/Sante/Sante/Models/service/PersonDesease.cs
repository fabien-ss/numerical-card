using Npgsql;
using Sante.Models.bdd;

namespace Sante.Models.service;
using System.Data.SqlClient;

public class PersonDesease{

    public Civil civil { get; set; }
    public Disease disease { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public Hopital hopital { get; set; }
    
    public List<PersonDesease> getAllDeseasePerCivil(){
        List<PersonDesease> diseases = new List<PersonDesease>();
        using (NpgsqlConnection connection = Connection.GetConnection())
        {
            connection.Open();
            string sql = "SELECT * From person_desease WHERE cin = @id";
            using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", this.civil.getCin());
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PersonDesease pd = new PersonDesease();
                        this.disease = new Disease();
                        this.disease.id = (int) reader["id_desease"];
                        this.disease.GetDiseaseById();
                        this.hopital = new Hopital();
                        this.hopital.setId((int) reader["idHopital"]);
                        this.hopital.GetHopitalById();
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