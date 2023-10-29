namespace Sante.Models.service;
public class Banque
{
    
    public string cin { get; set; }
    public string nom { get; set; }
    public string idBanque { get; set; }
    public List<Debits> debits { get; set; }
    public List<Credits> credits { get; set; }
    public Solde Solde { get; set; }
    
}