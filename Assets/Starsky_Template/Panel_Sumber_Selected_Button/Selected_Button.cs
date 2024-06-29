using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selected_Button : MonoBehaviour {
    #region Data
    // Sumber_Selected_Button :
    public string Event = "";
    // Sumber_Selected_Button, Part_Time_Job_Utama :
    public int [] A_Int;
    public string [] A_String;
    
    #endregion

    #region Head
    [SerializeField]
    Button Event_Button;
    bool b_Select = false;
    public void On_Cli () {
        if (b_Select) {
        } else {
            _Line_Selected_Button._Panel_Sumber_Selected_Button.On_Selected_Button (this);
        }
    }

    // Panel_Sumber_Selected_Button :
    public void On_Select () {
        b_Select = true;
        Event_Button.interactable = false;
        All_Scene_Go_Script.Ins._Sumber_Selected_Button.On_Doing_Event (this);
    }
    // Panel_Sumber_Selected_Button :
    public void Off_Select () {
        b_Select = false;
        Event_Button.interactable = true;
    }
    #endregion
    #region Line_Selected_Button
    [Header ("Boleh diinput Start (Panel/Layout) atau input manual untuk aktif di awal sebelum nyala.")]
    Line_Selected_Button _Line_Selected_Button;
    public void On_Input_Line_Selected_Button (Line_Selected_Button s) {
        _Line_Selected_Button = s;
    }
    #endregion
}
