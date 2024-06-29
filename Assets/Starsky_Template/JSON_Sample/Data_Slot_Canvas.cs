using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
using System;
public class Data_Slot_Canvas : MonoBehaviour {
    [Header ("Options :")]
    [SerializeField]
    int Maximum_Slot = 5;
    [SerializeField]
    Transform Layout_Data_Slot;
    [Tooltip ("Object")]
    [SerializeField]
    GameObject Data_Slot_System_Sample;
    [SerializeField]
    GameObject Load_Data_Viewport;
    // Start is called before the first frame update
    void On_Start() {
       Star_GameObject St = new Star_GameObject();
       int i = 0;
       for (i = 0; i < Maximum_Slot; i ++) {
            St.On_Instantiate (Data_Slot_System_Sample,Layout_Data_Slot, true);       
            St.On_Input_Method ("Data_Slot_System","On_Check_Cur_Slot",new Type[] { typeof(int)}, new object[] {(i + 1)});
            St.On_Input_Method ("Clone_Sample","On_Set_b_Clone",new Type[] { typeof(bool)}, new object[] {true});
       } 
       Load_Data_Viewport.GetComponent <Scroll_Rect_Position> ().ScrollToTopPosition ();
    }

    #region Active
    string Code_Active = ""; // "Load" / "Save"
    // Button_Event_Server :
    public void On_Active (string Code_Active_V) {
       // Debug.Log (Code_Active_V);
        Cur_Target_Slot =0;
        Layout_Data_Slot.gameObject.GetComponent <Panel_Destroyer> ().On_Destroy_All_Clone ();
        All_Scene_Go_Script.Ins._Popup_Type._Close_Button.On_Active_Close_Button (Panel_Layout_Close_Button);
        Code_Active = Code_Active_V;
        this.gameObject.SetActive (true);
        On_Start ();
    }

    void Off_Active () {
        All_Scene_Go_Script.Ins._Popup_Type._Close_Button.Off_Active_Close_Button ();
        Code_Active = "";
        
        _Data_Slot_System = null; // Target_Plum_Blossom_Data = null;
        this.gameObject.SetActive (false);
    }
    #endregion

    #region Data_Load
    // Character_Status_Sumber :
    public int Cur_Target_Slot = 0;
    // Selected_Button_Data :
    [HideInInspector]
    public Plum_Blossom_Data Target_Plum_Blossom_Data;
    Data_Slot_System _Data_Slot_System;
    public void On_Load (bool Back_Menu_V) {
        On_Active ("Load");
        if (Back_Menu_V) {
            Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
            Km.Code_Menu = "Data_Slot_Canvas"; Km.Object_Menu = "On_Load";
            
            All_Scene_Go_Script.Ins._Back_Menu.On_Add_Menu (Km);
        }
    }

    public void Off_Load (bool Back_Menu_V) {
        Off_Active();
        if (Back_Menu_V) {
            Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
            Km.Code_Menu = "Data_Slot_Canvas"; Km.Object_Menu = "On_Load";

            All_Scene_Go_Script.Ins._Back_Menu.On_Remove_Menu (Km);
        }
    }

    public void On_Data_Load () {
        All_Scene_Go_Script.Ins._Scene_Load.On_Load_Scene ("Home_Scene", "Load_Data");
        
    }

    // this - Scene_Load :
    public void On_Data_Load_2 () {
        Target_Plum_Blossom_Data = new Plum_Blossom_Data ();
        Target_Plum_Blossom_Data = Target_Plum_Blossom_Data.On_Load (Cur_Target_Slot);
        Home_Scene.Ins._Character_Status_Sumber.On_Get_Character_Status_1 (Target_Plum_Blossom_Data);
        Home_Scene.Ins._Character_Status_Sumber.On_Get_Status_Universal (Target_Plum_Blossom_Data.On_Convert_Data_To_Status_Universal (Target_Plum_Blossom_Data));
    }

    #endregion
    #region Data_Save
        #region Call
        // Attach To Button (Test) / Button_Event_Server :
        public void On_Save (bool Back_Menu_V) {
            On_Active ("Save");

            if (Back_Menu_V) {
                Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
                Km.Code_Menu = "Data_Slot_Canvas"; Km.Object_Menu = "On_Save";

                All_Scene_Go_Script.Ins._Back_Menu.On_Add_Menu (Km);
            }
        }

        void Off_Save (bool Back_Menu_V) {
            if (Back_Menu_V) {
                Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
                Km.Code_Menu = "Data_Slot_Canvas"; Km.Object_Menu = "On_Save";

                All_Scene_Go_Script.Ins._Back_Menu.On_Remove_Menu (Km);
            }
            Off_Active ();
        }
        #endregion
        // Button_Event_Server :
        public void On_Data_Save () {
          //  Debug.LogError ("Saving");
            Plum_Blossom_Data Ps = new Plum_Blossom_Data ();
            Ps.On_Save (Cur_Target_Slot, Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0]);
        }

    #endregion
    #region Data_Slot_System
    public void On_Data_Slot_System (int Cur_Slot, Data_Slot_System Ds) {
        Cur_Target_Slot = Cur_Slot;
        _Data_Slot_System = Ds;
        if (Code_Active == "Save") {
            string [] A_Title = new string[2];
            A_Title[0] = "Yes"; A_Title [1] = "No";
            string [] A_Event = new string[2];
            A_Event[0] = "Continue_Save"; A_Event[1] = "Back_Menu";
            
            Off_Save (false);
            All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Notification ("Notification", "Notification_1_1", "Do you want save this data to this slot ?", A_Title, A_Event);
            
        } else if (Code_Active == "Load") {
           string [] A_Title = new string[2];
            A_Title[0] = "Yes"; A_Title [1] = "No";
            string [] A_Event = new string[2];
            A_Event[0] = "Continue_Load"; A_Event[1] = "Back_Menu";
            
            Off_Load (false);
            All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Notification ("Notification", "Notification_1_1", "Do you want load this data ?", A_Title, A_Event); 
        }
    }
    #endregion
    #region Close_Button
    [SerializeField]
    Transform Panel_Layout_Close_Button;
    #endregion
}
