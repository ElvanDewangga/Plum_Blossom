using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.Events;
public class Sumber_Selected_Button : MonoBehaviour {
   Dictionary <string, UnityAction<Selected_Button>> Dict_Selected_Button = new Dictionary <string, UnityAction<Selected_Button>> ();

   void Start () {
     On_Load_Dict_Selected_Button_Data ();
    Dict_Selected_Button = new Dictionary <string, UnityAction<Selected_Button>> ();
    Dict_Selected_Button.Add ("Choose_Month",On_Choose_Month);
    Dict_Selected_Button.Add ("Choose_Day",On_Choose_Day);
    Dict_Selected_Button.Add ("Choose_Awal",On_Choose_Awal);
    Dict_Selected_Button.Add ("Profile_Status",On_Profile_Menu );
    Dict_Selected_Button.Add ("Profile_Friend",On_Profile_Menu );
    Dict_Selected_Button.Add ("Profile_Lover",On_Profile_Menu );
    Dict_Selected_Button.Add ("Profile_Schedule",On_Profile_Menu );
    Dict_Selected_Button.Add ("Part_Time_Job", On_Part_Time_Job);
    Dict_Selected_Button.Add ("Plan_Class", On_Plan_Class);
    Dict_Selected_Button.Add ("Plan_Day", On_Plan_Day);
    Dict_Selected_Button.Add ("Note_Part_Time_Job", On_Note_Part_Time_Job);
    Dict_Selected_Button.Add ("Note_Plan_Class", On_Note_Plan_Class);
    Dict_Selected_Button.Add ("Clear_Schedule", On_Clear_Schedule);
    Dict_Selected_Button.Add ("Clear_Job", On_Clear_Job);
    Dict_Selected_Button.Add ("",On_Kosong );
   } 

   #region Selected_Button
     void On_Example (Selected_Button Sb) {
          Selected_Button Get_Sb = Sb;
     }
   // Selected_Button :
   public void On_Doing_Event (Selected_Button Sb) {
    Dict_Selected_Button[Sb.Event](Sb);
   }

   void On_Choose_Month (Selected_Button Sb) {
        Sample_Scene.Ins.On_Get_Input (Sb); 
   }

   void On_Choose_Day (Selected_Button Sb) {
        Sample_Scene.Ins.On_Get_Input (Sb); 
   }

   void On_Choose_Awal (Selected_Button Sb) {
        Sample_Scene.Ins.On_Get_Input (Sb); 
   }

   void On_Profile_Menu (Selected_Button Sb) {
        Home_Scene.Ins._Profile.On_Menu (Sb.Event);
   }

   void On_Kosong (Selected_Button Sb) {
        Debug.LogError ("Event Kosong");
   }

   void On_Part_Time_Job (Selected_Button Sb) {
     
   
     Home_Scene.Ins._Part_Time_Job_Utama.On_Get_Selected_Button_Part_Time_Job (Sb);
   }

   void On_Plan_Class (Selected_Button Sb) {
     
   
     Home_Scene.Ins._Part_Time_Job_Utama.On_Get_Selected_Button_Plan_Class (Sb);
   }

   void On_Plan_Day (Selected_Button Sb) {
   //  Debug.Log ("Plan Day");
     Home_Scene.Ins._Part_Time_Job_Utama.On_Get_Selected_Button_Plan_Day (Sb);
   }

   void On_Note_Part_Time_Job (Selected_Button Bs) {
     Home_Scene.Ins._Part_Time_Job_Utama.On_Table_Menu (Bs.Event);
   }

   void On_Note_Plan_Class (Selected_Button Bs) {
     Home_Scene.Ins._Part_Time_Job_Utama.On_Table_Menu (Bs.Event);
   }

   void On_Clear_Schedule (Selected_Button Bs) {
     Home_Scene.Ins._Part_Time_Job_Utama.On_Clear_Plan (true); 
   }

   void On_Clear_Job (Selected_Button Bs) {
     Home_Scene.Ins._Part_Time_Job_Utama.On_Clear_Plan (true); 
   }
   #endregion

   #region Selected_Button_Data 
Dictionary <string, UnityAction<Selected_Button_Data>> Dict_Selected_Button_Data = new Dictionary <string, UnityAction<Selected_Button_Data>> ();

     void On_Load_Dict_Selected_Button_Data () {
          Dict_Selected_Button_Data = new Dictionary <string, UnityAction<Selected_Button_Data>> ();
          Dict_Selected_Button_Data.Add ("Button_Sprite_On_Set_Sprite",Button_Sprite_On_Set_Sprite );
          Dict_Selected_Button_Data.Add ("Selected_Button_Object_On_Active_Object",Selected_Button_Object_On_Active_Object );
          Dict_Selected_Button_Data.Add ("Selected_Button_Object_Off_Active_Object",Selected_Button_Object_Off_Active_Object );
     } 

     public void On_Doing_Event (Selected_Button_Data Sb) {
          Dict_Selected_Button_Data[Sb.Code_Event](Sb);
     }
     
     void On_Example (Selected_Button_Data Sb) {
          Selected_Button_Data Get_Sb = Sb;
     }
     // Selected_Button :
     public void Button_Sprite_On_Set_Sprite (Selected_Button_Data Sb) {
          if (Sb.A_String.Length >0) {
               Sb.gameObject.GetComponent <Button_Sprite> ().On_Set_Sprite (All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name(Sb.A_String[0] + "_Sprite"));
          } else {
                Sb.gameObject.GetComponent <Button_Sprite> ().On_Set_Sprite (All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name("Polos_Sprite"));
          }
     }

     public void Selected_Button_Object_On_Active_Object (Selected_Button_Data Sb) {
         Sb.gameObject.GetComponent <Selected_Button_Object> ().On_Active_Object (Sb);
     }

     public void Selected_Button_Object_Off_Active_Object (Selected_Button_Data Sb) {
         Sb.gameObject.GetComponent <Selected_Button_Object> ().Off_Active_Object (Sb);
     }
    
   #endregion
}
