/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import dao.Correspondance;
import dao.Model;
import java.io.Serializable;
import java.sql.Timestamp;

/**
 *
 * @author PRO112
 */
public class MoneyModel extends Model implements Serializable {
    
    @Correspondance(nomColonne = "cin", primarykey = true)
    String cin;
    @Correspondance(nomColonne = "date_input")
    Timestamp date;
    @Correspondance(nomColonne = "id_banque")
    String idBanque;

    public MoneyModel() throws Exception{
        this.init("banque", "postgres", "fabien");
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
