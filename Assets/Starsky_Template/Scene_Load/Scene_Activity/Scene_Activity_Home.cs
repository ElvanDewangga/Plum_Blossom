using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Activity_Home : Scene_Activity {
    public override void On_Active_Scene()
    {
        this.gameObject.SetActive (true);
    }

    public override void Off_Active_Scene()
    {
        this.gameObject.SetActive (false);
    }


    public override void On_Load_Open_Something () {
        Dict_Open_Something = new Dictionary<string, GameObject> ();
        Dict_Open_Something.Add ("Home_Canvas", A_GO_Open_Something[0]);
        Dict_Open_Something.Add ("Header_Canvas", A_GO_Open_Something[1]);
    }

    public override void On_Open_Something (string val) {
        if (!b_Load_Open_Something) {
            
             b_Load_Open_Something = true;
            On_Load_Open_Something ();
        }
        base.On_Open_Something (val);
    }

    public override void Off_Open_Something (string val) {
        if (!b_Load_Open_Something) {
             b_Load_Open_Something = true;
            On_Load_Open_Something ();
        }
        base.Off_Open_Something (val);
    }


    public override void On_Masuk_Scene (string From_Event) {
        if (From_Event == "World_Scene") { // Scene_Activity_World
            On_Open_Something ("Home_Canvas");
            Home_Scene.Ins.Animator_UI_Zoom_In_1.SetTrigger ("UI_Zoom_Out");
        }
    }

    public override void Off_Masuk_Scene (string From_Event) {
        if (From_Event == "World_Scene") { // Scene_Activity_World
            Off_Open_Something ("Home_Canvas");
        }
    }
}
