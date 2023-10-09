/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/EjbWebService.java to edit this template
 */
package restService;

import civil.CivilHandler;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.ejb.Stateless;
import java.util.Properties;
import javax.naming.Context;
import stat.TestRemote;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import model.Civil;
import service.Territoire;

/**
 *
 * @author PRO112
 */
@WebService(serviceName = "BanqueService")
@Stateless()
public class BanqueService {
        
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
    
    public static void main(String[] args) throws NamingException, Exception {
        //TestRemote test = getTestRemote();
       // CivilHandler cv = test.sendCivil("000000000003");
        Civil civil = new Civil();
        civil.getCivilsAccount("000000000002");
        System.out.println(civil);
        //for (Territoire territoire : cv.getTerritoires()) {
         //   System.err.println(territoire.getAddresse());
        //}   
    }
    
    @WebMethod(operationName = "consulationSolde")
    public Civil consultationSolde(String cin) throws Exception{
        Civil civil = new Civil();
        civil.getCivilsAccount(cin);
        return civil;
    }
    public BanqueService() {
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
