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
public class Input extends MoneyModel implements Serializable{
   
    @Correspondance(nomColonne = "money_input")
    double money;
    
    public Input() {
    }

    public Input(double money, Timestamp date, String idBanque) {
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

}
