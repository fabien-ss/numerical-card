/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */
package servlet;

import com.google.gson.Gson;
import ejb.BanqueRemote;
import ejbFoncier.FoncierRemote;
import java.io.IOException;
import java.io.PrintWriter;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import java.util.List;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import model.Banque;
import model.Territoire;

/**
 *
 * @author PRO112
 */
@WebServlet(name = "MyServletBanque", urlPatterns = {"/MyServletBanque"})
public class MyServletBanque extends HttpServlet {

    public static FoncierRemote getServiceFoncierRemote() throws NamingException{
        Properties prop = new Properties();
        InitialContext context = new InitialContext(prop);
        System.out.println(context.doLookup("java:global/Foncier-ejb/Foncier!ejbFoncier.FoncierRemote").getClass());
        FoncierRemote greeting = (FoncierRemote) context.doLookup("java:global/Foncier-ejb/Foncier!ejbFoncier.FoncierRemote");
        return greeting;
    } 
    
    public static BanqueRemote getServiceBanqueRemote() throws NamingException{
         //String host= "localhost";
        //String port = "3700";
        Properties prop = new Properties();
        //prop.put(Context.INITIAL_CONTEXT_FACTORY, "com.sun.enterprise.naming.SerialInitContextFactory");
        //prop.put("org.omg.CORBA.ORBInitialHost",host);
        //prop.put("org.omg.CORBA.ORBInitialPort",port);
        InitialContext context = new InitialContext(prop);
      
        System.out.println(context.doLookup("java:global/Banque-ejb/Banque!ejb.BanqueRemote").getClass());
        
        BanqueRemote greeting = (BanqueRemote) context.doLookup("java:global/Banque-ejb/Banque!ejb.BanqueRemote");
        return greeting;
    } 
    
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException, NamingException {
          response.setContentType("application/json;charset=UTF-8");
        String cin = request.getParameter("cin");
        cin = cin.trim();
        PrintWriter out = response.getWriter();
        Gson gson = new Gson();
        
        Object banques = (List<ejb.Banque>) MyServlet.getServiceBanqueRemote().getBanqueByCin(cin);
        String sbanques = gson.toJson(banques);
        //sbanques = sbanques.replace("\\"\", "");
        out.println(sbanques);
    }
    
    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            processRequest(request, response);
        } catch (NamingException ex) {
            Logger.getLogger(MyServlet.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try {
            processRequest(request, response);
        } catch (NamingException ex) {
            Logger.getLogger(MyServlet.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
