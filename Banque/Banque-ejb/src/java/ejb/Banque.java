/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/J2EE/EJB40/StatefulEjbClass.java to edit this template
 */
package ejb;

import com.google.gson.Gson;
import jakarta.ejb.Stateful;
import java.util.ArrayList;
import java.util.List;
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author PRO112
 */
@Stateful
public class Banque implements BanqueRemote {

    @Override
    public String hello() {
        return "Hello";
    }

    @Override
    public Object getBanqueByCin(String cin) {
        List<model.Banque> banques = new ArrayList<>();
        try {
            banques = new model.Banque().getBanques(cin);
            //Gson gson = new Gson();
            return banques;//gson.toJson(banques);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return "";
    }

    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")

    @Override
    public String doTransaction(double montant, int idDevise, String cin1, String cin2, float lastChange, int idBanque, float vente) {
        try {
            new model.Banque().Transaction(montant, idDevise, cin1, cin2, lastChange, idBanque, vente);
            System.out.println("Nety tsara");
            return "Success";
        } catch (Exception ex) {
            System.out.println("Tsy mety fa ambany solde");
            return "Tsy mety " +ex.getMessage();
         //   Logger.getLogger(Banque.class.getName()).log(Level.SEVERE, null, ex);
            
        }
    }

    @Override
    public Object ListeBanques() {
        
        return null;
        
    }
}
