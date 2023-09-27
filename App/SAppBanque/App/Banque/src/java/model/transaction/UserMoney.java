/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model.transaction;

import DAO.Correspondance;
import java.io.Serializable;
import model.Banque;

/**
 *
 * @author PRO112
 */
@Correspondance(nomTable = "V_MONEY")
public class UserMoney implements Serializable{
   
    String cin;
    double money;
    double id_banque;
    String banquename;
    Banque banques;

}
