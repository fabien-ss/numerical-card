/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */
package servlet;

import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import ejb.BanqueRemote;
import ejbFoncier.FoncierRemote;
import java.io.IOException;
import java.io.PrintWriter;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import model.CourDeChange;

/**
 *
 * @author PRO112
 */
@WebServlet(name = "Transcation", urlPatterns = {"/Transcation"})
public class Transcation extends HttpServlet {  
    
    public static FoncierRemote getServiceFoncierRemote() throws NamingException{
        Properties prop = new Properties();
        InitialContext context = new InitialContext(prop);
        FoncierRemote greeting = (FoncierRemote) context.doLookup("java:global/Foncier-ejb/Foncier!ejbFoncier.FoncierRemote");
        return greeting;
    }
    
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException, NamingException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            
            float montant = Float.valueOf(request.getParameter("montant"));
            String idDevises = request.getParameter("idDevise");
            String cin1 = request.getParameter("cin1");
            String cin2 = request.getParameter("cin2");
            int idBanque = Integer.valueOf(request.getParameter("idBanque"));
            int idDevise= Integer.valueOf(idDevises);
            
            System.out.println("ito devise "+idDevises);
            // ici on prends le derier cour
            Object banques = (CourDeChange) Transcation.getServiceFoncierRemote().getLastDeviseValue(idDevise);
            Gson gson = new Gson();        
            String sbanques = gson.toJson(banques);
          
            
            JsonParser parser = new JsonParser();
            JsonObject jsonObject = parser.parse(sbanques).getAsJsonObject();
            String lastChangeString = jsonObject.get("montant").getAsString();
            String lastVentePrice = jsonObject.get("montantvente").getAsString();
                    
            
            BanqueRemote br = MyServlet.getServiceBanqueRemote();
            float lastChange = Float.valueOf(lastChangeString);
            float vente = Float.valueOf(lastVentePrice);
            String message = br.doTransaction(montant, idDevise, cin1, cin2, lastChange, idBanque, vente);
            out.println(gson.toJson(message));
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
        } catch (NamingException ex) {
            Logger.getLogger(Transcation.class.getName()).log(Level.SEVERE, null, ex);
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
            Logger.getLogger(Transcation.class.getName()).log(Level.SEVERE, null, ex);
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
