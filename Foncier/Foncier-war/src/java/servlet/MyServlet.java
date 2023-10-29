/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */
package servlet;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import ejb.Banque;
import ejb.BanqueRemote;
import java.io.IOException;
import java.io.PrintWriter;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import java.lang.ProcessBuilder.Redirect.Type;
import java.util.List;
import java.util.Map;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.naming.InitialContext;
import javax.naming.NamingException;

/**
 *
 * @author PRO112
 */
@WebServlet(name = "MyServlet", urlPatterns = {"/MyServlet"})
public class MyServlet extends HttpServlet {

    
    public static BanqueRemote getServiceRemote() throws NamingException{
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
          //response.setContentType("application/json;charset=UTF-8");
        PrintWriter out = response.getWriter();
       
        Object banques = (List<Banque>) MyServlet.getServiceRemote().getBanqueByCin("000000000001");
        Gson gson = new Gson();        
        String sbanques = gson.toJson(banques);
        //sbanques = sbanques.replace("\\"\", "");
        out.println(sbanques);
        
// Analysez le JSON en un tableau de Map
        java.lang.reflect.Type type = new TypeToken<List<Map<String, Object>>>(){}.getType();
        List<Map<String, Object>> banqueList = gson.fromJson(sbanques, type);

        // Parcourez la liste d'objets
        for (Map<String, Object> banque : banqueList) {
            out.println("CIN: " + banque.get("cin"));
            out.println("Nom: " + banque.get("nom"));
            out.println("ID Banque: " + banque.get("idBanque"));

            // Parcourez les tableaux "debits" et "credits" s'ils sont présents
            List<Map<String, Object>> debits = (List<Map<String, Object>>) banque.get("debits");
            List<Map<String, Object>> credits = (List<Map<String, Object>>) banque.get("credits");

            if (debits != null) {
                out.println("Débits:");
                for (Map<String, Object> debit : debits) {
                    out.println("Money: " + debit.get("money"));
                    out.println("Date: " + debit.get("date"));
                }
            }

            if (credits != null) {
                out.println("Crédits:");
                for (Map<String, Object> credit : credits) {
                    out.println("Money: " + credit.get("money"));
                    out.println("Date: " + credit.get("date"));
                }
            }
            
        }
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
        } catch (Exception ex) {
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
        } catch (Exception ex) {
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
