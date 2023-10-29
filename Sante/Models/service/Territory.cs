namespace Sante.Models.service;
public class Territory
{
    public string cin { get; set; }
    public string adresse { get; set; }
    public int longeur { get; set; }
    public int largeur { get; set; }
    public string description { get; set; }
    public string titre { get; set; }
    public double surface { get; set; }
    public double perimetre { get; set; }
    public string[] coordonnees { get; set; }
    public string idTerritoire { get; set; }
}