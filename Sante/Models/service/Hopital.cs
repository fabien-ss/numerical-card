using System.ComponentModel.DataAnnotations.Schema;
using Sante.Models.bdd;

namespace Sante.Models.service;

[Table("hospital")]
public class Hopital{
    
    [Column("id")]
    public int id {get; set;}
    [Column("nom")]
    public string? nom {get; set;}

    public Hopital GetHopitalById()
    {
        var context = ApplicationDbContextFactory.Create();
        Hopital hopital = context.hopital.First(h => h.id == this.id);
        return hopital;
    }
}