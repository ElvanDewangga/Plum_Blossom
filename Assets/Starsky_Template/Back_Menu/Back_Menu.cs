using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Menu : MonoBehaviour {
    [SerializeField]
    List <Keterangan_Menu> L_Opening_Menu = new List<Keterangan_Menu> ();
    [System.Serializable]
    public class Keterangan_Menu {
        public string Code_Menu = "";
        public object Object_Menu;
    }

    #region Implementation
        #region Call
        void On_Example () {
            // Connected with : Close_Button C#
            On_Refresh_Menu ();

            Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
            Km.Code_Menu = "Inventory_Menu"; Km.Object_Menu = 2;

            On_Add_Menu (Km);
            // On_Remove_Menu (Km);
        }

        /*
        public void On_Load (bool Back_Menu_V) {
            On_Active ("Load");

            Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
                Km.Code_Menu = "Inventory_Menu"; Km.Object_Menu = 2;

                All_Scene_Go_Script.Ins._Back_Menu.On_Add_Menu (Km);
        }

        void Off_Load (bool Back_Menu_V) {
            Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
                Km.Code_Menu = "Inventory_Menu"; Km.Object_Menu = 2;

                All_Scene_Go_Script.Ins._Back_Menu.On_Remove_Menu (Km);
        }
        */

        #endregion
    public void On_Add_Menu (Keterangan_Menu Back_Keterangan_Menu) {
        L_Opening_Menu.Add (Back_Keterangan_Menu);
    }

    public void On_Remove_Menu (Keterangan_Menu Cs) {
        
        foreach (Keterangan_Menu Ks in L_Opening_Menu) {
            if (Ks.Code_Menu == Cs.Code_Menu && Ks.Object_Menu == Cs.Object_Menu) {
                On_Back_Menu_Event (Ks, false);
                L_Opening_Menu.Remove (Ks);
                break;
            }
        }
    }

    // Notification :
    public void On_Remove_Menu_Latest () {
        On_Remove_Menu_Latest_2 (false);
    }

    void On_Remove_Menu_Latest_2 (bool IsClose) {
        if (L_Opening_Menu.Count >0) {
            On_Back_Menu_Event (L_Opening_Menu[L_Opening_Menu.Count-1],IsClose);
            L_Opening_Menu.RemoveAt (L_Opening_Menu.Count -1);
        }
    }

    void On_Refresh_Menu () {
        L_Opening_Menu = new List<Keterangan_Menu> ();
    }
    #endregion
    #region Event
        
        void On_Back_Menu_Event (Keterangan_Menu Ks, bool IsClose) {
            // IsClose = true (Menutup Menu) IsClose = false (buka ulang menu)
            if (Ks.Code_Menu == "Data_Slot_Canvas") { // Data_Slot_Canvas
                if (Ks.Object_Menu.ToString () == "On_Load") {
                    if (IsClose) {
                        All_Scene_Go_Script.Ins._Data_Slot_Canvas.Off_Load (false);
                    } else {
                        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Load (true);
                    }
                    
                } else if (Ks.Object_Menu.ToString () == "On_Save") {
                    if (IsClose) {
                        All_Scene_Go_Script.Ins._Data_Slot_Canvas.Off_Load (false);
                    } else {
                        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Save (true);
                    }
                } 
            } else if (Ks.Code_Menu == "Part_Time_Job_Utama") {
                Home_Scene.Ins._Part_Time_Job_Utama.Off_Open ();
            } else if (Ks.Code_Menu == "Profile") {
                Home_Scene.Ins._Profile.Off_Open ();
            }
        }

    #endregion
    #region Close_Button
    // Close_Button :
    public void On_Close_Menu () {
       On_Remove_Menu_Latest_2 (true);
    }
    #endregion
    
}
