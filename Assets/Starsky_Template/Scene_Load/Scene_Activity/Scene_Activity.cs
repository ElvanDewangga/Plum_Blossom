using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scene_Activity : MonoBehaviour{
    
    void On_Example_Active_Scene () {
       // Home_Scene.Ins._Scene_Activity.On_Active_Scene ();
     //   Home_Scene.Ins._Scene_Activity.Off_Active_Scene ();
    }
    public abstract void On_Active_Scene ();
    public abstract void Off_Active_Scene ();


    void On_Example_Open_Something () {
        // Home_Scene.Ins._Scene_Activity.On_Open_Something ("Header_Canvas");
    }

    void On_Example_Add_Dict_Open_Something () {
        // Dict_Open_Something.Add ("Header_Canvas", A_GO_Open_Something[0]);
    }
    /*
    public abstract GameObject [] A_GO_Open_Something {get;set;}
    public abstract Dictionary <string, GameObject> Dict_Open_Something {get;set;}
    */
    public GameObject [] A_GO_Open_Something;
    public Dictionary <string, GameObject> Dict_Open_Something = new Dictionary<string, GameObject> ();
    public bool b_Load_Open_Something = false;
    public virtual void On_Load_Open_Something () {
        
    }

    public virtual void On_Open_Something (string val) {
        Dict_Open_Something [val].SetActive (true);
    }

    public virtual void Off_Open_Something (string val) {
        Dict_Open_Something [val].SetActive (false);
    }

    void On_Example_On_Masuk_Scene () {
       // Home_Scene.Ins._Scene_Activity.On_Masuk_Scene ("World_Scene"); 
    }
    public abstract void On_Masuk_Scene (string From_Event);
    public abstract void Off_Masuk_Scene (string From_Event);
}
