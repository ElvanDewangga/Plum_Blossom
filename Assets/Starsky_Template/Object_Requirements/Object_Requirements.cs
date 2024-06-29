using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Requirements : MonoBehaviour {
    [SerializeField]
    string Code_Event = "";
    [System.Serializable]
    public class Target_Requirements {
        public int Cur_Int;
        public string Cur_String;

        public string Target_Code; // "Affection"
        public int Target_Int;
        public string Target_String;
        public System_Requirements.Requirements _Requirements;
    }
    
    [SerializeField]
    Target_Requirements [] A_Target_Requirements = new Target_Requirements[0];
   
    #region Implementation
    void On_Example_On_Target_Requirements () {
        /*
        foreach (Selected_Button Ls in L_Selected_Button){ 
                if (Ls.gameObject.GetComponent <Object_Requirements> () != null) {
                    Object_Requirements Req = Ls.gameObject.GetComponent <Object_Requirements> ();
                    Req.On_Target_Requirements (slot_req, s);
                }
            }
            */
    }
    // Sample_Scene - Panel_Sumber_Selected_Button - Line_Selected_Button :
    public void On_Target_Requirements (int Code, int Target_Int) {
        if (A_Target_Requirements.Length >0) {
            A_Target_Requirements[Code].Target_Int = Target_Int;
            if (A_Target_Requirements[Code]._Requirements == System_Requirements.Requirements.More_Or_Same) {
                if (A_Target_Requirements[Code].Target_Int >= A_Target_Requirements[Code].Cur_Int ) {
                    
                    On_Doing_Event ();
                } else {
                    On_Else_Doing_Event ();
                    
                }
            } else if (A_Target_Requirements[Code]._Requirements == System_Requirements.Requirements.Less_Or_Same) {
                if (A_Target_Requirements[Code].Target_Int <= A_Target_Requirements[Code].Cur_Int  ) {
                    
                    On_Doing_Event ();
                } else {
                    On_Else_Doing_Event ();
                    
                }
            }
        } else {
            b_Complete_All_Requirements = true;
        }
    }

    void On_Doing_Event () {
        

        if (!b_Doing_Check_All_Requirements) {
            if (Code_Event == "Set_Active_Reversal") {
                
                this.gameObject.SetActive (false);
            } 
        } else {
            
            if (b_Doing_Check_Last_Requirements) {
                if (Code_Event == "Interactable_Button") {
                        this.gameObject.GetComponent <Object_Data> ().On_Get_A_GameObject ()[0].GetComponent <Button> ().interactable = true;
                }
            }
        }
    }

    void On_Else_Doing_Event () {
        if (!b_Doing_Check_All_Requirements) { // periksa satu bagian
            if (Code_Event == "Set_Active_Reversal") {
                this.gameObject.SetActive (true);
            }
        } else { // periksa full bagian
           //  Debug.LogError ("Tidak Sesuai");
             b_Complete_All_Requirements = false;
             
            if (Code_Event == "Interactable_Button") {
                this.gameObject.GetComponent <Object_Data> ().On_Get_A_GameObject ()[0].GetComponent <Button> ().interactable = false;
            }
             
            
        }
        
    }
    #endregion
    #region Check_All_Requirements
    bool b_Doing_Check_All_Requirements = false;
    bool b_Doing_Check_Last_Requirements = false;
    // Kumpulan_System_Requirements :
    bool b_Complete_All_Requirements = false;
    // Kumpulan_System_Requirements :
    public void On_Check_All_Requirements (Kumpulan_System_Requirements Kump) {
        b_Doing_Check_All_Requirements = true; b_Doing_Check_Last_Requirements = false;
        b_Complete_All_Requirements = true;
        int x = -1;

        foreach (Target_Requirements s in A_Target_Requirements) {
           x ++;
            int.TryParse (Get_Data.Ins.On_Get_Data_By_Name (s.Target_Code).ToString (), out int target);
            if (b_Complete_All_Requirements == false) {
                break;
            }
            if (x == A_Target_Requirements.Length-1) {
                b_Doing_Check_Last_Requirements = true;
            }
            On_Target_Requirements (x, target);
            
        }
        if (b_Complete_All_Requirements) {
            Kump.On_Add_L_Object_Requirements (this);
        }
        b_Doing_Check_All_Requirements = false;
    }
    #endregion
}
