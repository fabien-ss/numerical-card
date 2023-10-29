/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import DAO.Correspondance;
import DAO.Model;
import java.io.Serializable;
import java.sql.SQLException;
import java.util.List;
import java.sql.*;
import org.postgis.*;

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "Territory") // anaran le table
public class Territoire extends Model implements Serializable {
    
    @Correspondance(nomColonne = "cin" /* ito zao tsy mitovy anaran 'le colonne sy attribut de natao cin*/, foreignkey = true /* atao true foreignkey raha foreignkey de raha primarykey de otrazany ihany*/) // asina correspondance izy vao kobony hoe colonne ana table, sinon tsy colonne
    String cin; 
    @Correspondance (nomColonne = "adress_local")
    String adresse;
    @Correspondance
    Integer longueur;
    @Correspondance
    Integer largeur;
    @Correspondance
    String description;
    @Correspondance
    String titre;
    @Correspondance(nomColonne = "id_territory", primarykey = true)
    String idTerritoire;
    @Correspondance(nomColonne = "surface")
    double surface; 
    @Correspondance(nomColonne = "perimetre")
    double perimetre;
    String[] coordonnees;
    
    public String[] getCoordinates() throws Exception{
        System.out.println("Id territoire ="+this.idTerritoire);
     
        this.setAreasCoordinate(null);
        return this.coordonnees;
    }
    
    public void setAreasCoordinate(java.sql.Connection connection) throws SQLException, Exception{
        boolean main = true;
        if(connection == null || connection.isClosed()){
            connection = this.enterToBdd();
            main = false;
        }
        String sql = "SELECT ST_AsText(geom) FROM champs_de_terre where id_territory='"+this.idTerritoire+"'";
        System.out.println(sql);
        Statement preparedStatement = connection.createStatement();
        ResultSet resultSet = preparedStatement.executeQuery(sql);
        if (resultSet.next()) {
            String polygonGeom = (String) resultSet.getObject(1);
            System.out.println(polygonGeom);
            polygonGeom = polygonGeom.replace("((", "");
            polygonGeom = polygonGeom.replace("))", "");
            polygonGeom = polygonGeom.replace("POLYGON", "");
            this.coordonnees = polygonGeom.split(",");
        }
        if(!main) connection.close();
    }
    
    public void updateSurface(java.sql.Connection c) throws Exception{
        String sql2 = "update territory set perimetre = (select (ST_Length(geom) from champs_de_terre where id_territory='"+this.idTerritoire+"'))";
        
        sql2 = "update territory set perimetre = (select ST_Perimeter(geom::geography) from champs_de_terre where id_territory='"+this.idTerritoire+"') where id_territory ='"+this.idTerritoire+"'";
        System.out.println("Perimetre "+sql2);
        String sql = "update territory set surface = (SELECT  ST_Area(geom::geography) / 1000000 as area_km2 from champs_de_terre where id_territory='"+this.idTerritoire+"') where id_territory ='"+this.idTerritoire+"'";
        this.init("foncier", "postgres", "fabien");
        this.executeUpdate(c, sql);
        this.executeUpdate(c, sql2);
        
    }
    
    public void saveCoordinates(java.sql.Connection c) throws Exception{
        String sql = "INSERT INTO champs_de_terre(id_territory, geom) values ('"+this.idTerritoire+"', 'POLYGON((";
        for (String coordonnee : this.coordonnees) {
            sql += coordonnee + ",";
        }
        sql = sql.substring(0, sql.length() - 1);
        sql += "))')";
        this.init("foncier", "postgres", "fabien");
        this.executeUpdate(c, sql);
    }
    
    public static void main(String[] args) throws Exception {
       Territoire  t = new Territoire();
       t.setCin("000000000001");
       List<Territoire> territoires = t.getTerritoryByCin();
        for (Territoire territoire : territoires) {
            territoire.setAreasCoordinate(null);
            
            for (String coordonnee : territoire.getCoordonnees()) {
                System.out.println("Longitude, Latitude "+coordonnee);
            }
        }

    }

    
    public List<Territoire> getTerritoryByCin() throws Exception{
        List<Territoire> territoires = this.selectAll(null);
        /*for (Territoire territoire : territoires) {
            territoire.setAreasCoordinate(null);
        }*/
        return territoires;
    }
    
    public void initSequence(java.sql.Connection c) throws Exception{
        this.setLongPK(7);
        this.setPrefixe("T");
        this.setSequence("territory_id_territory_seq");
        this.setIdTerritoire(this.construirePK(c));
    }
    
    public Territoire() throws Exception{
        this.init("foncier", "postgres", "fabien");
    }

    public double getSurface() {
        return surface;
    }

    public void setSurface(double surface) {
        this.surface = surface;
    }

    public String[] getCoordonnees() {
        return coordonnees;
    }

    public void setCoordonnees(String[] coordonnees) {
        this.coordonnees = coordonnees;
    }
    
    public String[] getCoordonnee() {
        return coordonnees;
    }

    public void setCoordonnee(String[] coordonnee) {
        this.coordonnees = coordonnee;
    }

    public String getIdTerritoire() {
        return idTerritoire;
    }

    public void setIdTerritoire(String idTerritoire) {
        this.idTerritoire = idTerritoire;
    }

    public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        if(cin.isEmpty()) throw new IllegalArgumentException("Cin invalide");
        this.cin = cin;
    }

    public String getAdresse() {
        return adresse;
    }

    public void setAdresse(String adresse) {
        this.adresse = adresse;
    }

    public Integer getLongueur() {
        return longueur;
    }

    public void setLongueur(Integer longueur) {
        this.longueur = longueur;
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

    public double getPerimetre() {
        return perimetre;
    }

    public void setPerimetre(double perimetre) {
        this.perimetre = perimetre;
    }
    
    
}
