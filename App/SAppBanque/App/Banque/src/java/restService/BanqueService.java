/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/EjbWebService.java to edit this template
 */
package restService;

import jakarta.ejb.EJB;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import jakarta.ejb.Stateless;
import java.util.Properties;
import javax.naming.Context;
import javax.naming.InitialContext;
import service.Territoire;
import stat.TestRemote;

import javax.naming.InitialContext;
import javax.naming.NamingException;

/**
 *
 * @author PRO112
 */
@WebService(serviceName = "BanqueService")
@Stateless()
public class BanqueService {
    
    @EJB
    public TestRemote test;
    
    public static TestRemote getTestRemote() throws NamingException{
        String host= "localhost";
        String port = "3700";
        Properties prop = new Properties();
        prop.put(Context.INITIAL_CONTEXT_FACTORY, "com.sun.enterprise.naming.SerialInitContextFactory");
        prop.put("org.omg.CORBA.ORBInitialHost",host);
        prop.put("org.omg.CORBA.ORBInitialPort",port);
        InitialContext context = new InitialContext(prop);
        TestRemote greeting = (TestRemote) context.lookup("java:global/Foncier/Test!stat.TestRemote");
        return greeting;
    }

    public BanqueService() throws NamingException {
       // this.test = getTestRemote();
    }
    @WebMethod(operationName = "hello")
    public String hello() {
        return "Hello ";
    }
    @WebMethod(operationName = "")
    public String getBanque(){
        return "ok";
    }
}
