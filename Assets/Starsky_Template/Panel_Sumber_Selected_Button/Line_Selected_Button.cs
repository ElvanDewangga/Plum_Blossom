using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Selected_Button : MonoBehaviour { 
   // Selected_Button :
   public Panel_Sumber_Selected_Button _Panel_Sumber_Selected_Button;
   List <Selected_Button> L_Selected_Button = new List<Selected_Button> ();
   
   public void On_Input_Panel_Sumber_Selected_Button (Panel_Sumber_Selected_Button s) {
    _Panel_Sumber_Selected_Button = s;
   }

   public void On_Get_L_Selected_Button () {
        if (_Panel_Sumber_Selected_Button.b_Button_Dibuat_Langsung) {
            L_Selected_Button = new List<Selected_Button> ();
            foreach (Transform s in this.transform) {
                if (s.GetComponent<Selected_Button>() != null) {
                    Selected_Button Ss = s.GetComponent<Selected_Button>();
                    L_Selected_Button.Add (Ss);
                    Ss.On_Input_Line_Selected_Button (this);
                }
            }
        }
    }

    #region Panel_Sumber_Selected_Button
    public void On_Selected_Button (Selected_Button sp) {
        
        foreach (Selected_Button Ls in L_Selected_Button){
            if (sp == Ls) {
                Ls.On_Select ();
            } else {
                Ls.Off_Select ();
            }
        }
    }
        #region On_Check_All_Selected_Button (Object_Requirements)
        // Pnale_Sumber_Selected_Button :
        public void On_Check_All_Selected_Button (int slot_req, int s) {
            foreach (Selected_Button Ls in L_Selected_Button){ 
                if (Ls.gameObject.GetComponent <Object_Requirements> () != null) {
                    Object_Requirements Req = Ls.gameObject.GetComponent <Object_Requirements> ();
                    Req.On_Target_Requirements (slot_req, s);
                }
            }
        }
        #endregion
        
        #region On_Refresh_All_Off_Select
        // Panel_Sumber_Selected_Button :
        public void On_Refresh_All_Off_Select () {
            
            foreach (Selected_Button Ls in L_Selected_Button){
                Ls.Off_Select ();
            }
        }
        #endregion
    #endregion
    
    
}
