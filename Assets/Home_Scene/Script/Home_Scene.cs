using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Scene : MonoBehaviour {
    public static Home_Scene Ins;
    void Awake () {
        Ins = this;
    }
    public Scene_Activity _Scene_Activity;
    public Header_Canvas _Header_Canvas;
    public Character_Status_Sumber _Character_Status_Sumber;
    public A_Character_Asset _A_Character_Asset;
    public Panel_Small_Popup _Panel_Small_Popup;
    public Panel_Small_Popup _Small_Popup_Menu_2;
    public Part_Time_Job_Utama _Part_Time_Job_Utama;
    public Profile _Profile;
    public Home_Child_Interact _Home_Child_Interact;
    public Canvas Home_Scene_Canvas;
    public Check_A_Quantity _Check_A_Quantity;
    public Animator Animator_UI_Zoom_In_1;
    public Plum_Blossom_Show_Kegiatan _Plum_Blossom_Show_Kegiatan;
    public Kegiatan_Home _Kegiatan_Home;
    #region Scene
    // Scene_Load :
    public void On_Scene () {
        _Header_Canvas.On_Header ();
        All_Scene_Go_Script.Ins._Raw_World.Get_GO_Sample ("Particle_Sakura_1").SetActive (false);
        Sample_Scene.Ins.gameObject.SetActive (false);
       // Example_Sprite = All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name ("Coin_Sprite");
    }

    public void Off_Scene () {
        
    }
    #endregion
}
