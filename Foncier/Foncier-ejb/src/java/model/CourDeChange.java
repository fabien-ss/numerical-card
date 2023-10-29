/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import DAO.Correspondance;
import DAO.Model;
import java.io.Serializable;
import java.sql.Timestamp;
import java.util.List;

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "courdechange")
public class CourDeChange extends Model implements Serializable{
    
    /* id_devise int REFERENCES devise(id_devise),
    montant float,
    date_change timestamp */
    
    @Correspondance(nomColonne = "id_devise")
    int idDevise;
  
    @Correspondance(nomColonne = "tauxvente")
    double montantvente;
    @Correspondance(nomColonne = "date_change")
    Timestamp dateChange;
    @Correspondance(nomColonne = "montant")
    double montant;

    public double getMontantvente() {
        return montantvente;
    }

    public void setMontantvente(double montantvente) {
        this.montantvente = montantvente;
    }

    
    
    
    public CourDeChange ObtenirDernierChange() throws Exception {
        String sql = "select * from courdechange where id_devise = "+this.idDevise+" and date_change = (select max(date_change) from courdechange where id_devise = "+this.idDevise+")";
      //  sql= "select * from courdechange where id_devise = "+this.idDevise+" order by date_change limit 1 desc";
        List<CourDeChange> c = (this.executeQuery(null, sql));
        for (CourDeChange courDeChange : c) {
            System.out.println("dsq "+courDeChange.getMontant());
            System.out.println("dsdsqdq "+courDeChange.getMontantvente());
        }
        System.out.println(c.get(0).getMontant());
        return c.get(0);
    }
    
    public CourDeChange() throws Exception{
        this.init("foncier","postgres", "fabien");
    }

    public int getIdDevise() {
        return idDevise;
    }

    public void setIdDevise(int idDevise) {
        this.idDevise = idDevise;
    }

    public double getMontant() {
        return montant;
    }

    public void setMontant(double montant) {
        this.montant = montant;
    }

    public Timestamp getDateChange() {
        return dateChange;
    }

    public void setDateChange(Timestamp dateChange) {
        this.dateChange = dateChange;
    }
    
    
}
