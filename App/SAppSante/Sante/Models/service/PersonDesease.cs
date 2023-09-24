using Npgsql;
using Sante.Models.bdd;

namespace Sante.Models.service;
public class PersonDesease{
    
    public Civil civil { get; set; }
    public Disease disease { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public Hopital hopital { get; set; }

    public List<PersonDesease> GetAllDeseasePerCivil()
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
                    pd.disease = new Disease { id = (int)reader["id_desease"] };
                    pd.disease.GetDiseaseById();
                    pd.hopital = new Hopital { id = (int)reader["idHopital"] };
                    pd.hopital.GetHopitalById();
                    pd.startDate = (DateTime)reader["date_start"];
                    pd.endDate = (DateTime)reader["date_end"];
                    diseases.Add(pd);
                }
            }
        }
        connection.Close();
        return diseases;
    }
}