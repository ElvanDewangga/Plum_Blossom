using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Set_Data : MonoBehaviour {
    public static Set_Data Ins;
    
    void Awake () {
        Ins = this;
    }

    void On_Example_On_Set_Data_Inc_By_Name () {
        // Point Affection akan bertambah 10.
        Set_Data.Ins.On_Set_Data_Inc_By_Name("Affection", 10);
    }

    // Object_Requirements, Plum_Blossom_Show_kegiatan :
    public void On_Set_Data_Inc_By_Name(string Name, int Inc_Value) {
        Set_Data_Name = Name;
        // memberikan value untuk menambahkan 
        Dictionary<string, GameObject> Dict_GameObject = Get_Data.Ins.Get_Dict_GameObject();
        Dictionary<string, Type> Dict_Type = Get_Data.Ins.Get_Dict_Type();
        
        if (Dict_GameObject.TryGetValue(Name, out GameObject gameObject) &&
            Dict_Type.TryGetValue(Name, out Type componentType)) {
            int.TryParse (Get_Data.Ins.On_Get_Data_By_Name (Name).ToString (), out int target);
            
            var component = gameObject.GetComponent(componentType);
            if (component != null) {
                var method = componentType.GetMethod("On_Set_Field");
                if (method != null) {
               //     Debug.Log (target + "+" + Inc_Value);
                    int Total_Value =  target +Inc_Value;
                    Total_Value = Home_Scene.Ins._Check_A_Quantity.On_Check_Quantity (Name, Total_Value);
                    method.Invoke(component, new object[] { Name,  Total_Value});
                } else {
                    Debug.LogError ("Method Null");
                }
            } else {
                Debug.LogError ("Component Null");
            }
        } else {
            // Handle the case where the Name is not found
            Debug.LogError($"Name {Name} not found in the dictionaries.");
        }
        On_Doing_Refresh();
    }

    string Set_Data_Name = "";

    public void On_Set_Data_Non_Mono_Inc_By_Name(string Name, int Inc_Value) {
        Set_Data_Name = Name;
        if (Name == "Coin") {
            Home_Scene.Ins._Character_Status_Sumber._Status_Universal.Coin += Inc_Value;
        }
        On_Doing_Refresh();
    }

    

    #region Dict_Object
    Dictionary<string, UnityAction> Dict_UnityAction = new Dictionary<string, UnityAction>();
    bool b_Load_Dict_Object = false;

    void On_Example_Add_Dict_Object() {
        // Set_Data.Ins.On_Add_Dict_Type("Coin", Event_Refresh);
    }

    public void On_Add_Dict_UnityAction(string v, UnityAction s) {
        if (!b_Load_Dict_Object) {
            b_Load_Dict_Object = true;
            Dict_UnityAction = new Dictionary<string, UnityAction>();
        }
        Dict_UnityAction.Add(v, s);
    }
    #endregion

    #region Refresh_Data
    void On_Example_Doing_Refresh () {
        On_Doing_Refresh ("Melakukan_Refresh_Tampilan");
    }
    
    public void On_Doing_Refresh (string Name_V) {
        Set_Data_Name = Name_V;
    }
    
    void On_Doing_Refresh() {
        if (Dict_UnityAction.TryGetValue(Set_Data_Name, out var action)) {
            action.Invoke();
        }
    }
    #endregion
}