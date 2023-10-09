/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package service;

import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import jakarta.jws.WebResult;
import jakarta.jws.WebService;
import jakarta.jws.soap.SOAPBinding;

@WebService(targetNamespace="http://spoonless.github.io/ws/hello", serviceName="HelloService")
@SOAPBinding(parameterStyle = SOAPBinding.ParameterStyle.BARE)
public class HelloService {
  @WebMethod
  @WebResult(name = "helloMessage", targetNamespace = "http://spoonless.github.io/ws/hello")
  public String sayHello(
      @WebParam(name = "who", targetNamespace="http://spoonless.github.io/ws/hello") String name) {
    return "Hello " + name;
  }
}