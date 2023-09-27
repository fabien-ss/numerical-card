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
@Correspondance(nomTable = "Output_money")
public class Output extends MoneyModel implements Serializable{
   
    @Correspondance(nomColonne = "money_output")
    double money;
    
    public Output() {
    }

    public Output(double money, Timestamp date, String idBanque) {
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
