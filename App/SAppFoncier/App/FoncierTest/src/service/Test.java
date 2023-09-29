/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package service;

import bean.LandBean;
import bean.LandBeanRemote;
import java.util.List;
import java.util.Properties;
import java.util.Vector;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import stat.TestRemote;
import utils.Land;

/**
 *
 * @author PRO112
 */
public class Test {
    public static void main(String[] args) throws NamingException {
               try{    
            Properties propl = new Properties();
            propl.setProperty("org.com.CORBA.ORBInitialHost" , "172.50.113.86");
            propl.setProperty("org.com.CORBA.ORBInitialPort" , "3700");
            InitialContext ps = new InitialContext(propl);
                   System.out.println(propl);
                   
            System.out.println("CUCUCUCUCUCUCUCU");
            LandBeanRemote ldr = (LandBeanRemote)ps.lookup("java:global/TANY/LandBean!bean.LandBeanRemote");
            List<Land> lst = ldr.getLand("00000001"); 
            System.out.println(lst);
            for( Land ld : lst )
                System.out.println(ld.getRefOwner());
        }catch(Exception e){
            e.printStackTrace();
        }
    }
}
