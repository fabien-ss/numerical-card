using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Sante.Models.bdd;

namespace Sante.Models.service;

[Table("disease")]
public class Disease{

    [Key]
    [Column("id")]
    public int id { get; set; }
    [Column("nom")]
    public string? nom { get; set; }

    public Disease GetDiseaseById()
    {
        var context = ApplicationDbContextFactory.Create();
        var d = context.diseases
            .First(c => c.id == this.id);
        return d;
    }
}