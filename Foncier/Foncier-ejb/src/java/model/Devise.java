/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import DAO.Correspondance;
import DAO.Model;
import java.io.Serializable;
import java.util.List;

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "devise")
public class Devise extends Model implements Serializable{
    
    @Correspondance(nomColonne =  "id_devise")
    int id_devise;// SERIAL PRIMARY KEY,
    @Correspondance(nomColonne =  "nom")
    String nom;
    @Correspondance(nomColonne =  "symbole")
    String symbole;

    public List<Devise> getAllDevise() throws Exception{
        return this.executeQuery(null, "select * from devise");
    }
    
    public Devise() throws Exception{
        this.init("foncier","postgres", "fabien");
    }

    public Devise(int id_devise, String nom, String symbole) throws Exception {
        this.id_devise = id_devise;
        this.nom = nom;
        this.symbole = symbole;
        this.init("foncier","postgres", "fabien");
    }
    
    public int getId_devise() {
        return id_devise;
    }

    public void setId_devise(int id_devise) {
        this.id_devise = id_devise;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getSymbole() {
        return symbole;
    }

    public void setSymbole(String symbole) {
        this.symbole = symbole;
    }
    
    
}
