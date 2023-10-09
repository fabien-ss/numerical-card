/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package service;


import java.util.Properties;
import java.util.Vector;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import model.Territoire;



/**
 *
 * @author PRO112
 */
public class Test {
    public static TestRemote getTestRemote() throws NamingException{
        String host= "localhost";
        String port = "3700";
        Properties prop = new Properties();
        prop.put(Context.INITIAL_CONTEXT_FACTORY, "com.sun.enterprise.naming.SerialInitContextFactory");
        prop.put("org.omg.CORBA.ORBInitialHost",host);
        prop.put("org.omg.CORBA.ORBInitialPort",port);
        InitialContext context = new InitialContext(prop);
        TestRemote greeting = (TestRemote) context.lookup("java:global/Foncier/Test!service.TestRemote");
        return greeting;
    }
    
    public static void main(String[] args) throws NamingException, Exception {
        TestRemote t = Test.getTestRemote();
        Vector<Territoire> territoires = (Vector<Territoire>) t.getTerritoires("000000000002");
        
        for (Territoire territoire : territoires) {
            System.out.println(territoire.getAddresse());
        }
        // Civil civil = new Civil();
        //civil.getCivilsAccount("000000000002");
        //System.out.println(civil);   
    }
}
