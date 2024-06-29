using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kumpulan_System_Requirements : MonoBehaviour {
    List <Object_Requirements> L_Object_Requirements = new List<Object_Requirements> ();
    void On_Example_Check_All_Object_Requirements () {
        // Refresh semua requirements terlebih dahulu : Home_Child_Interact
        this.On_Check_All_Object_Requirements ();
        this.On_Get_Random ();
    }

    public void On_Check_All_Object_Requirements () {
        L_Object_Requirements = new List<Object_Requirements> ();
        foreach (Transform s in this.transform) {
            s.GetComponent<Object_Requirements> ().On_Check_All_Requirements (this);
        }
    }

    #region Implementation
    void On_Example_On_Get_Random () {
        // jika ingin mengambil salah satu object_requirements yang sesuai syarat : Home_Child_Interact
        this.On_Get_Random ();
    }
    
    public GameObject On_Get_Random () {
        if (L_Object_Requirements.Count > 0) {
            return L_Object_Requirements[Random.Range (0, L_Object_Requirements.Count)].gameObject;
        } else {
            Debug.LogError ("Kumpulan_System null");
            return null;
        }
        
    }

        #region On_Get_Object
        void On_Example_On_Get_Object () {
            this.On_Get_Object (0);
        }
        
        public GameObject On_Get_Object (int Number) {
            return L_Object_Requirements[Number].gameObject;
        }

        #endregion
    #endregion
    #region Object_Requirements
    // this - Object_Requirements :
    public void On_Add_L_Object_Requirements (Object_Requirements s) {
        L_Object_Requirements.Add (s);
    }
    #endregion
}
