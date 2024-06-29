using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button_Event_Server : MonoBehaviour {
    #region Sample
    [SerializeField]
    public GameObject Button_2; // Prefab
    [SerializeField]
    public GameObject Button_2_1;
    public GameObject Button_3;
    #endregion
    #region Head
    Dictionary <string, UnityAction> Dict_Unity_Action = new Dictionary<string, UnityAction> ();
    void Start () {
        Dict_Unity_Action = new Dictionary<string, UnityAction>();
        Dict_Unity_Action.Add ("New_Games", On_New_Games);
        Dict_Unity_Action.Add ("Save_Games", On_Save_Games);
        Dict_Unity_Action.Add ("Load_Games", On_Load_Games);
        Dict_Unity_Action.Add ("Settings", On_Settings);
        Dict_Unity_Action.Add ("Quit_Game", On_Quit_Game);
        Dict_Unity_Action.Add ("Awal_Confirm", On_Awal_Confirm);
        Dict_Unity_Action.Add ("Close_Notification", On_Close_Notification);
        Dict_Unity_Action.Add ("Back_Menu", On_Close_Notification);
        Dict_Unity_Action.Add ("Gender", On_New_Games_Rewrite_Form);
        Dict_Unity_Action.Add ("Name", On_New_Games_Rewrite_Form);
        Dict_Unity_Action.Add ("Birthday", On_New_Games_Rewrite_Form);
        Dict_Unity_Action.Add ("Child_Gender", On_New_Games_Rewrite_Form);
        Dict_Unity_Action.Add ("Child_Name", On_New_Games_Rewrite_Form);
        Dict_Unity_Action.Add ("Child_Birthday", On_New_Games_Rewrite_Form);
        Dict_Unity_Action.Add ("Child_Blood_Type", On_New_Games_Rewrite_Form);
        Dict_Unity_Action.Add ("New_Games_Confirmation", On_Confirm_New_Games);
        Dict_Unity_Action.Add ("Go_Home", On_Go_Home);
        Dict_Unity_Action.Add ("Continue_Save", On_Data_Save);
        Dict_Unity_Action.Add ("Continue_Load", On_Data_Load);
        Dict_Unity_Action.Add ("Visual_Novel_Option", On_Visual_Novel_Option);
        Dict_Unity_Action.Add ("Home_Bed", On_Open_Option);
        Dict_Unity_Action.Add ("Wardrobe",  On_Open_Option);
        Dict_Unity_Action.Add ("Notebook",  On_Open_Option);
        Dict_Unity_Action.Add ("Map",  On_Open_Option);
        Dict_Unity_Action.Add ("Home_Child",On_Open_Option );
        Dict_Unity_Action.Add ("Part_Time_Utama",On_Part_Time_Utama );
        Dict_Unity_Action.Add ("Class_Utama",On_Class_Utama );
        Dict_Unity_Action.Add ("Home_Profile",On_Home_Profile );
        Dict_Unity_Action.Add ("Home_Child_Chat",On_Open_Option_Small_Popup_Menu_2 ); 
        Dict_Unity_Action.Add ("Child_Chat_About_Future",On_Talk_With_Child ); 
        Dict_Unity_Action.Add ("Child_Chat_Criticize",On_Talk_With_Child ); 
        Dict_Unity_Action.Add ("Home_Child_Give_Money",On_Open_Option_Small_Popup_Menu_2 );
        Dict_Unity_Action.Add ("Child_Give_100_Coin",On_Talk_With_Child ); 
        Dict_Unity_Action.Add ("Child_Give_500_Coin",On_Talk_With_Child ); 
        Dict_Unity_Action.Add ("Child_Give_1000_Coin",On_Talk_With_Child ); 
        Dict_Unity_Action.Add ("Home_Sleep", On_Home_Sleep);
        Dict_Unity_Action.Add ("Cancel_Panel_Popup_Home", On_Cancel_Popup_Home);
        Dict_Unity_Action.Add ("Home_Go_To_World", On_Home_Go_To_World);
        Dict_Unity_Action.Add ("Town_Home", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Restaurant", On_Town_Place);
        Dict_Unity_Action.Add ("Town_City_Hall", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Park", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Beach", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Museum", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Dugeon", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Church", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Mangolia_Building", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Clothes_Store", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Weapon_Store", On_Town_Place);
        Dict_Unity_Action.Add ("Town_Hospital", On_Town_Place);
    } 
    string Event = "";
    // Button_Event :
    public void On_Call_Button_Event (string val) {
        Event = val;
        Cur_Button_Event = null;
        Dict_Unity_Action[val] ();
    }

    Button_Event Cur_Button_Event;
    public void On_Call_Button_Event (string val, Button_Event button) {
        Event = val;
        Cur_Button_Event = button;
        Dict_Unity_Action [val] ();
    }
    #endregion
    #region Unity_Event
    void On_New_Games () {
        Sample_Scene.Ins.On_New_Games ();
    }

    void On_Save_Games () {
      //  Debug.LogError ("Load Games");
        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Save (true);
    }

    void On_Load_Games () {
      //  Debug.LogError ("Load Games");
        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Load (true);
        Sample_Scene.Ins.On_Load_Games ();
    }

    void On_Settings () {
        Debug.LogError ("Settings");
        Sample_Scene.Ins.On_Settings ();
    }

    void On_Quit_Game () {
        Debug.LogError ("Quit Game");
        Sample_Scene.Ins.On_Quit_Game ();
    }

    void On_Awal_Confirm () {
        Sample_Scene.Ins.Cli_Confirm ();
    }

    void On_Close_Notification () {
        All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Set_Event (Event);
    }

    void On_New_Games_Rewrite_Form () {
        Sample_Scene.Ins.On_New_Games_Rewrite_Form (Event);
    }

    void On_Confirm_New_Games () {
        Sample_Scene.Ins.On_Confirm_New_Games ();
    }

    void On_Go_Home () {
        All_Scene_Go_Script.Ins._Scene_Load.On_Load_Scene ("Home_Scene", "Open_Home");
        
        All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,false, "Awal_Form_Show (Fs)");
        All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Set_Event ("Close_Notification");
    }

    void On_Data_Save () {
        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Data_Save ();
        All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Set_Event ("Back_Menu");
    }

    void On_Data_Load () {
        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Data_Load ();
        All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Set_Event ("Close_Notification");
    }

    void On_Visual_Novel_Option () {
        Visual_Novel_System.Ins._Visual_Novel_Option.On_Answer_Option (Cur_Button_Event.gameObject.GetComponent<Button_Sub_Event> ().Sub_Event);
    }
    
    void On_Open_Option () {
        On_Cancel_Popup_Home ();
        Home_Scene.Ins._Panel_Small_Popup.On_Open_Option (Event);
    }

    void On_Open_Option_Small_Popup_Menu_2 () {
        On_Cancel_Popup_Home ();
        Home_Scene.Ins._Small_Popup_Menu_2.On_Open_Option (Event);
    }

    void On_Talk_With_Child () {
        On_Cancel_Popup_Home ();
        Home_Scene.Ins._Home_Child_Interact.On_Interact (Event);
    }

    void On_Part_Time_Utama () {
        Home_Scene.Ins._Part_Time_Job_Utama.On_Open ();
        On_Cancel_Popup_Home ();
        Home_Scene.Ins._Part_Time_Job_Utama.Part_Time_Menu_But.On_Cli ();
        
    }

    void On_Class_Utama () {
        Home_Scene.Ins._Part_Time_Job_Utama.On_Open ();
        On_Cancel_Popup_Home ();
        Home_Scene.Ins._Part_Time_Job_Utama.Plan_Class_Menu_But.On_Cli ();
        
        
    }

    void On_Home_Profile () {
        Home_Scene.Ins._Profile.On_Open ();
    }

    void On_Cancel_Popup_Home () {
        Home_Scene.Ins._Panel_Small_Popup.Off_Open_Option ();
        Home_Scene.Ins._Small_Popup_Menu_2.Off_Open_Option ();
    }

    void On_Home_Go_To_World () {
         On_Cancel_Popup_Home ();
         
        Home_Scene.Ins.Animator_UI_Zoom_In_1.SetTrigger ("UI_Zoom_In");
        Loading.Ins.On_White_Fade (2.0f);
        Loading.Ins.On_Loading_Animation_Event (On_Home_Go_To_World_2, 1.5f);
    }

    // Loading :
    public void On_Home_Go_To_World_2 () {
        World_Scene.Ins._Scene_Activity.On_Masuk_Scene ("Home_Scene");
    }

    void On_Town_Place () {
        World_Scene.Ins._World_Canvas.On_Town_Place (Event);
    }
    
    void On_Home_Sleep () {
        On_Cancel_Popup_Home ();
        Home_Scene.Ins._Kegiatan_Home.On_Doing_Sleep ();
    }
    #endregion
}
