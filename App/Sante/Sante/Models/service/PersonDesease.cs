using Npgsql;
using Sante.Models.bdd;

namespace Sante.Models.service;
using System.Data.SqlClient;

public class PersonDesease{
    public PersonDesease()
    {
        
    }
    public PersonDesease(Civil civil, Disease disease, DateTime startDate, DateTime endDate, Hopital hopital)
    {
        this.civil = civil;
        this.disease = disease;
        this.startDate = startDate;
        this.endDate = endDate;
        this.hopital = hopital;
    }

    public Civil civil { get; set; }
    public Disease disease { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public Hopital hopital { get; set; }

    public List<PersonDesease> getAllDeseasePerCivil()
    {
        var diseases = new List<PersonDesease>();
        using var connection = Connection.GetConnection();
        connection.Open();
        const string sql = "SELECT * From person_desease WHERE cin = @id";
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@id", this.civil.cin);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var pd = new PersonDesease();
                    this.disease = new Disease
                    {
                        id = (int)reader["id_desease"]
                    };
                    this.disease.GetDiseaseById();
                    this.hopital = new Hopital
                    {
                        id = (int)reader["idHopital"]
                    };
                    this.hopital.GetHopitalById();
                    this.startDate = (DateTime)reader["date_start"];
                    this.endDate = (DateTime)reader["date_end"];
                    diseases.Add(pd);
                }
            }
        }
        connection.Close();

        return diseases;
    }
}