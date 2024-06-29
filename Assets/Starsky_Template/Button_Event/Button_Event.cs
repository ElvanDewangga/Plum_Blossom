using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Button_Event : MonoBehaviour {
    [SerializeField]
    public string Event_V;
    [SerializeField]
    TMP_Text _Tmp_Text;
    #region Input_Event
    // Notification :
    public void On_Set_Event (string bal) {
        Event_V = bal;
    }

    public void On_Set_Title (string bal) {
        _Tmp_Text.text = bal;
    }
    
    #endregion
   public void On_Cli_Button_Event () {
    All_Scene_Go_Script.Ins._Button_Event_Server.On_Call_Button_Event(Event_V);
   }
}
