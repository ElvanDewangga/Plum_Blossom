using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Starsky;
public class GameObject_And_Destroy : MonoBehaviour {
   [SerializeField]
   Transform Layout_Parent;

   // Hover_Select : 
   public void On_Instantiate (string Cd) {
        Star_GameObject Star = new Star_GameObject ();
        if (Cd == "On_Scalling_1") {
            
            Star.On_Instantiate (All_Scene_Go_Script.Ins._Popup_Type.Yellow_Arrow, Layout_Parent, true);
        }
   }

   // Hover_Select : 
   public void On_Destroy () {
        foreach (Transform t in Layout_Parent) {
            Destroy (t.gameObject);        
        }
   }
}
