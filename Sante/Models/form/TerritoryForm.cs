using System.ComponentModel.DataAnnotations;
namespace Sante.Models.form;

public class TerritoryForm
{   
    [Required(ErrorMessage = "Please set adress.")]
    public string adresse{ get; set;}
    [Required(ErrorMessage = "Please set a description.")]
    public string description{ get; set;}
    [Required(ErrorMessage = "Please set length.")]
    public int longueur{ get; set;}
    [Required(ErrorMessage = "Pealse set width.")]
    public int largeur{ get; set;}
    [Required(ErrorMessage = "Please set Title.")]
    public string titre{ get; set;}
    [Required(ErrorMessage = "Set coordinates.")]
    public string[] coordonnees{ get; set;}
    public string? cin { get; set; }

    public void JoinPoints()
    {
        this.coordonnees[this.coordonnees.Length - 1] = this.coordonnees[0];
    }
}

