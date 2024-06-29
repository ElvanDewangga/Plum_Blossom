using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Selected_Button_Data : MonoBehaviour {
    #region Data
    public int [] A_Int;
    public string [] A_String = new string [0];
    

        #region On_Get_Data
        [SerializeField]
        string Code_Get_Data = "";
        bool b_On_Get_Data = false;
        void On_Get_Data () {
            if (All_Scene_Go_Script.Ins._Data_Slot_Canvas.Cur_Target_Slot != 0) { 
                    b_On_Get_Data = true;
                    if (Code_Get_Data != "") {
                    Plum_Blossom_Data Data = All_Scene_Go_Script.Ins._Data_Slot_Canvas.Target_Plum_Blossom_Data;
                //  Convert_A_Object_To_A_String Cs = new Convert_A_Object_To_A_String ();
                //  Fungsi_Umum Fu = new Fungsi_Umum ();
                //  string[] stringArray = Cs.ConvertObjectArrayToStringArray(Fu.On_Get_Fields (Data, Code_Get_Data));
                // A_String = stringArray;
                A_String = Data.On_Get_Data (Code_Get_Data);
                if (this.gameObject.activeInHierarchy) {
                    On_Doing_Event_1 ();
                }
                
                    }
            }
        }
        #endregion
    #endregion
    void On_Example () {
        string [] Data_String = new string [1] {
            "Housekeeping"
        };
        On_Input_Data (Data_String);
    }

    void OnEnable () {
        if (b_On_Get_Data) {
            On_Doing_Event_1 ();
        } else {
            On_Get_Data ();
        }
        
    }
    // Panel_Sumber_Selected_Button :
    public void On_Start () {
        On_Get_Data ();
    }
    // Part_Time_Job_Utama :
    public void On_Input_Data (string [] A_String_V) {
        A_String = A_String_V;
        
        On_Doing_Event_1 ();
    }

    #region Event
    public string Code_Event = "";
    
    void On_Doing_Event_1 () {
        On_Doing_Event_2 ("Button_Sprite_On_Set_Sprite");
        Selected_Button_Object_Target = 0; On_Doing_Event_2 ("Selected_Button_Object_Off_Active_Object");
    }
    void On_Doing_Event_2 (string v) {
        Code_Event = v;
        All_Scene_Go_Script.Ins._Sumber_Selected_Button.On_Doing_Event (this);
    }
    #endregion
    #region Selected_Button_Object
    public int Selected_Button_Object_Target = 0;
    #endregion
    
}
