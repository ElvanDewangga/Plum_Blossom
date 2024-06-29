using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Sumber_Selected_Button : MonoBehaviour {
    
    [Tooltip("Options :")]
    [Header ("jika ingin Awake duluan :")]
    [SerializeField]
    bool b_Awake = false;
    [Header ("Centang ini jika buttonnya sudah dibuat langsung diawal")]
    // Line_Selected_Button :
    public bool b_Button_Dibuat_Langsung = false;
    [Header ("Auto_Select_Button : (Jika tidak ada yang perlu diseleksi diawal maka element ganti 0)")]
    [SerializeField]
    Selected_Button [] A_Auto_Selected_Button = new Selected_Button [0];

    List <Line_Selected_Button> L_Line_Selected_Button = new List<Line_Selected_Button> ();
    
    void Awake () {
        if (b_Awake) {
            On_Get_L_Line_Selected_Button ();
            On_L_Line_Selected_Button ();
        }
    }
    void Start () {
        
        if (b_Button_Dibuat_Langsung && !b_Awake) {
            On_Get_L_Line_Selected_Button ();
            On_L_Line_Selected_Button ();
        }
    }
    void On_Get_L_Line_Selected_Button () {
        L_Line_Selected_Button = new List<Line_Selected_Button> ();
            foreach (Transform s in this.transform) {
                if (s.GetComponent<Line_Selected_Button>() != null) {
                    L_Line_Selected_Button.Add (s.GetComponent<Line_Selected_Button>());
                }
            }
    }
    void On_L_Line_Selected_Button () {
        foreach (Line_Selected_Button Ls in L_Line_Selected_Button){
            Ls.On_Input_Panel_Sumber_Selected_Button (this);
            Ls.On_Get_L_Selected_Button ();
        }
        
        On_Refresh_Default_Select ();
    }
    #region Refresh_Default_Select
    // this, Sample_Scene
    public void On_Refresh_Default_Select () {
        if (A_Auto_Selected_Button.Length > 0) {
            foreach (Selected_Button s in A_Auto_Selected_Button) {
                s.Off_Select ();
                s.On_Cli ();
            }
        }
    }

    void On_Example_On_Refresh_All_Off_Select () {
        Panel_Sumber_Selected_Button Ps = this;
        Ps.On_Refresh_All_Off_Select ();
    }

    // Part_Time_Job_Utama :
    public void On_Refresh_All_Off_Select () {
        foreach (Line_Selected_Button Ls in L_Line_Selected_Button){
            Ls.On_Refresh_All_Off_Select ();
        }
    }
    #endregion
    #region On_Check_All_Selected_Button (Object_Requirements)
    // Sample_Scene :
    public void On_Check_All_Selected_Button (int slot_req, int s) {
        foreach (Line_Selected_Button Ls in L_Line_Selected_Button){
            Ls.On_Check_All_Selected_Button (slot_req, s);
        }
    }
    #endregion
    #region Selected_Button
    Selected_Button _Selected_Button;
    // Selected_Button :
    public void On_Selected_Button (Selected_Button sp) {
        _Selected_Button = sp;
        foreach (Line_Selected_Button Ls in L_Line_Selected_Button){
            Ls.On_Selected_Button (_Selected_Button);
        }
    }

    #endregion
    #region Selected_Button_Data
    [SerializeField]
    Selected_Button_Data [] A_Start_Selected_Button_Data;
    // Character_Status_Sumber :
    
    public void On_Start_Selected_Button_Data () {
        foreach (Selected_Button_Data s in A_Start_Selected_Button_Data) {
            s.On_Start ();
        }
    }
    #endregion
}
