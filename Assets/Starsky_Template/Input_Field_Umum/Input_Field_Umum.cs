using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Input_Field_Umum : MonoBehaviour {
    [SerializeField]
    TMP_InputField _Tmp_Inputfield;

    
    // Sample_Scene :
    public void On_Refresh_Input_Field () {
        _Tmp_Inputfield.text = "";
    }

    void Start () {
        Start_A_C_Input_Field_Requirements_Start ();
    }
    #region System_Requirements
    [SerializeField]
    System_Requirements.C_Input_Field_Requirements_Start [] A_C_Input_Field_Requirements_Start = new System_Requirements.C_Input_Field_Requirements_Start[0];
    void Start_A_C_Input_Field_Requirements_Start () {
        if (A_C_Input_Field_Requirements_Bool.Length >0) {
            System_Requirements Req = new System_Requirements ();
            foreach (System_Requirements.C_Input_Field_Requirements_Start a in A_C_Input_Field_Requirements_Start) {
                Req.On_Process_Requirements_Start (a, _Tmp_Inputfield);
            }
        }
    }
    
    [SerializeField]
    System_Requirements.C_Input_Field_Requirements_Bool [] A_C_Input_Field_Requirements_Bool = new System_Requirements.C_Input_Field_Requirements_Bool[0];

    // Sample_Scene :
    public bool b_Check_Requirements () {
        bool Res = true;
        if (A_C_Input_Field_Requirements_Bool.Length >0) {
            System_Requirements Req = new System_Requirements ();
            foreach (System_Requirements.C_Input_Field_Requirements_Bool  a in A_C_Input_Field_Requirements_Bool) {
                bool b = Req.On_Process_Requirements_Bool (a, _Tmp_Inputfield);
                if (b == false) {
                    Res = false;
                    break;
                }
            }
        }
        return Res;
    }
    #endregion
}
