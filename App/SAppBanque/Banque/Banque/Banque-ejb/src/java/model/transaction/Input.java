/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model.transaction;
import DAO.*;
import java.io.Serializable;
import java.sql.Timestamp;
/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "Input_money")
public class Input extends Model implements Serializable{
   
    @Correspondance(nomColonne = "money_input")
    double money;
    @Correspondance(nomColonne = "cin", primarykey = true)
    String cin;
    @Correspondance(nomColonne = "date_input")
    Timestamp date;
    @Correspondance(nomColonne = "id_banque")
    String idBanque;

    public Input() throws Exception{
        this.init("banque", "postgres", "fabien");
    }

    public Input(double money, Timestamp date, String idBanque) throws Exception{
        this.init("banque", "postgres", "fabien");
        this.setMoney(money);
        this.setDate(date);
        this.setIdBanque(idBanque);
    }
    
    public double getMoney() {
        return money;
    }

    public void setMoney(double money) {
        this.money = money;
    }
 public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }

    public Timestamp getDate() {
        return date;
    }

    public void setDate(Timestamp date) {
        this.date = date;
    }

    public String getIdBanque() {
        return idBanque;
    }

    public void setIdBanque(String idBanque) {
        this.idBanque = idBanque;
    }
    
}
