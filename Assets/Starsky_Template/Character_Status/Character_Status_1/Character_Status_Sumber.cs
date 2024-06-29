using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character_Status_Sumber : Custom_Initialization {
   [SerializeField]
   GameObject _Character_Status_1_Sample;

   [SerializeField]
   List <Character_Status_1> L_Player_Character_Status_1 = new List<Character_Status_1> ();

   [SerializeField]
   List <Character_Status_1> L_Enemy_Character_Status_1 = new List<Character_Status_1> ();

    // Data_Slot_System , TMP_Text_Pengubah_Text_Sumber :
   public List <Character_Status_1> On_Get_L_Player_Character_Status_1 () {
    return L_Player_Character_Status_1;
   } 
   #region InitializationManager
    
    public override void CustomStart () {
        base.CustomStart ();
        // Player :
        if (All_Scene_Go_Script.Ins._Data_Slot_Canvas.Cur_Target_Slot == 0) { // New Games
            GameObject Ins = GameObject.Instantiate (_Character_Status_1_Sample);
            Ins.transform.SetParent (this.transform);
            Character_Status_1 Cs = Ins.GetComponent<Character_Status_1> ();
    

            List <Form_Show.Form_Id> L_Form_Show = new List<Form_Show.Form_Id> ();
            L_Form_Show = All_Scene_Go_Script.Ins._Form_Show.On_Get_L_Form_Id ();

          

            Cs.On_Set_Field ("Max_Hp",20);
            Cs.On_Set_Field ("Cur_Hp", 20);

            Cs.On_Set_Field ("Max_Mp",20);
            Cs.On_Set_Field ("Cur_Mp", 20);

            Cs.On_Set_Field ("Max_Stress",100);
            Cs.On_Set_Field ("Cur_Stress", 0);

            Cs.On_Set_Field ("Gender", L_Form_Show[0]._Form_String.Isi);
            Cs.On_Set_Field ("Name", L_Form_Show[1]._Form_String.Isi);

            Convert_Local_Month Cm = new Convert_Local_Month ();
            Cm.On_Get_Month_Day (L_Form_Show[2]._Form_String.Isi, out string month, out int day);

            Cs.On_Set_Field ("Birthday_Month", month);
            Cs.On_Set_Field ("Birthday_Day", day);

            Cs.On_Set_Field ("Child_Age", 5);
            
            Cs.On_Set_Field ("Child_Gender", L_Form_Show[3]._Form_String.Isi);
            Cs.On_Set_Field ("Child_Name", L_Form_Show[4]._Form_String.Isi);

            Cm.On_Get_Month_Day (L_Form_Show[5]._Form_String.Isi, out string child_month, out int child_day);
            Cs.On_Set_Field ("Child_Birthday_Month", child_month);
            Cs.On_Set_Field ("Child_Birthday_Day", child_day);

            Cs.On_Set_Field ("Child_Blood_Type", L_Form_Show[6]._Form_String.Isi);

            L_Player_Character_Status_1.Add (Cs);

            // Status Universal :
            _Status_Universal.Day = 1;
            _Status_Universal.Month = 1;
            _Status_Universal.Year = 2232;

            _Status_Universal.Coin = 10000;
            Convert_Season Cv = new Convert_Season ();
            _Status_Universal.Season = Cv.GetSeason (_Status_Universal.Day, _Status_Universal.Month);
            _Status_Universal.Hari = "Sunday";

           
            Home_Scene.Ins._Header_Canvas.On_Finish_Load ();
            On_Check_First_Home ();
            Cs.Get_Data_On_Add_Dict_Object ();
            Get_Data_On_Add_Dict_Object ();
            Set_Data_On_Add_Dict_Object ();
            All_Scene_Go_Script.Ins._Local_Calendar.On_Get_Calendar_Data (_Status_Universal);
            Home_Scene.Ins._Part_Time_Job_Utama._Panel_Sumber_Selected_Button_Plan_Day.On_Start_Selected_Button_Data ();
        } else { // Load Games

        }
    }
    
 
   #endregion
   #region Status_Universal
    [System.Serializable]
    public class Status_Universal {
        public int Day;
        public int Month;
        public int Year;
        public string Season; // "Spring", "Summer", "Autumn", "Winter"
        public string Hari;

        public int First_Home;
        public int Coin;
    }
    // Data_Slot_Sytem :
    public Status_Universal _Status_Universal = new Status_Universal ();
    #region Local_Calendar
    // Local_Calendar :
    public void On_Get_Local_Calendar (int Day, int Month, int Year, string Hari) {
        _Status_Universal.Day = Day;
        _Status_Universal.Month = Month;
        _Status_Universal.Year = Year;
        _Status_Universal.Hari = Hari; 
    }
    #endregion
   #endregion
   #region Data_Load
   
   // Data_Slot_Canvas :
    public void On_Get_Status_Universal (Status_Universal St) {
        _Status_Universal = St;
        Home_Scene.Ins._Header_Canvas.On_Call_Set_Star_GameObject ("Coin", new object [] {_Status_Universal.Coin.ToString ()});
        Home_Scene.Ins._Header_Canvas.On_Finish_Load ();
        On_Check_First_Home ();
        Get_Data_On_Add_Dict_Object ();
        Set_Data_On_Add_Dict_Object ();
        All_Scene_Go_Script.Ins._Local_Calendar.On_Get_Calendar_Data (_Status_Universal);
        Home_Scene.Ins._Part_Time_Job_Utama._Panel_Sumber_Selected_Button_Plan_Day.On_Start_Selected_Button_Data ();
    }

    // Data_Slot_Canvas :
    public void On_Get_Character_Status_1 (Plum_Blossom_Data Pbd) {
        GameObject Ins = GameObject.Instantiate (_Character_Status_1_Sample);
        Ins.transform.SetParent (this.transform);
        Character_Status_1 Cs = Ins.GetComponent<Character_Status_1> ();
        Pbd.On_Convert_Data_To_Character_Status_1 (Pbd,Cs);

        L_Player_Character_Status_1.Add (Cs);
        
        All_Scene_Go_Script.Ins._Pengubah_String._TMP_Text_Pengubah_Text_Sumber.On_Add_Dict_From_Home_Scene ();

        Home_Scene.Ins._Header_Canvas.On_Call_Set_Star_GameObject ("Mp", new object [] {L_Player_Character_Status_1[0].Cur_Mp, L_Player_Character_Status_1[0].Max_Mp});
        Home_Scene.Ins._Header_Canvas.On_Call_Set_Star_GameObject ("Hp", new object [] {L_Player_Character_Status_1[0].Cur_Hp, L_Player_Character_Status_1[0].Max_Hp});
        Home_Scene.Ins._Header_Canvas.On_Call_Set_Star_GameObject ("Cur_Stress", new object [] {L_Player_Character_Status_1[0].Cur_Stress, L_Player_Character_Status_1[0].Max_Stress});

        Cs.Get_Data_On_Add_Dict_Object ();
    }
   #endregion 
   #region Visual_Novel_System 
    void On_Check_First_Home () {
       Visual_Novel_System.Ins.On_Start_Visual_Novel ("Visual_Novel_Res/Opening_Act", "Visual_Novel_Kalimat");
    }
   #endregion 
   #region Get_Data
    // this :
    void Get_Data_On_Add_Dict_Object () {
        Get_Data.Ins.On_Add_Dict_Object ("Coin", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Coin", typeof(Character_Status_Sumber.Status_Universal));
    } 

    #endregion
    #region Set_Data
    // this :
    void Set_Data_On_Add_Dict_Object () {
        Set_Data.Ins.On_Add_Dict_UnityAction ("Coin", On_Refresh_Set_Data_Coin);
        Set_Data.Ins.On_Add_Dict_UnityAction ("Cur_Stress", On_Refresh_Set_Data_Stress);
    } 

    public void On_Refresh_Set_Data_Coin () {
        Home_Scene.Ins._Header_Canvas.On_Call_Set_Star_GameObject ("Coin", new object [] {Home_Scene.Ins._Character_Status_Sumber._Status_Universal.Coin.ToString ()});

    }

    public void On_Refresh_Set_Data_Stress () {
        Home_Scene.Ins._Header_Canvas.On_Call_Set_Star_GameObject ("Cur_Stress", new object [] {Home_Scene.Ins._Character_Status_Sumber.L_Player_Character_Status_1[0].Cur_Stress, Home_Scene.Ins._Character_Status_Sumber.L_Player_Character_Status_1[0].Max_Stress});

    }
    #endregion
}
