using System.ComponentModel.DataAnnotations.Schema;
using Sante.Models.bdd;

namespace Sante.Models.service;

[Table(("person_desease"))]
public class PersonDesease{
    [NotMapped]
    public Civil civil { get; set; }
    
    [Column("cin")]
    public String cin { get; set; }
    [NotMapped]
    public Disease disease { get; set; }
    [Column("date_start")]
    public DateTime startDate { get; set; }
    [Column("date_end")]
    public DateTime endDate { get; set; }
    [NotMapped]
    public Hopital hopital { get; set; }
    [Column("id_desease")]
    public int idDesease { get; set; }
    [Column("idhopital")]
    public int idhopital { get; set; }
    
    public List<PersonDesease> GetAllDeseasePerCivil()
    {
        var context = ApplicationDbContextFactory.Create();
        var pD = context.personDeseases
            .Where(p => p.cin == this.cin).ToList();
        foreach (var p in pD)
        {
            p.hopital = new Hopital
            {
                id = p.idhopital
            }.GetHopitalById();
            p.disease = new Disease
            {
                id = p.idDesease
            }.GetDiseaseById();
        }
        return pD;
    }
}