using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Panel_Form_Show : MonoBehaviour {
   #region Form_Show
    public void On_Add_Form_Show (string Type_Form, string Field_V, string Isi_V) {
        GameObject Form_Sample = GameObject.Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample (Type_Form));
        Form_Sample.transform.SetParent (this.transform);
        
        Form_Sample.gameObject.SetActive (true);
        if (Form_Sample.GetComponentInChildren <Button_Event> () != null) {
            Button_Event Be = Form_Sample.GetComponentInChildren <Button_Event> ();
            Be.On_Set_Event (Field_V);
        }
        if (Form_Sample.GetComponent <Clone_Sample> () != null) {
            Clone_Sample Be = Form_Sample.GetComponent <Clone_Sample> ();
            Be.On_Set_b_Clone (true);
        }
        
        //Form_1 Fm = Form_Sample.GetComponent <Form_1> ();
        //Fm.On_Set (Field_V, Isi_V);
        
        GetComponentByName Gb = new GetComponentByName ();
        Type s = Gb.On_Get_Name (Type_Form);
        if (s!= null) {
            Component component = GetComponent(s);
            var method = s.GetMethod("On_Set", new Type[] { typeof(string), typeof(string) });
                if (method != null)
                {
                    method.Invoke(component, new object[] { Field_V, Isi_V});
                }
                else
                {
                    Debug.LogError("Metode 'On_Set' tidak ditemukan pada tipe " + s.Name);
                }
        }

        
        /*
        Form_Sample.gameObject.GetComponent <s> ().On_Test ();
        if (Type_Form == ) {

        }
        */
    }
   #endregion

}
