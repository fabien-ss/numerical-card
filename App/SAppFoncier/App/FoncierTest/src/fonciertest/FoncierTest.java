/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package fonciertest;

import java.util.Properties;
import java.util.Vector;
import javax.naming.Context;
import javax.naming.InitialContext;
import model.Territoire;
import service.TestRemote;

/**
 *
 * @author PRO112
 */
public class FoncierTest {
    
    TestRemote terrotoire;
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.println("test");
        try {
            String host= "localhost";
            String port = "3700";
            Properties prop = new Properties();
            prop.put(Context.INITIAL_CONTEXT_FACTORY, "com.sun.enterprise.naming.SerialInitContextFactory");
            prop.put("org.omg.CORBA.ORBInitialHost",host);
            prop.put("org.omg.CORBA.ORBInitialPort",port);
            InitialContext context = new InitialContext(prop);
            
            TestRemote greeting = (TestRemote) context.lookup("java:global/Foncier/Test!stat.TestRemote");
            
            Vector<Territoire> t = greeting.getTerritoires("000000000003");
            
            context.close();
            
        } catch(Exception e) {
            e.printStackTrace();
        }
    }
    
}
