/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;
import dao.*;
import java.io.Serializable;
import java.sql.Timestamp;
/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "Output_money")
public class Output extends Model implements Serializable{
   
    
    @Correspondance(nomColonne = "cin", primarykey = true)
    String cin;
    @Correspondance(nomColonne = "money_value")
    float money;
    @Correspondance(nomColonne = "date_output")
    Timestamp date;
    @Correspondance(nomColonne = "id_banque")
    String idBanque;

    public Output() throws Exception{
        this.init("banque", "postgres", "fabien");
    }
    public String getCin() {
        return this.cin;
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
    
    public Output(float money, Timestamp date, String idBanque)throws Exception{
        this.init("banque", "postgres", "fabien");
        this.setMoney(money);
        this.setDate(date);
        this.setIdBanque(idBanque);
    }
    
    public float getMoney() {
        return money;
    }

    public void setMoney(float money) {
        this.money = money;
    }

}
