using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Panel_Model_1 : MonoBehaviour {

   [SerializeField]
   TMP_Text Number_Tx, Title_Tx, Effect_Tx;
   [SerializeField]
   TMP_Text Coin_Tx; 
   public string Title; 
   int Number, Coin, Min_Coin, Max_Coin;
   List <Field_1> L_Effect_Field_1 = new List<Field_1> ();
   // Panel_Model_1_Data :
   public void On_Get_Data (string Title_V, List <Field_1> L_Effect_Field_1_V, int Coin_V, int Min_Coin_V, int Max_Coin_V) {
        Coin = Coin_V; Min_Coin = Min_Coin_V; Max_Coin = Max_Coin_V;
        Number_Tx.text = Number.ToString ();
        Title = Title_V;
        Title_Tx.text = Title_V;
        L_Effect_Field_1 = L_Effect_Field_1_V;
        
        Effect_Tx.text  = "";
        int x = 0;
        for (x=0; x <L_Effect_Field_1.Count; x++) {
            if (x < L_Effect_Field_1.Count -1) { // Awal + tengah
                Effect_Tx.text += L_Effect_Field_1[x].Code_Str + " +, ";
            } else { // Terakhir :
                Effect_Tx.text += L_Effect_Field_1[x].Code_Str + " +";
            }
        }
        
        if (Min_Coin_V == 0) {
            Coin_Tx.text = Coin.ToString ();
        } else {
            Coin_Tx.text = Min_Coin.ToString () + " - " + Max_Coin.ToString ();
        }
   }
}
