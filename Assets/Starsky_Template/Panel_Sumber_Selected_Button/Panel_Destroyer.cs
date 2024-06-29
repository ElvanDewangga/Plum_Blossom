using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Destroyer : MonoBehaviour {
   // Notification_Script :
   public Transform Layout;
   
   #region Diactive & Destroy All Clone
    // Notification_Script, Data_Slot_Canvas, Visual_Novel_Option :
    public void On_Destroy_All_Clone () {
        On_All_Destroy ();
    }

    void On_All_Diactive () {
        foreach (Transform t in Layout.transform) {
            t.gameObject.SetActive (false);
        }
    }

    void On_All_Destroy () {
        foreach (Transform t in Layout.transform) {
            Clone_Sample Cs = t.gameObject.GetComponent <Clone_Sample> ();
            if (Cs != null) {
                if (Cs.b_Clone) {
                    Destroy (t.gameObject);
                }
            }
        }
    }
   #endregion
}
