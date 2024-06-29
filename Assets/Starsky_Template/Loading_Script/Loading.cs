using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Loading : MonoBehaviour {
    public static Loading Ins;
    void Awake () {
        Ins = this;
    }
    string Code_Active;
    // Visual_Novel_System :
   public void On_Loading (string Code_Active_V) {
        Code_Active = Code_Active_V;
        if (Code_Active == "Loading_1") {
            On_Loading_1 ();
        }
   }

    // Visual_Novel_System :
   public void Off_Loading (string x_V) {
        Code_Active = x_V;
        if (Code_Active == "Loading_1") {
            Off_Loading_1 ();
        }
   }
   [SerializeField]
   Image Loading_1; 
   void On_Loading_1 () {
    Loading_1.gameObject.SetActive (true);
   }

   void Off_Loading_1 () {
    Loading_1.gameObject.SetActive (false);
   }
    #region Loading_Animation_Event
    UnityAction Loading_Unity_Event;
    void On_Example_Loading_Animation_Event () {
        // On_Loading_Animation_Event (On_Example_Loading_Animation_Event () Event setelah loading, 1.5f lama animasi);
    }
    // Button_Event_Server, :
    public void On_Loading_Animation_Event (UnityAction UnityAction, float Time_Animation) {
        Loading_Unity_Event = UnityAction;
        StartCoroutine (N_On_Loading_Animation_Event (Time_Animation));
    }

    IEnumerator N_On_Loading_Animation_Event (float Time_Animation) {
        yield return new WaitForSeconds (Time_Animation);
        Loading_Unity_Event ();
    }
    #endregion
    #region White_Fade

    void On_Example_On_White_Fade () {
        // Ingin membuat white fade effect : Cd = Jeda waktu utk Off.
        /*
         Home_Scene.Ins.Animator_UI_Zoom_In_1.SetTrigger ("UI_Zoom_In");
        Loading.Ins.On_White_Fade (2.0f);
        Loading.Ins.On_Loading_Animation_Event (On_Example_On_White_Fade, 1.5f);
        */
        On_White_Fade (0.5f);
    }
    public void On_White_Fade (float Cd) {
        White_Fade.gameObject.SetActive (true);
        White_Fade.SetTrigger ("On");
        
        StartCoroutine (N_On_White_Fade (Cd));
    }

    IEnumerator N_On_White_Fade (float Cd) {
        yield return new WaitForSeconds (Cd);
        White_Fade.SetTrigger ("Off");
        yield return new WaitForSeconds (0.5f); // Jeda waktu Animasi fade out
        White_Fade.gameObject.SetActive (false);

    }
    // Button_Event_Server : 
    public Animator White_Fade;
    #endregion
    #region Dinding_Fade
    public Animator Dinding_Fade;
    void On_Example_On_Dinding_Fade () {
        // Ingin membuat white fade effect : Cd = Jeda waktu utk Off.
        /*
         Home_Scene.Ins.Animator_UI_Zoom_In_1.SetTrigger ("UI_Zoom_In");
        Loading.Ins.On_White_Fade (2.0f);
        Loading.Ins.On_Loading_Animation_Event (On_Example_On_White_Fade, 1.5f);
        */
        On_Dinding_Fade (0.5f);
    }
    public void On_Dinding_Fade (float Cd) {
        Dinding_Fade.gameObject.SetActive (true);
        Dinding_Fade.SetTrigger ("On");
        
        StartCoroutine (N_On_Dinding_Fade (Cd));
    }

    IEnumerator N_On_Dinding_Fade (float Cd) {
        yield return new WaitForSeconds (Cd);
        Dinding_Fade.SetTrigger ("Off");
        yield return new WaitForSeconds (0.5f); // Jeda waktu Animasi fade out
        Dinding_Fade.gameObject.SetActive (false);

    }
    #endregion
    #region Loading_Invisible_List
    // Player_Duel_Room_Field :
    public bool b_Loading_Invisible = false;
    string Event_Loading_Invisible;
    [SerializeField]
    List <string> L_Loading_Invisible;
    int Cur_Progress;
    // Duel_Mechanism, Player_Duel_Room_Field :
    // jika Cur_Progress tidak dipakai cukup tulis 0
    public void On_b_Loading_Invisible (string Event_Loading_Invisible_V, int Cur_Progress_V) {
        if (!b_Loading_Invisible) {
            b_Loading_Invisible = true;
            Cur_Progress = Cur_Progress_V;
            Event_Loading_Invisible = Event_Loading_Invisible_V;
            if (Event_Loading_Invisible == "Home_Scene_Load_Data") {
                On_Loading ("Loading_1");
            }
            else if (Event_Loading_Invisible == "Start_Save_Status" ) { // Php_Data
                
                On_Loading ("Loading_1"); 
            }
        } else {
            Debug.LogError ("Ada Loading Lewat ! Cek struktur loading");
        }
    }
    // Card_3d_Sample :
    public void On_Add_Loading_Invisible (string s) {
        if (L_Late_Rpc_Loading_Invisible.Contains (s)) {
            On_Remove_L_Late_Rpc_Loading_Invisible (s);
        } else {
            L_Loading_Invisible.Add (s);
        }
        
    }

    public void On_Remove_Loading_Invisible (string s) {
        if (L_Loading_Invisible.Contains (s)) {
            L_Loading_Invisible.Remove (s);
        } else {
            On_Add_L_Late_Rpc_Loading_Invisible (s);
        }
        
        if (b_Loading_Invisible) {
            On_Check_Finish_Loading ();
        }

    }

    void On_Check_Finish_Loading () {
        // Debug.LogError ("Loading Removed");
            if (Cur_Progress >0) {
                Cur_Progress --;
            }

            if (L_Loading_Invisible.Count == 0 && Cur_Progress == 0) {                
                On_Finish_Event_Loading_Invisible ();   
            }
    }

    string Target_Loading_Invisible = ""; // supaya variable bisa lanjut loading dari Loading_Input_Deck ke Loading_Client_Pemisah_Duel_Room
    void On_Finish_Event_Loading_Invisible () {
         b_Loading_Invisible = false;
        Target_Loading_Invisible = Event_Loading_Invisible;

        if (Target_Loading_Invisible == "First_Draw") {

        }
       
        Target_Loading_Invisible = "";

        
    }

    [SerializeField]
    List <string> L_Late_Rpc_Loading_Invisible;
    void On_Add_L_Late_Rpc_Loading_Invisible (string s) {
        L_Late_Rpc_Loading_Invisible.Add (s);
    }

    void On_Remove_L_Late_Rpc_Loading_Invisible (string s) {
        L_Late_Rpc_Loading_Invisible.Remove (s);
    }
    #endregion
}
