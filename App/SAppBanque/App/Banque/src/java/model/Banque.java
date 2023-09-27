/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import DAO.*;
import java.io.Serializable;

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "Banque")
public class Banque extends Model implements Serializable {
    
    @Correspondance(nomColonne = "id_banque", primarykey = true)
    String idBanque;
    @Correspondance(nomColonne = "banque_name")
    String nom;

    public Banque(String nom, String prefixe) throws Exception {
        //this.setPrefixe(prefixe);
        this.setNom(nom);
       // this.setSequence("seq_banque");
      //  this.setIdBanque(this.construirePK(null));
    }
    public Banque(){
        
    }
    public String getIdBanque() {
        return idBanque;
    }

    public void setIdBanque(String idBanque) throws Exception{
        if(idBanque.isEmpty()) throw new Exception("Sequence or function constructpk hasn't been called");
        this.idBanque = idBanque;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }
    public static void main(String[] args) throws Exception {
        Banque b = new Banque("BOI", "BOI");
        b.insert(null);
    }
}
