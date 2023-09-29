using System.Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sante.Models.bdd;

namespace Sante.Models.service;

[Table("civil")]
public class Civil
{
    [Key]
    [Column("cin")]
    public string cin { get; set; }
    [Column("nom")]
    public string nom { get; set; }
    [Column("first_name")]
    public string firstName { get; set; }
    [Column("date_of_birth")]
    public DateTime dateOfBirth { get; set; }
    [Column("place_of_birth")]
    public string birthPlace { get; set; }
    [Column("address_local")]
    public string addresse { get; set; }
    [Column("father")]
    public string? fatherid { get; set; }
    [Column("mother")]
    public string? motherid { get; set; }
    [NotMapped]
    public Civil father { get; set; }
    [NotMapped]
    public Civil mother { get; set; }
    
    [Column("date_delivery")]
    public DateTime deliveryDate { get; set; }
    [NotMapped]
    public List<PersonDesease> deseases { get; set; }
    
    public void GetCivilByCin()
    {
        using (var context = ApplicationDbContextFactory.Create())
        {
            var civil = context.civil
                .FirstOrDefault(c => c.cin == this.cin);

            if (civil != null)
            {
                this.nom = civil.nom;
                this.firstName = civil.firstName;
                this.dateOfBirth = civil.dateOfBirth;
                this.birthPlace = civil.birthPlace;
                this.addresse = civil.addresse;
                this.deliveryDate = civil.deliveryDate;
                
                if (civil.fatherid != null)
                {
                    this.father = new Civil
                    {
                        cin = civil.fatherid
                    };
                    this.father.GetCivilByCin(); // Assuming this is a method in the Civil class
                }

                if (civil.motherid != null)
                {
                    this.mother = new Civil
                    {
                        cin = civil.motherid
                    };
                    this.mother.GetCivilByCin(); // Assuming this is a method in the Civil class
                }

                var pd = new PersonDesease { cin = this.cin };
                this.deseases = pd.GetAllDeseasePerCivil();
            }
            else
            {
                throw new DataException("No cin match.");
            }
        }
    }
}