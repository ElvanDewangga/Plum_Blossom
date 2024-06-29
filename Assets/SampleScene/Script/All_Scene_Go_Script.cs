using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_Scene_Go_Script : MonoBehaviour {
   public static All_Scene_Go_Script Ins;
   void Awake () {
    Ins = this;
   }

   public Button_Event_Server _Button_Event_Server;
   public Popup_Type _Popup_Type;
   public Sumber_Selected_Button _Sumber_Selected_Button;
   public Form_Show _Form_Show;
   public Back_Menu _Back_Menu;
   public Pengubah_String _Pengubah_String;
   public Scene_Load _Scene_Load;
   public Sprite_Umum _Sprite_Umum;
   public Data_Slot_Canvas _Data_Slot_Canvas;
   public Raw_World _Raw_World;
   public Mouse_Position_UI _Mouse_Position_UI;
   public Baloon_Dialog _Baloon_Dialog;
   #region Active_Scene
   public enum Active_Scene {Default, Sample_Scene, Home_Scene}
   public Active_Scene _Active_Scene;
   public Local_Calendar _Local_Calendar;
   // Sample_Scene :
   public void On_Active_Scene (Active_Scene var) {
      _Active_Scene = var;
   }
   #endregion
}
