/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/J2EE/EJB40/SessionLocal.java to edit this template
 */
package test;

import jakarta.ejb.Remote;

/**
 *
 * @author PRO112
 */
@Remote
public interface TestRemote {
    public String hello();
}
