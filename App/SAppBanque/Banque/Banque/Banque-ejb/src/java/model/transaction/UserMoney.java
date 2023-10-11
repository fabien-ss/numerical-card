/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model.transaction;

import DAO.Model;
import DAO.Correspondance;
import java.io.Serializable;

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "V_MONEY")
public class UserMoney extends Model implements Serializable{
    @Correspondance(nomColonne = "cin")
    String cin;
    @Correspondance(nomColonne = "money_total")
    double money;
    @Correspondance(nomColonne = "id_banque")
    String id_banque;
    @Correspondance(nomColonne = "banque_name")
    String banquename;
   
    Banque banques;
    public UserMoney() throws Exception{
        this.init("banque", "postgres", "fabien");
    }
    public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }

    public double getMoney() {
        return money;
    }

    public void setMoney(double money) {
        this.money = money;
    }

    public String getId_banque() {
        return id_banque;
    }

    public void setId_banque(String id_banque) {
        this.id_banque = id_banque;
    }

    public String getBanquename() {
        return banquename;
    }

    public void setBanquename(String banquename) {
        this.banquename = banquename;
    }

    public Banque getBanques() {
        return banques;
    }

    public void setBanques(Banque banques) {
        this.banques = banques;
    }
    
}
