using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_Time_Job_Utama : Panel_Model_1_Utama {
     [SerializeField]
    Transform Layout_Close_Button;

    public override void On_Open () {
         base.On_Open ();
        
        Part_Time_Job_Selected_Button = null;

         All_Scene_Go_Script.Ins._Popup_Type._Close_Button.On_Active_Close_Button (Layout_Close_Button);

            Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
            Km.Code_Menu = "Part_Time_Job_Utama"; Km.Object_Menu = 0;

            All_Scene_Go_Script.Ins._Back_Menu.On_Add_Menu (Km);

             Part_Time_Menu_But.Off_Select (); Plan_Class_Menu_But.Off_Select ();
             On_Clear_Plan (false);
    }

    public override void Off_Open () {
        base.Off_Open ();
    }
    #region Table_Menu
    [SerializeField]
    Panel_Sumber_Selected_Button _Panel_Sumber_Selected_Button_Table_Menu;
    // Button_Event_Server:
    public Selected_Button Part_Time_Menu_But;
    public Selected_Button Plan_Class_Menu_But;
    
    [SerializeField]
    Transform [] A_Table_Note_Part_Time_Job;
    [SerializeField]
    Transform [] A_Table_Note_Plan_Class;
    string Menu = "";
    // Sumber_Selected_Button :
    public void On_Table_Menu (string Menu_V) {
        Menu = Menu_V;
        On_Clear_Plan (false);
        Off_All_Table_Menu ();
        if (Menu == "Note_Part_Time_Job") {
           // Debug.LogError ("Part Time");
            A_Table_Note_Part_Time_Job[0].gameObject.SetActive (true);
        } else if (Menu == "Note_Plan_Class") {
           // Debug.LogError ("Plan class");
            A_Table_Note_Plan_Class [0].gameObject.SetActive (true);
        }
        On_Refresh_Clear_Tab ();
    }
    
    void Off_All_Table_Menu () {
        foreach (Transform s in A_Table_Note_Part_Time_Job) {
            s.gameObject.SetActive (false);
        }

        foreach (Transform s in A_Table_Note_Plan_Class) {
            s.gameObject.SetActive (false);
        }
    }
    #endregion
    #region Result_Tab
    [SerializeField]
    Panel_Sumber_Selected_Button _Panel_Sumber_Selected_Result_Option;
    [SerializeField]
    Selected_Button Selected_Button_Clear_Schedule, Selected_Button_Clear_Job;
    [SerializeField]
    Form_1 _Form_1_Weekly_Income;

    void On_Refresh_Clear_Tab () {
        
        
        _Panel_Sumber_Selected_Result_Option.On_Refresh_All_Off_Select ();
        Selected_Button_Clear_Schedule.gameObject.SetActive (false); Selected_Button_Clear_Job.gameObject.SetActive (false);
        if (Menu == "Note_Part_Time_Job") {
            
            Selected_Button_Clear_Job.gameObject.SetActive (true);
        } else if (Menu == "Note_Plan_Class") {
            
            Selected_Button_Clear_Schedule.gameObject.SetActive (true);
        }
    }

    bool b_Clear_Plan = false;
    // this, Sumber_Selected_Button :
    public void On_Clear_Plan (bool b_Clear) {
        if (b_Clear) {
            if (Menu == "Note_Part_Time_Job") {
                _Panel_Sumber_Selected_Button_Plan_Part_Time_Job.On_Refresh_All_Off_Select ();
            } else if (Menu == "Note_Plan_Class") { 
                _Panel_Sumber_Selected_Button_Plan_Class.On_Refresh_All_Off_Select ();
            }
            _Panel_Sumber_Selected_Button_Plan_Day.On_Refresh_All_Off_Select ();
        }
        b_Clear_Plan = b_Clear;
    }
    #endregion
    #region Selected_Button
        #region Part_Time_Job
        [SerializeField]
        Panel_Sumber_Selected_Button _Panel_Sumber_Selected_Button_Plan_Part_Time_Job;
        Selected_Button Part_Time_Job_Selected_Button;
        // Sumber_Selected_Button :
        public void On_Get_Selected_Button_Part_Time_Job (Selected_Button Sb) {
            On_Clear_Plan (false);
            On_Refresh_Clear_Tab ();
            _Panel_Sumber_Selected_Button_Plan_Day.On_Refresh_All_Off_Select ();
            Part_Time_Job_Selected_Button = Sb;
        }
        #endregion
        #region Plan_Class
        [SerializeField]
        Panel_Sumber_Selected_Button _Panel_Sumber_Selected_Button_Plan_Class;
        Selected_Button Plan_Class_Selected_Button;
        // Sumber_Selected_Button :
        public void On_Get_Selected_Button_Plan_Class (Selected_Button Sb) {
            
            On_Clear_Plan (false);
            On_Refresh_Clear_Tab ();
            _Panel_Sumber_Selected_Button_Plan_Day.On_Refresh_All_Off_Select ();
            Plan_Class_Selected_Button = Sb;
        }
        #endregion
        #region Plan_Day
        [SerializeField]
        public Panel_Sumber_Selected_Button _Panel_Sumber_Selected_Button_Plan_Day;
        Selected_Button Plan_Day_Selected_Button;
        // Sumber_Selected_Button :
        public void On_Get_Selected_Button_Plan_Day (Selected_Button Sb) {
            Plan_Day_Selected_Button = Sb;
            if (!b_Clear_Plan) {
                if (Part_Time_Job_Selected_Button != null) {
                    string [] Data_String = new string [1] {
                        Part_Time_Job_Selected_Button.gameObject.GetComponent <Part_Time_Job>().Title
                    };
                    Sb.gameObject.GetComponent <Selected_Button_Data> ().On_Input_Data (Data_String);
                } else if (Plan_Class_Selected_Button != null) {
                    string [] Data_String = new string [1] {
                        Plan_Class_Selected_Button.gameObject.GetComponent <Plan_Class>().Title
                    };
                    Sb.gameObject.GetComponent <Selected_Button_Data> ().On_Input_Data (Data_String);
                }
            } else {
                // Debug.Log ("Hari ini kegiatannya di hapus");
                string [] A_String = Sb.gameObject.GetComponent <Selected_Button_Data> ().A_String;
                if (Menu == "Note_Part_Time_Job") {
                    if (A_String.Length > 0) {
                        if (On_Get_Type_Plan (A_String[0]) == "Part_Time_Job") {
                            On_Doing_Clear ();
                        }
                    }
                } else if (Menu == "Note_Plan_Class") { 
                    if (A_String.Length > 0) {
                        if (On_Get_Type_Plan (A_String[0]) == "Class") {
                            On_Doing_Clear ();
                        }
                    }
                }
            }
        }

        void On_Doing_Clear () {
            string [] Data_String = new string [0];
            Plan_Day_Selected_Button.gameObject.GetComponent <Selected_Button_Data> ().On_Input_Data (Data_String);
        }
        // Plum_Blossom_Data, Kegiatan_Home :
        public Selected_Button_Data [] A_Plan_Day = new Selected_Button_Data[0];

        #endregion


     #endregion
     #region Dict_Type_Plan
      bool b_Dict_Type_Plan =false;
    Dictionary <string, string> Dict_Type_Plan = new Dictionary<string, string> ();

    void On_Load_Dict_Type_Plan () {
        Dict_Type_Plan = new Dictionary<string, string> ();
        Dict_Type_Plan.Add ("Housekeeping","Part_Time_Job");
        Dict_Type_Plan.Add ("Babysitting","Part_Time_Job");
        Dict_Type_Plan.Add ("Tutoring","Part_Time_Job");
        Dict_Type_Plan.Add ("Singer","Part_Time_Job");
        Dict_Type_Plan.Add ("Pickpocket","Part_Time_Job");
        Dict_Type_Plan.Add ("Porter","Part_Time_Job");

        Dict_Type_Plan.Add ("Reading", "Class");

        Dict_Type_Plan.Add ("Arithmetic", "Class");
        Dict_Type_Plan.Add ("Literature", "Class");
        Dict_Type_Plan.Add ("PE", "Class");
        Dict_Type_Plan.Add ("Sport_Club", "Class");
        Dict_Type_Plan.Add ("Tech_Club", "Class");
        Dict_Type_Plan.Add ("Music_Club", "Class");
        
        Dict_Type_Plan.Add ("Taming_Class", "Class");
        Dict_Type_Plan.Add ("Apothecary_Class", "Class");
        Dict_Type_Plan.Add ("Crafting_Class", "Class");
        Dict_Type_Plan.Add ("Magic_Class", "Class");
        Dict_Type_Plan.Add ("Combat_Class", "Class");

        Dict_Type_Plan.Add ("Advanced_Apothecary_Class", "Class");
        Dict_Type_Plan.Add ("Advanced_Crafting_Class", "Class");
        Dict_Type_Plan.Add ("Advanced_Magic_Class", "Class");
        Dict_Type_Plan.Add ("Advanced_Combat_Class", "Class");
    }

    // Kegitatan_Home :
    public string On_Get_Type_Plan (string Name) {
        if (!b_Dict_Type_Plan) {
            b_Dict_Type_Plan = true;
            On_Load_Dict_Type_Plan ();
        }
       return Dict_Type_Plan[Name];
    }

     #endregion
     #region Panel_Model_1_Data
     [SerializeField]
        List <Panel_Model_1_Data> L_Panel_Model_1_Data = new List <Panel_Model_1_Data> ();
        // Panel_Model_1_Data :
        public void On_Add_Panel_Model_1_Data (Panel_Model_1_Data s) {
            L_Panel_Model_1_Data.Add (s);
        }

        public Panel_Model_1_Data On_Get_Panel_Model_1_Data_From_Name (string s) {
            Panel_Model_1_Data Pd = new Panel_Model_1_Data ();
            foreach (Panel_Model_1_Data target in L_Panel_Model_1_Data) {
                if (target.Title == s) {
                    Pd = target;
                }
            }
            return Pd;
        }
    #endregion
}
