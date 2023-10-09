/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import java.io.Serializable;
import java.util.Vector;
import model.transaction.Banque;
import model.transaction.Input;
import model.transaction.Output;
import model.transaction.Solde;

/**
 *
 * @author PRO112
 */
public class Civil implements Serializable{

    String cin;
    Vector<Banque> banques;
    Vector<Solde> soldeAuCourDuTemps;
    
    public void getCivilsAccount(String cin) throws Exception{
        this.cin = cin;
        Banque banque = new Banque();
        this.banques = banque.executeQuery(null, "select * from v_user_banque where cin='"+this.cin+"'");
        for (Banque b : banques) {
            Input in = new Input();
            String sql = "select * from input_money where id_banque='"+b.getIdBanque()+"' and cin='"+this.cin+"'";
            b.setDebits((Vector<Input>) in.executeQuery(null, sql));
            Output out = new Output();
            String sql2 = "select * from output_money where id_banque='"+b.getIdBanque()+"' and cin='"+this.cin+"'";
            b.setCredits((Vector<Output>) in.executeQuery(null, sql2));
        }
    }
    public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }

    public Vector<Banque> getBanques() {
        return this.banques;
    }

    public void setBanques(Vector<Banque> banques) {
        this.banques = banques;
    }
    
    
}
