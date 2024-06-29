using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Sub_Event : Button_Event {
  [SerializeField]
  public string Sub_Event = "";

  public void On_Set_Sub_Event (string bal) {
        Sub_Event = bal;
  }

  public void On_Cli_Sub_Button_Event () {
        All_Scene_Go_Script.Ins._Button_Event_Server.On_Call_Button_Event(Event_V, this);
  }
 
}
