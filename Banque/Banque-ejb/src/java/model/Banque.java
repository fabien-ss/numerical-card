/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import dao.*;
import java.io.Serializable;
import java.util.List;
import javax.naming.NamingException;
/**
 *
 * @author PRO112
 */
@Correspondance(nomTable="v_user_banque")
public class Banque extends Model implements Serializable{
    
    @Correspondance(nomColonne = "cin", primarykey = true)
    String cin;
    @Correspondance(nomColonne="banque_name")
    String nom;
    @Correspondance(nomColonne = "id_banque")
    int idBanque;
    
    Solde solde;
    List<Input> debits;
    List<Output> credits;
    
    
    public void Transaction(double montant, int idDevise, String cin1, String cin2, float lastChange, int idBanque, float vente) throws NamingException, Exception{
        // ilay cin1 no debitena dia cin2 no verifiena
        // mila argument vaovao prix taux de vente
        Solde s = new Solde();
        List<Solde> ss = s.executeQuery(null, "select * from v_money where cin='"+cin2+"' and id_banque = '"+idBanque+"'");
        s = ss.get(0);
        
        if(s.getTotal() < (montant * lastChange) ) throw new Exception("Error solde inferieur a la transaction demandée");
        
        Input in = new Input();
        in.cin = cin1;
        in.idBanque = idBanque + "";
        in.money = montant * lastChange;
        
        Output out = new Output();
        out.cin = cin1;
        out.idBanque = idBanque + "";
        out.money = 0;
        
        Output out2 = new Output();
        out2.cin = cin2;
        out2.idBanque = idBanque + "";
        out2.money = (float) (montant * vente);
        
        Input in2 = new Input();
        in2.cin = cin2;
        in2.idBanque = idBanque + "";
        in2.money = 0;
        
        in.insert(null);
        out.insert(null);
        
        out2.insert(null);
        in2.insert(null);
    }

    public Solde getSolde() {
        return solde;
    }

    public void setSolde(Solde solde) {
        this.solde = solde;
    }
    
    public static void main(String[] args) throws Exception {
//        FoncierRemote fr = CallEjb.getServiceFoncierRemote();
//        float montantactuel = (float) fr.getLastDeviseValue(1);
    }
    public List<Banque> getBanques(String cin) throws Exception{
        this.cin = cin;
        List<Banque> banques = this.selectAll(null);
        for (Banque banque : banques) {
            banque.setBanque(cin);
            List<Solde> soldes = new Solde().executeQuery(null, "select * from v_money where id_banque="+banque.idBanque+" and cin='"+cin+"'");
            if(soldes.size() > 0) banque.solde = soldes.get(0);
            
        }
        return banques;
    }
    
    public void setBanque(String cin) throws Exception{
        Input in = new Input();
        Output out = new Output();
        in.cin = cin;
        out.cin = this.cin;
       // this.debits = in.selectAll(null);
        this.debits = in.executeQuery(null, "select * from input_money where cin='"+cin+"' and id_banque='"+this.idBanque+"'" );
       // this.credits = out.selectAll(null);
        this.credits = in.executeQuery(null, "select * from output_money where cin='"+cin+"' and id_banque='"+this.idBanque+"'" );
    }
    
    public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }
    
    public Banque() throws Exception{
        this.init("banque", "postgres", "fabien");
    }

    public int getIdBanque() {
        return idBanque;
    }

    public void setIdBanque(int idBanque) {
        this.idBanque = idBanque;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public List<Input> getDebits() {
        return debits;
    }

    public void setDebits(List<Input> debits) {
        this.debits = debits;
    }

    public List<Output> getCredits() {
        return credits;
    }

    public void setCredits(List<Output> credits) {
        this.credits = credits;
    }

    
}
