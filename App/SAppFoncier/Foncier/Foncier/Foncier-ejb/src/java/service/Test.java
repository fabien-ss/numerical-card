/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/J2EE/EJB40/StatelessEjbClass.java to edit this template
 */
package service;

import civil.CivilHandler;
import jakarta.ejb.Stateless;
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;
import model.Territoire;

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
        Territoire territoire;// = new Territoire();
        try {
            territoire = new Territoire();
            territoire.setCin(cin);
            territoire = (Territoire) territoire.select(null);
            return territoire;
        } catch (Exception ex) {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
    
    public static void main(String[] args) throws Exception {
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
        Territoire territoire;
        try {
            territoire = new Territoire();
            Vector<Territoire> territoires = new Vector<>();
            territoires = territoire.selectAll(null);
            return territoires;
        } catch (Exception ex) {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }

    @Override
    public CivilHandler sendCivil(String cin) {
        CivilHandler ch = new CivilHandler();
        ch.setCin(cin);
        try {
            ch.getCivilsTerritory();
            return ch;
        } catch (Exception ex) {
            Logger.getLogger(Test.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
}
