/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/EjbWebService.java to edit this template
 */
package api;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.ejb.Stateless;

/**
 *
 * @author PRO112
 */
@WebService(serviceName = "NewWebService")
@Stateless()
public class NewWebService {

    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "hello")
    public String hello() {
        return "Hello sss!";
    }
}
