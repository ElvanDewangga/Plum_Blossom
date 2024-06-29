using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Small_Popup_Menu_2 : Panel_Small_Popup {
    #region Open_Option
    [SerializeField]
    Image Bg_Small_Popup;
   // Button_Event_Servver :
    public override void On_Open_Option (string Name_Option) {
        Home_Scene.Ins._Home_Child_Interact.On_Check_Object_Requirements ();
        Bg_Small_Popup.gameObject.SetActive (true);
        base.On_Open_Option(Name_Option);
    }

    public override void Off_Open_Option () {
        Bg_Small_Popup.gameObject.SetActive (false);
        base.Off_Open_Option ();
    }
   #endregion
   #region Dictionary
    [SerializeField]
    GameObject [] A_Option_Go;
    
    public override void On_Load_Dict_Option () {
        Dict_Option = new Dictionary<string, GameObject> ();
        Dict_Option.Add ("Home_Child_Chat", A_Option_Go[0]);
        Dict_Option.Add ("Home_Child_Give_Money", A_Option_Go[1]);
        
    }
   #endregion
}
