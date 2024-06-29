using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Kegiatan_Home : MonoBehaviour {
    // Button_Event_Server, Plum_Blossom_Show_kegiatan :
    public void On_Doing_Sleep () {
        Home_Scene.Ins.Animator_UI_Zoom_In_1.SetTrigger ("On");
        Loading.Ins.On_Dinding_Fade (1.0f);
        Loading.Ins.On_Loading_Animation_Event (On_Doing_Sleep_2, 1.5f);
      //  On_Doing_Sleep_2 ();
    }

    void On_Doing_Sleep_2 () {
        All_Scene_Go_Script.Ins._Local_Calendar.On_Next_Day ();
        Home_Scene.Ins._Header_Canvas.Bg_Calendar.gameObject.SetActive (false);
        Home_Scene.Ins._Header_Canvas.Bg_Calendar.gameObject.SetActive (true);

        On_Activity (Home_Scene.Ins._Character_Status_Sumber._Status_Universal.Hari);
    }

    #region Daily_Activity (Part_Time_Job_Utama)
    string Day;
    void On_Activity (string Day_V) {
        Day = Day_V;
        if (Day_V == "Sunday") {
            On_Activity_Sunday ();
        } else {
            On_Activity_Daily ();
        }
    }

    void On_Activity_Sunday () {
        Home_Scene.Ins._Home_Child_Interact.gameObject.SetActive (true);
    }

    void On_Activity_Daily () {
        int Target_Day = 0;
        if (Day == "Monday"){Target_Day =0;}
        else if (Day == "Tuesday"){Target_Day =1;}
        else if (Day == "Wednesday"){Target_Day =2;}
        else if (Day == "Thursday"){Target_Day =3;}
        else if (Day == "Friday"){Target_Day =4;}
        else if (Day == "Saturday"){Target_Day =5;}
         
        On_Process_Target_Day (Home_Scene.Ins._Part_Time_Job_Utama.A_Plan_Day[Target_Day]);
    }

    void On_Process_Target_Day (Selected_Button_Data Pt) {
        Home_Scene.Ins._Plum_Blossom_Show_Kegiatan.On_Doing_Kegiatan (Pt);
    }

    #endregion
    
}
