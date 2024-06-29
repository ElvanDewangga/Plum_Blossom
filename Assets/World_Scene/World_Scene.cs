using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Scene : MonoBehaviour{
   public Scene_Activity _Scene_Activity;
   public static World_Scene Ins;
   void Awake () {
    Ins = this;
     
   }
   
   public World_Canvas _World_Canvas;
}
