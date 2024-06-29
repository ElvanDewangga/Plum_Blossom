using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Character_Asset : MonoBehaviour {
   // Visual_Novel_World :
   public Character_Asset On_Get_Character_Asset (string Character_Code_V) {
        Character_Asset Res = null ;
        foreach (Transform s in this.transform) {
            Character_Asset ss = s.GetComponent <Character_Asset>();
            if (ss.Character_Code == Character_Code_V) {
                Res = ss;
                break;
            }
        } 

        return Res;
   }

}
