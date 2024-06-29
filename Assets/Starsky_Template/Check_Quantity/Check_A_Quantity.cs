using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_A_Quantity : MonoBehaviour {
    [SerializeField]
    Check_Quantity [] A_Check_Quantity = new Check_Quantity [0];
    public int On_Check_Quantity (string Name_V, int Total_Value) {
        int Res = 0;
        if (!b_On_Load_Dict_Check_Quantity) {
            b_On_Load_Dict_Check_Quantity = true;
            On_Load_Dict_Check_Quantity ();
        }
        Res = Dict_Check_Quantity[Name_V].On_Check_Quantity (Total_Value);
        return Res;
    }
    #region Add_Check_Quantity
    void On_Example_Check_Quantity () {
        int Code_Quantity = 2;
        Check_Quantity Target = On_Get_Check_Quantity (Code_Quantity);
    }
    
    // Add_Check_Quantity :
    public Check_Quantity On_Get_Check_Quantity (int Code_Quantity_V) {
        return A_Check_Quantity [Code_Quantity_V];
    }
    #endregion
    #region Dictionary
    Dictionary <string, Check_Quantity> Dict_Check_Quantity = new Dictionary<string, Check_Quantity> ();
    bool b_On_Load_Dict_Check_Quantity = false;
    void On_Load_Dict_Check_Quantity () {
        Dict_Check_Quantity.Add ("Strength", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Stamina", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Agility", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Intelligence", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Charisma", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Faith", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Darkness", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Cooking", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Luck", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Crafting", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Inspection", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Apothecary", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Taming", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Magic", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Weapons", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Spells", A_Check_Quantity[0]);
        Dict_Check_Quantity.Add ("Affection", A_Check_Quantity[0]);

        Dict_Check_Quantity.Add ("Coin", A_Check_Quantity[1]);
        Dict_Check_Quantity.Add ("Cur_Stress", A_Check_Quantity[2]);
        Dict_Check_Quantity.Add ("Cur_Hp", A_Check_Quantity[3]);
        Dict_Check_Quantity.Add ("Cur_Mp", A_Check_Quantity[4]);

    }
    #endregion
}
