/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */
package servlet;

import com.google.gson.Gson;
import ejbFoncier.FoncierRemote;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Properties;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import java.util.List;
import model.CourDeChange;
import model.Devise;

/**
 *
 * @author PRO112
 */
@WebServlet(name = "getLastChange", urlPatterns = {"/getLastChange"})
public class getLastChange extends HttpServlet {
    
    public static FoncierRemote getServiceFoncierRemote() throws NamingException{
        Properties prop = new Properties();
        InitialContext context = new InitialContext(prop);
        FoncierRemote greeting = (FoncierRemote) context.doLookup("java:global/Foncier-ejb/Foncier!ejbFoncier.FoncierRemote");
        return greeting;
    } 
    
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        
            /* TODO output your page here. You may use following sample code. */
          
        try(PrintWriter out = response.getWriter()) {
          int id = 1;
//            Object banques = (CourDeChange) getDevise.getServiceFoncierRemote().getLastDeviseValue(id);
//            Gson gson = new Gson();        
//            String sbanques = gson.toJson(banques);
//            //sbanques = sbanques.replace("\\"\", "");
//            out.println(sbanques);
        }
        catch(Exception e){
          
            e.printStackTrace();
        
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
        processRequest(request, response);
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
        processRequest(request, response);
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
