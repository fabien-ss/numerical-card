/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/J2EE/EJB40/SessionLocal.java to edit this template
 */
package service;

import jakarta.ejb.Remote;
import java.util.Vector;
import model.Territoire;
import civil.CivilHandler;
/**
 *
 * @author PRO112
 */
@Remote
public interface TestRemote {
    public String hello();
    public Object getTerritoire(String cin);
    public Vector<Territoire> getTerritoires(String cin);
    public CivilHandler sendCivil(String cin);
}
