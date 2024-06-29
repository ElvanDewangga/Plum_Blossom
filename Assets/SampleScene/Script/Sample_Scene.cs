using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Sample_Scene : MonoBehaviour {
  public static Sample_Scene Ins;
   void Awake () {
    Ins = this;
   }

   void Start () {
      All_Scene_Go_Script.Ins.On_Active_Scene (All_Scene_Go_Script.Active_Scene.Sample_Scene);
   }
   
    [SerializeField]
   GameObject Tab_Tombol_Awal;
    [SerializeField]
    TMP_Text Title_Name_Tx, Title_Birthday_Tx, Title_Gender_Tx;
    [SerializeField]
    TMP_Text Logo_Name_Tx, Logo_Birthday_Tx;
    [SerializeField]
    Panel_Sumber_Selected_Button _Panel_Sumber_Selected_Day, _Panel_Sumber_Selected_Month, _Panel_Sumber_Selected_Blood_Type, _Panel_Sumber_Selected_Gender;
    [SerializeField]
    Panel_Form_Show _Panel_Form_Show_You, _Panel_Form_Show_Child;
   #region New_Games
    string Code_New_Games = "";
    [SerializeField]
    TMP_InputField Nem_Games_Name_IF;
    [SerializeField]
    Bg_Result_Text Bg_Result_Text_Birthday;
    [SerializeField]
    Input_Field_Umum Name_IF;
    [SerializeField]
    public void On_New_Games () {
      All_Scene_Go_Script.Ins._Form_Show.On_Refresh_Form ();
      Fungsi_Umum Fs = new Fungsi_Umum ();
      Fs.On_Set_Active (Tab_Tombol_Awal, false);
      Code_New_Games = "Enter your gender (Fs)";
      Function_New_Games (false);
      //Title_Gender_Tx.text = "Enter your gender";
      //All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,true, "Enter your gender (Fs)");
      
    }

    // Sumber_Selected_Button :
    string Month, Day;
    string Blood_Type;
    string Gender;
    public void On_Get_Input (Selected_Button S) {
      
      if (Code_New_Games == "Enter your birthday (Fs)" || Code_New_Games == "Enter your child birthday (Fs)") {
        if (S.Event == "Choose_Month") {
          Convert_Local_Month Cv = new Convert_Local_Month ();
          Month = Cv.On_Get_Month_Name (S.A_Int[0]);
          _Panel_Sumber_Selected_Day.On_Check_All_Selected_Button (0, Cv.On_Get_Total_Day (S.A_Int[0])+1);
        } else if (S.Event == "Choose_Day") {
          Day = S.A_Int[0].ToString ();
        }
        Bg_Result_Text_Birthday._Tmp_Text.text = Month + ", " + Day;
      } else if (Code_New_Games == "Enter your child blood type (Fs)") {
        Blood_Type = S.A_String[0];
      } else if (Code_New_Games == "Enter your gender (Fs)" || Code_New_Games == "Enter your child gender (Fs)") {
        Gender = S.A_String[0];
      }
    }

    // Button_Event_Server :
    public void Cli_Confirm () {
      if (Code_New_Games == "Enter your gender (Fs)") {
        All_Scene_Go_Script.Ins._Form_Show.On_Add_Form_String ("Gender", Gender);
        
        _Panel_Sumber_Selected_Gender.On_Refresh_Default_Select ();
        Code_New_Games = "Enter your name (Fs)";
        Function_New_Games (false);
        
      }
      else if (Code_New_Games == "Enter your name (Fs)") { 
        
        
       // Debug.LogError ("S");
        if (Name_IF.b_Check_Requirements ()) {
          All_Scene_Go_Script.Ins._Form_Show.On_Add_Form_String ("Name", Nem_Games_Name_IF.text);

          Code_New_Games = "Enter your birthday (Fs)";
          Function_New_Games (false);
        } else {
          string [] A_Title = new string[1];
          A_Title[0] = "Confirm";
          string [] A_Event = new string[1];
          A_Event[0] = "Close_Notification";
          All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Notification ("Notification","Notification_1_1", "Please write your child name correctly with 4 letters or more.", A_Title, A_Event);
        }
      } else if (Code_New_Games == "Enter your birthday (Fs)") {
        All_Scene_Go_Script.Ins._Form_Show.On_Add_Form_String ("Birthday", Bg_Result_Text_Birthday._Tmp_Text.text);
        _Panel_Sumber_Selected_Day.On_Refresh_Default_Select (); _Panel_Sumber_Selected_Month.On_Refresh_Default_Select ();
        Bg_Result_Text_Birthday.gameObject.SetActive (false);

        
        Code_New_Games = "Enter your child gender (Fs)";
        _Panel_Sumber_Selected_Gender.On_Refresh_Default_Select ();
        Function_New_Games (false);
        
      }else if (Code_New_Games == "Enter your child gender (Fs)") {
        All_Scene_Go_Script.Ins._Form_Show.On_Add_Form_String ("Child_Gender", Gender);
       // Debug.LogError ("S"); 
        Code_New_Games = "Enter your child name (Fs)";
        Function_New_Games (false);
       
      }else if (Code_New_Games == "Enter your child name (Fs)") {
        
       // Debug.LogError ("S");
       if (Name_IF.b_Check_Requirements ()) {
          All_Scene_Go_Script.Ins._Form_Show.On_Add_Form_String ("Child_Name", Nem_Games_Name_IF.text);
          
          Code_New_Games = "Enter your child birthday (Fs)";
          Function_New_Games (false);
       } else {
          string [] A_Title = new string[1];
          A_Title[0] = "Confirm";
          string [] A_Event = new string[1];
          A_Event[0] = "Close_Notification";
          All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Notification ("Notification","Notification_1_1", "Please write your child name correctly with 4 letters or more.", A_Title, A_Event);
       }
        
      } else if (Code_New_Games == "Enter your child birthday (Fs)") {
        All_Scene_Go_Script.Ins._Form_Show.On_Add_Form_String ("Child_Birthday", Bg_Result_Text_Birthday._Tmp_Text.text);
       // Debug.LogError ("S");
       _Panel_Sumber_Selected_Day.On_Refresh_Default_Select (); _Panel_Sumber_Selected_Month.On_Refresh_Default_Select ();
       
        Code_New_Games = "Enter your child blood type (Fs)";
        Function_New_Games (false);
      } else if (Code_New_Games == "Enter your child blood type (Fs)") {
        All_Scene_Go_Script.Ins._Form_Show.On_Add_Form_String ("Child_Blood_Type", Blood_Type);
        
        Code_New_Games = "Form_Show";
        Function_New_Games (true);

        //b_New_Games_Rewrite = true;
      }
      Name_IF.On_Refresh_Input_Field ();
      
    }
    
    void Function_New_Games (bool Rewrite) {
      if (!b_New_Games_Rewrite || Rewrite ) {
          if (Code_New_Games == "Enter your gender (Fs)") { 
            
            Title_Gender_Tx.text = "Enter your gender";
          All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,true, "Enter your gender (Fs)");
          
          
          }
          else if (Code_New_Games == "Enter your name (Fs)") { 
            
            
            Logo_Name_Tx.text = "Icon Caretaker.png"; Logo_Birthday_Tx.text = "Icon Caretaker.png";
            Title_Name_Tx.text = "Enter your name";
            
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your gender (Fs)");
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,true, "Enter your name (Fs)");

          } else if (Code_New_Games == "Enter your birthday (Fs)") {
            
            Title_Birthday_Tx.text = "Enter your birthday";
              Name_IF.On_Refresh_Input_Field ();
              All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your name (Fs)");
              All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,true, "Enter your birthday (Fs)");
              Bg_Result_Text_Birthday.gameObject.SetActive (true);
            
            
          }else if (Code_New_Games == "Enter your child gender (Fs)") {
            

            Code_New_Games = "Enter your child gender (Fs)";
            Title_Gender_Tx.text = "Enter your child gender";
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,false, "Enter your birthday (Fs)"); 
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,true, "Enter your gender (Fs)");
            
          
          }else if (Code_New_Games == "Enter your child name (Fs)") {
            
            Title_Name_Tx.text = "Enter your child name";
            
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your gender (Fs)");
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,true, "Enter your name (Fs)");
            
            
          } else if (Code_New_Games == "Enter your child birthday (Fs)") {
            
            Title_Birthday_Tx.text = "Enter your child birthday";
              All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your name (Fs)");
              All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,true, "Enter your birthday (Fs)"); 
              Bg_Result_Text_Birthday.gameObject.SetActive (true);

          } else if (Code_New_Games == "Enter your child blood type (Fs)") {
            
            Title_Name_Tx.text = "Enter your child blood type";
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,false, "Enter your birthday (Fs)"); 
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,true, "Enter your child blood type (Fs)");
            Bg_Result_Text_Birthday.gameObject.SetActive (false);
            

            
          } else if (Code_New_Games == "Form_Show") {
            b_New_Games_Rewrite = true;
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your child blood type (Fs)");
            All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,true, "Awal_Form_Show (Fs)");
            
            All_Scene_Go_Script.Ins._Form_Show.On_Show_The_Form (_Panel_Form_Show_You,"Form_1",0,2);
            All_Scene_Go_Script.Ins._Form_Show.On_Show_The_Form (_Panel_Form_Show_Child,"Form_1",3,6);
        }
      } else {
        Close_All_New_Games_Tab ();
        if (Code_New_Games != "Form_Show") {
          Code_New_Games = "Form_Show";
          Function_New_Games (true);
        }
      }

      
    }

    void Close_All_New_Games_Tab () {
      All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your gender (Fs)");
      All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your name (Fs)");
      All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,false, "Enter your birthday (Fs)");
      All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (0,false, "Enter your child blood type (Fs)"); 

    }

    
    bool b_New_Games_Rewrite = false;
    // Button_Event_Server :
    public void On_New_Games_Rewrite_Form (string Val) {
      All_Scene_Go_Script.Ins._Popup_Type.Set_Popup_Tab (1,false, "Awal_Form_Show (Fs)");
        
      All_Scene_Go_Script.Ins._Form_Show.Off_Show_The_Form (_Panel_Form_Show_You);
      All_Scene_Go_Script.Ins._Form_Show.Off_Show_The_Form (_Panel_Form_Show_Child);

      Code_New_Games = All_Scene_Go_Script.Ins._Pengubah_String._String_Change_String.On_Change_String (Val);
      _Panel_Sumber_Selected_Gender.On_Refresh_Default_Select ();
      Function_New_Games (true);

      
    }

    // Button_Event_Server :
    public void On_Confirm_New_Games () {
      string [] A_Title = new string[2];
          A_Title[0] = "Yes"; A_Title[1] = "No";
          string [] A_Event = new string[2];
          A_Event[0] = "Go_Home"; A_Event[1] = "Close_Notification";
          All_Scene_Go_Script.Ins._Popup_Type._Notification.On_Notification ("Notification","Notification_1_1", "Are you sure about this ?", A_Title, A_Event);
    }
   #endregion
   #region Load_Games
    public void On_Load_Games () {
        
    }
   #endregion
   #region Settings
    public void On_Settings () {
        
    }
   #endregion
   #region Quit_Game
    public void On_Quit_Game () {
        
    }
   #endregion
}
