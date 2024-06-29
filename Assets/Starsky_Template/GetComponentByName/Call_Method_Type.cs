using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Call_Method_Type {
    #region Example
    /*
    void On_Example () {
        GetComponentByName Gb = new GetComponentByName (); Type s = Gb.On_Get_Name ("Form_2");
        Component component = GetComponent(s);

        On_Call_Method (component, s, "On_Set", new Type [] {typeof (string)}, new object[] {"Set Value ini"});
    }
    */
    #endregion
    #region Implementation
    // Header_Canvas - Starsky :
    public void On_Call_Method (Component Cp, Type Type_Script, string Method_Name, Type [] Type_V, object [] Isi_V) {
        Component component = Cp;
        var method = Type_Script.GetMethod(Method_Name, Type_V);
        method.Invoke(component, Isi_V);

    }
    #endregion
}
