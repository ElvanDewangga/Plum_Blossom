using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Button_Object : MonoBehaviour {
    public GameObject [] A_GameObject;
    void On_Example () {
        // Selected_Button_Object_Target = 0; On_Doing_Event ("Selected_Button_Object_On_Active_Object");
    }
    
    // Blm pernah dipakai :
    public void On_Active_Object (Selected_Button_Data Sb) {
        On_Diactive_All_Object ();
        if (Sb.A_String.Length > 0) {
            A_GameObject[Sb.Selected_Button_Object_Target].SetActive (true);
        }
    }
    
    // Sumber_Selected_Button :
    public void Off_Active_Object (Selected_Button_Data Sb) {
        if (Sb.A_String.Length > 0) {
            A_GameObject[Sb.Selected_Button_Object_Target].SetActive (false);
        } else {
            A_GameObject[Sb.Selected_Button_Object_Target].SetActive (true);
        }
    }

    void On_Diactive_All_Object () {
        foreach (GameObject s in A_GameObject) {
            s.gameObject.SetActive (false);
        }
    }
}
