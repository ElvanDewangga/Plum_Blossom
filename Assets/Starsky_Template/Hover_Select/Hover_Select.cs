using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class Hover_Select : MonoBehaviour{ // Sumber
    Dictionary <string, UnityAction<Hover_Select_Object>> Dict_Hover_Select_Object = new Dictionary <string, UnityAction<Hover_Select_Object>> ();

   void Start () {
    Dict_Hover_Select_Object = new Dictionary <string, UnityAction<Hover_Select_Object>> ();
    Dict_Hover_Select_Object.Add ("On_Scalling_1",On_Scalling_1);
    Dict_Hover_Select_Object.Add ("Off_Scalling_1",Off_Scalling_1);
    Dict_Hover_Select_Object.Add ("On_Glow_1",On_Glow_1);
    Dict_Hover_Select_Object.Add ("Off_Glow_1",Off_Glow_1);
    Dict_Hover_Select_Object.Add ("On_Hover_Keterangan_Town",On_Hover_Keterangan_Town);
    Dict_Hover_Select_Object.Add ("Off_Hover_Keterangan_Town",Off_Hover_Keterangan_Town);

   } 

   #region Hover_Select_Object
   // Selected_Button :
   public void On_Doing_Event (Hover_Select_Object Sb) {
    Dict_Hover_Select_Object[Sb.On_Event](Sb);
   }

   void On_Scalling_1 (Hover_Select_Object Sb) {
     //  Sb.transform.localScale = new Vector3 (1.15f, 1.15f, 1.15f);
     Sb._Animator.SetBool ("Hover", true); 
       Sb.gameObject.GetComponent<GameObject_And_Destroy> ().On_Instantiate (Sb.On_Event);
   }

   void On_Glow_1 (Hover_Select_Object Sb) {
      Sb.gameObject.GetComponent<Hover_Sprite> ().On_Hover ();
   }

    // Selected_Button :
   public void Off_Doing_Event (Hover_Select_Object Sb) {
    Dict_Hover_Select_Object[Sb.Off_Event](Sb);
   }

   void Off_Glow_1 (Hover_Select_Object Sb) {
     Sb.gameObject.GetComponent<Hover_Sprite> ().Off_Hover ();
   }

   void Off_Scalling_1 (Hover_Select_Object Sb) {
     //  Sb.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
       Sb._Animator.SetBool ("Hover", false); 
       Sb.gameObject.GetComponent<GameObject_And_Destroy> ().On_Destroy ();
   }

   void On_Hover_Keterangan_Town (Hover_Select_Object Sb) {
    World_Scene.Ins._World_Canvas.On_Hover_Town_keterangan (Sb);
    
   }

   void Off_Hover_Keterangan_Town (Hover_Select_Object Sb) {
    World_Scene.Ins._World_Canvas.Off_Hover_Town_keterangan ();
   }
   #endregion
   #region Link_Select_Object
    [SerializeField]
    List <Hover_Select_Object> L_Hover_Select_Object = new List<Hover_Select_Object> ();
    
   #endregion 
}
