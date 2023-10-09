/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/J2EE/EJB40/StatelessEjbClass.java to edit this template
 */
package stat;

import civil.CivilHandler;
import jakarta.ejb.Stateless;
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;
import service.Territoire;

/**
 *
 * @author PRO112
 */
@Stateless
public class Test implements TestRemote {

    @Override
    public String hello() {
        return "Hello";
    }

    @Override
    public Territoire getTerritoire(String cin) {
        Territoire territoire = new Territoire();
        territoire.setCin(cin);
        try {
            territoire = (Territoire) territoire.select(null);
        } catch (Exception ex) {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
        return territoire;
    }
    
    public static void main(String[] args) {
        Territoire territoire = new Territoire();
        territoire.setCin("000000000003");
        try {
            territoire = (Territoire) territoire.select(null);
            System.out.println(territoire.getAddresse());
        } catch (Exception ex) {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public Vector<Territoire> getTerritoires(String cin) {
        Territoire territoire = new Territoire();
        territoire.setCin(cin);
        Vector<Territoire> territoires = new Vector<>();
        try {
            territoires = territoire.selectAll(null);
        } catch (Exception ex) {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
        return territoires;
    }

    @Override
    public CivilHandler sendCivil(String cin) {
        CivilHandler ch = new CivilHandler();
        ch.setCin(cin);
        try {
            ch.getCivilsTerritory();
            return ch;
            //throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
        } catch (Exception ex) {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
}
