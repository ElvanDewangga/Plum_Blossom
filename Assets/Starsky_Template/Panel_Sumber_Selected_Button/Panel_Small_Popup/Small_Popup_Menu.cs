using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_Popup_Menu : Panel_Small_Popup {
   #region Open_Option
   // Button_Event_Servver :
    public override void On_Open_Option (string Name_Option) {
        base.On_Open_Option(Name_Option);
    }

    public override void Off_Open_Option () {
        base.Off_Open_Option ();
    }
   #endregion
   #region Dictionary
    [SerializeField]
    GameObject [] A_Option_Go;

    public override void On_Load_Dict_Option () {
        Dict_Option = new Dictionary<string, GameObject> ();
        Dict_Option.Add ("Home_Bed", A_Option_Go[0]);
        Dict_Option.Add ("Wardrobe", A_Option_Go[1]);
        Dict_Option.Add ("Notebook", A_Option_Go[2]);
        Dict_Option.Add ("Map", A_Option_Go[3]);
        Dict_Option.Add ("Home_Child", A_Option_Go [4]);
        
    }
   #endregion
}
