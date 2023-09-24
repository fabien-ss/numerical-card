/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package Api;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;   

/**
 *
 * @author PRO112
 */
@WebService(serviceName = "BanqueService")
public class BanqueService {
    /**
     * This is a sample web service operation
     * @return 
     */
    public String index(){
        return "OH";
    }
}
