using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Get_Data : MonoBehaviour {
    public static Get_Data Ins;
    void Awake () {
        Ins = this;
    }
    
    void On_Example_On_Get_Data_By_Name () {
        Get_Data.Ins.On_Get_Data_By_Name ("Affection");
    }
    // Object_Requirements :
    public object On_Get_Data_By_Name (string Name) {
        if (Dict_GameObject.TryGetValue(Name, out GameObject gameObject) &&
            Dict_Type.TryGetValue(Name, out Type componentType))
        {
           // return gameObject.GetComponent(componentType).On_Get_Field (Name);
            var component = gameObject.GetComponent(componentType);
            var method = componentType.GetMethod("On_Get_Field");
            return method.Invoke(component, new object[] { Name});
        } else {
            return null;
        }
    }
    
    #region Dict_Object
    Dictionary <string, GameObject> Dict_GameObject = new Dictionary <string, GameObject> ();
    Dictionary <string, Type> Dict_Type = new Dictionary <string, Type> ();
    bool b_Load_Dict_Object = false;
    void On_First_Load_Dict_Object () {
        if (!b_Load_Dict_Object) {
            b_Load_Dict_Object = true;
            Dict_Type = new Dictionary <string, Type> ();
        }
    }

    void On_Example_Add_Dict_Object () {
        On_Add_Dict_Object ("Strength", this.gameObject);  On_Add_Dict_Type ("Strength", typeof (Character_Status_1));
    }
    // Character_Status_Sumber - Character_Status_1 :
   public void On_Add_Dict_Object (string v, GameObject s) {
        Dict_GameObject.Add (v, s);
    }

    public void On_Add_Dict_Type (string v, Type s) {
        Dict_Type.Add (v, s);
    }
    #endregion
    #region Set_Data
    // Set_Data :
    public Dictionary <string, GameObject> Get_Dict_GameObject () {
        return Dict_GameObject;
    }

    public Dictionary <string, Type> Get_Dict_Type () {
        return Dict_Type;
    }
    #endregion
}
