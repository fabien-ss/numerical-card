/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import DAO.Correspondance;
import DAO.Model;
import java.io.Serializable;

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "Territory") // anaran le table
public class Territoire extends Model implements Serializable {
    
    @Correspondance(nomColonne = "cin" /* ito zao tsy mitovy anaran 'le colonne sy attribut de natao cin*/, foreignkey = true /* atao true foreignkey raha foreignkey de raha primarykey de otrazany ihany*/) // asina correspondance izy vao kobony hoe colonne ana table, sinon tsy colonne
    String cin; 
    @Correspondance // reto mitovy daholo
    String longitude;
    @Correspondance
    String latitude;
    @Correspondance
    String addresse;
    @Correspondance
    Integer longeur;
    @Correspondance
    Integer largeur;
    @Correspondance
    String description;
    @Correspondance
    String titre;

    public Territoire() throws Exception{
        this.init("foncier", "postgres", "fabien");
    }
    
    public Territoire(String cin, String longitude, String latitude, String addresse, int longeur, int largeur, String description, String titre) throws Exception {
        this.init("foncier", "postgres",  "fabien");
        
        // raha mampiasa sequence manoka de afaka manamboatra id atao am setPrefixe(String) ny prefixe ex: PRS de atao ao am nom fonction le anaran'le sequence
        // de eo amle setColonnePrimaryKey elah manao hoe setId(this.construirePk(null)) // eto zao id no id an'le izy fa eto cin 
        this.setCin(cin);
        this.setLongitude(longitude);
        this.setLatitude(latitude);
        this.setAddresse(addresse);
        this.setLongeur(longeur);
        this.setLargeur(largeur);
        this.setDescription(description);
        this.setTitre(titre);
    }

    public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }

    public String getLongitude() {
        return longitude;
    }

    public void setLongitude(String longitude) {
        this.longitude = longitude;
    }

    public String getLatitude() {
        return latitude;
    }

    public void setLatitude(String latitude) {
        this.latitude = latitude;
    }

    public String getAddresse() {
        return addresse;
    }

    public void setAddresse(String addresse) {
        this.addresse = addresse;
    }

    public Integer getLongeur() {
        return longeur;
    }

    public void setLongeur(Integer longeur) {
        this.longeur = longeur;
    }

    public Integer getLargeur() {
        return largeur;
    }

    public void setLargeur(Integer largeur) {
        this.largeur = largeur;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getTitre() {
        return titre;
    }

    public void setTitre(String titre) {
        this.titre = titre;
    }
    
    
}
