/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model.transaction;

import DAO.Model;
import DAO.Correspondance;
import java.io.Serializable;
import java.util.Vector;
/**
 *
 * @author PRO112
 */
@Correspondance(nomTable="v_user_banque")
public class Banque extends Model implements Serializable{
    
    @Correspondance(nomColonne = "cin")
    String cin;
    @Correspondance(nomColonne="banque_name")
    String nom;
    @Correspondance( nomColonne = "id_banque")
    int idBanque;
    
    Vector<Input> debits;
    Vector<Output> credits;
    Solde solde;

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

    public Vector<Input> getDebits() {
        return debits;
    }

    public void setDebits(Vector<Input> debits) {
        this.debits = debits;
    }

    public Vector<Output> getCredits() {
        return credits;
    }

    public void setCredits(Vector<Output> credits) {
        this.credits = credits;
    }

    public Solde getSolde() {
        return solde;
    }

    public void setSolde(Solde solde) {
        this.solde = solde;
    }
    
    
}
