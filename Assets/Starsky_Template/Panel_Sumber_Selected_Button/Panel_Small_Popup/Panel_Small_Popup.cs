using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Small_Popup : MonoBehaviour {
   #region Open_Option
   // Button_Event_Servver :
    public virtual void On_Open_Option (string Name_Option) {
        if (!b_Dict_Option) {
            b_Dict_Option = true;
            On_Load_Dict_Option ();
        }
        Off_Others_Button (Name_Option);
        Dict_Option[Name_Option].SetActive (true);
        this.gameObject.transform.position = All_Scene_Go_Script.Ins._Mouse_Position_UI.On_Get_Mouse_Position ();
        this.gameObject.SetActive (true);
    }

    public virtual void Off_Open_Option () {
        this.gameObject.SetActive (false);
    }

    void Off_Others_Button (string Name_Option) {
        foreach (KeyValuePair<string, GameObject> entry in Dict_Option) {
            if (entry.Key != Name_Option) {
                entry.Value.SetActive (false);
            }
        }
    }
   #endregion

   #region Dictionary
   protected bool b_Dict_Option = false;
   protected Dictionary <string, GameObject> Dict_Option = new Dictionary<string, GameObject> ();

   public virtual void On_Load_Dict_Option () {
        // This method is meant to be overridden in derived classes
   }
   #endregion
}
