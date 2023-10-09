/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package civil;

import java.io.Serializable;
import java.util.Vector;
import model.Territoire;

/**
 *
 * @author PRO112
 */
public class CivilHandler implements Serializable {
    
    String cin; 
    Vector<Territoire> territoires;
    
    public void getCivilsTerritory() throws Exception
    {
        Territoire call = new Territoire();
        String sql = "select * from territory where cin='"+this.cin+"'";
        this.territoires = (Vector<Territoire>) call.executeQuery(null, sql);
    }

    public String getCin() {
        return cin;
    }

    public void setCin(String cin) {
        this.cin = cin;
    }

    public Vector<Territoire> getTerritoires() {
        return territoires;
    }

    public void setTerritoires(Vector<Territoire> territoires) {
        this.territoires = territoires;
    }
    
    
}
