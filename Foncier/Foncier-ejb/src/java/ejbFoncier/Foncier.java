/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/J2EE/EJB40/StatefulEjbClass.java to edit this template
 */
package ejbFoncier;

import com.google.gson.Gson;
import jakarta.ejb.Stateful;
import java.util.ArrayList;
import java.util.List;
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;
import model.CourDeChange;
import model.Devise;
import model.Territoire;

/**
 *
 * @author PRO112
 */
@Stateful
public class Foncier implements FoncierRemote {
    
    
    @Override
    public Object getTerritoires(String cin) {
        Territoire territoire;
        try {
            territoire = new Territoire();
            territoire.setCin(cin);
            List<Territoire> territoires = territoire.getTerritoryByCin();
            return territoires;//new Gson().toJson(territoires);
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return "qsd";
    }
    public static void main(String[] args) {
        Object d = new Foncier().getTerritoires("000000000003");
        System.out.println(d);
    }

    @Override
    public Object getAllDevise() {
        List<Devise> listes = new ArrayList<>();
        try {
            Devise d = new Devise();
            listes = d.getAllDevise();
        } catch (Exception ex) {
            Logger.getLogger(Foncier.class.getName()).log(Level.SEVERE, null, ex);
        }
        return listes;
        //throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }

    @Override
    public Object getLastDeviseValue(int idDevise) {
        CourDeChange cc = null;    
        try{
            cc = new CourDeChange();
            cc.setIdDevise(idDevise);
            return cc.ObtenirDernierChange();
        }
        catch(Exception ex){
            ex.printStackTrace();
        }
        return cc;
    }

    @Override
    public String[] getCoordinates(String idTerritoire) {
        System.out.println(idTerritoire);
        Territoire t;
        try {
            t = new Territoire();
            t.setIdTerritoire(idTerritoire);
            return t.getCoordinates();
        } catch (Exception ex) {
            Logger.getLogger(Foncier.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
        //throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}
