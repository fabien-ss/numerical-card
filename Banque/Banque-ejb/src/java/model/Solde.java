package model;

import dao.Correspondance;
import dao.Model;
import java.io.Serializable;

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "v_money")
public class Solde extends Model implements Serializable{
    
    @Correspondance(nomColonne = "money_total")
    double total;
    @Correspondance(nomColonne = "id_banque")
    int idBanque;
    @Correspondance(nomColonne = "banque_name")
    String banqueName;
    @Correspondance(nomColonne = "cin")
    String cin;
    
    public Solde() throws Exception{
        this.init("banque", "postgres", "fabien");
    }
    
    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }

    public int getIdBanque() {
        return idBanque;
    }

    public void setIdBanque(int idBanque) {
        this.idBanque = idBanque;
    }

    public String getBanqueName() {
        return banqueName;
    }

    public void setBanqueName(String banqueName) {
        this.banqueName = banqueName;
    }

    public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }
    
    
}
