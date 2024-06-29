using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Load : MonoBehaviour {
    #region Example
    void On_Example () {
        On_Load_Scene ("Home_Scene", "Doing_This_After_Finish_Load");
    }
    #endregion
    #region Implementation
    string Event_Finish = "";
    // Button_Event_Server, Data_Slot_Canvas :
    public void On_Load_Scene (string Name_Scene, string Event_V) {
        Event_Finish = Event_V;
        StartCoroutine (N_On_Load_Scene (Name_Scene));
    }

    IEnumerator N_On_Load_Scene (string Name_Scene) {
        if (On_Check_Scene_Load (Name_Scene)) {
            // Ada scene yang sama : jangan sampai terduplikat. Unload dulu
            AsyncOperation Ao2 = SceneManager.UnloadSceneAsync (Name_Scene);
            yield return new WaitUntil (() => Ao2.isDone);
        }
        AsyncOperation Ao = SceneManager.LoadSceneAsync (Name_Scene, LoadSceneMode.Additive);
        yield return new WaitUntil (() => Ao.isDone);
        On_Finish_Load_Scene ();
    }
    #endregion
    #region Event
    void On_Finish_Load_Scene () {
       if (Event_Finish == "Open_Home") {
        Home_Scene.Ins.On_Scene ();
       } else if (Event_Finish == "Load_Data") { // Data_Slot_Canvas
       Home_Scene.Ins.On_Scene ();
        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Data_Load_2 ();
       }
    }
    
    
    #endregion
    #region On_Check_Scene_Load
    bool On_Check_Scene_Load (string Scene_Name) {
       bool Res = false;
       if (Scene_Name == "Home_Scene") {
        if (Home_Scene.Ins != null) {
            Res = true;
        } 
       } else if (Scene_Name == "") {
        
       }
       return Res;
    }
    #endregion
   
}
