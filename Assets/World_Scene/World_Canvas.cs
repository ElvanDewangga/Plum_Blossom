using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Numerics;
using UnityEngine.UI;
using Fungus;
public class World_Canvas : MonoBehaviour {
   
   // Button_Event_Server :
   string Code_Building = "";
   public void On_Town_Place (string Event) {
    Code_Building = Event;
     On_Load_All_Dictionary ();
        Dict_Town[Event] ();
   }

   void On_Load_All_Dictionary () {
        if (!b_Dict_Town) {
            b_Dict_Town = true;
            On_Load ();
            On_Load_Dict_Hover_Town_Keterangan ();
        }
   }
    #region Dictionary_Town
    bool b_Dict_Town =false;
    Dictionary <string, UnityAction> Dict_Town = new Dictionary<string, UnityAction> ();
    Dictionary <string, int []> Dict_Button_Keterangan = new Dictionary<string, int[]> ();
    void On_Load () {
        Dict_Town = new Dictionary<string, UnityAction> ();
        Dict_Town.Add ("Town_Home",On_Town_Home);
        Dict_Town.Add ("Town_Restaurant", On_Open_Display_Building);
        Dict_Town.Add ("Town_City_Hall", On_Open_Display_Building);
        Dict_Town.Add ("Town_Park", On_Open_Display_Building);
        Dict_Town.Add ("Town_Beach", On_Open_Display_Building);
        Dict_Town.Add ("Town_Museum", On_Open_Display_Building);
        Dict_Town.Add ("Town_Dugeon", On_Open_Display_Building);
        Dict_Town.Add ("Town_Church", On_Open_Display_Building);
        Dict_Town.Add ("Town_Mangolia_Building", On_Open_Display_Building);
        Dict_Town.Add ("Town_Clothes_Store", On_Open_Display_Building);
        Dict_Town.Add ("Town_Weapon_Store", On_Open_Display_Building);
        Dict_Town.Add ("Town_Hospital", On_Open_Display_Building);

        Dict_Button_Keterangan = new Dictionary<string, int[]> ();
        Dict_Button_Keterangan.Add ("Town_Home",new int [] {0});
        Dict_Button_Keterangan.Add ("Town_Restaurant", new int [] {0,1,2});
        Dict_Button_Keterangan.Add ("Town_City_Hall", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Park", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Beach", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Museum", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Dugeon", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Church", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Mangolia_Building", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Clothes_Store", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Weapon_Store", new int [] {0,2});
        Dict_Button_Keterangan.Add ("Town_Hospital", new int [] {0,2});

    }

    void On_Town_Home () {
       
        Loading.Ins.On_White_Fade (2.0f);
        Loading.Ins.On_Loading_Animation_Event (On_Town_Home_2, 1.5f);
       
    }

    public void On_Town_Home_2 () {
         World_Scene.Ins._Scene_Activity.Off_Masuk_Scene ("World_Scene");
    }

    public void Cli_On_Shop () {
        if (Code_Building == "Town_Restaurant") {
            On_Restaurant ();
        }
    }

        #region On_Open_Display_Building
        
            [SerializeField]
            Hover_Select _Hover_Select_Display_Building;
            [SerializeField]
            Image Bg_Open_Display_Building;
            [SerializeField]
            Button [] A_Button_Open_Display_Building;
            void Off_A_Button_Open_Display_Buiding () {
                foreach (Button B in A_Button_Open_Display_Building) {
                    B.gameObject.SetActive (false);
                }
            }

            void On_A_Button_Open_Display_Building (int [] sb) {
                foreach (int s in sb) {
                    A_Button_Open_Display_Building[s].gameObject.SetActive (true);
                }
            }
            [SerializeField]
            TMP_Text TMP_Text_Display_Building;
            void On_Open_Display_Building () {
                Off_Hover_Town_keterangan ();
                _Hover_Select_Display_Building.gameObject.SetActive (false);
                TMP_Text_Display_Building.text = Code_Building;
                Bg_Open_Display_Building.gameObject.SetActive (true);
                Off_A_Button_Open_Display_Buiding ();
                On_A_Button_Open_Display_Building(Dict_Button_Keterangan[Code_Building]);
            }

            public void Off_Open_Display_Building () {
                
                _Hover_Select_Display_Building.gameObject.SetActive (true);
                Bg_Open_Display_Building.gameObject.SetActive (false);
            }
        #endregion
        #region Restaurant
        [SerializeField]
        Image Bg_Restaurant;
        void On_Restaurant () {
            Bg_Restaurant.gameObject.SetActive (true);
        }

        public void Off_Restaurant () {
            Bg_Restaurant.gameObject.SetActive (false);
        }
        #endregion
    #endregion
    #region Dict_Hover_Town_Keterangan
    Dictionary <string, string> Dict_Hover_Town_Keterangan = new Dictionary<string, string>  ();
    
    void On_Load_Dict_Hover_Town_Keterangan () {
        Dict_Hover_Town_Keterangan = new Dictionary<string, string> ();
        Dict_Hover_Town_Keterangan.Add ("Town_Home", "This is your home");
        Dict_Hover_Town_Keterangan.Add ("Town_Restaurant", "You can buy some food and eat here.");
        Dict_Hover_Town_Keterangan.Add ("Town_City_Hall", "The famous city hall in this town.");
        Dict_Hover_Town_Keterangan.Add ("Town_Park", "There are so many kinds of flower. You can visit here to see flowers.");
        Dict_Hover_Town_Keterangan.Add ("Town_Beach", "Beach there have so many visitor in weekend");
        Dict_Hover_Town_Keterangan.Add ("Town_Museum", "This museum was built since 2000");
        Dict_Hover_Town_Keterangan.Add ("Town_Dugeon", "You can battle with creatures and gathering some item in here.");
        Dict_Hover_Town_Keterangan.Add ("Town_Church", "Religious Place that residence come for prays.");
        Dict_Hover_Town_Keterangan.Add ("Town_Mangolia_Building", "Building of Mangolia");
        Dict_Hover_Town_Keterangan.Add ("Town_Clothes_Store", "Clothes store sells out kinds of clothes");
        Dict_Hover_Town_Keterangan.Add ("Town_Weapon_Store", "You can buy weapon here");
        Dict_Hover_Town_Keterangan.Add ("Town_Hospital", "Hospital in this town.");
    }
        #region Display
        [SerializeField]
        Baloon_Dialog _Baloon_Dialog_Town_keterangan;
        #endregion
    #endregion
    #region Hover_Select
    public void On_Hover_Town_keterangan (Hover_Select_Object Sb) {
        On_Load_All_Dictionary ();
        Button_Event Be = Sb.gameObject.GetComponent <Button_Event> ();
        _Baloon_Dialog_Town_keterangan.On_Selisih_Jarak (new UnityEngine.Vector3 (15,15,0));
        _Baloon_Dialog_Town_keterangan.On_Set_Active_Baloon_Dialog (Dict_Hover_Town_Keterangan[Be.Event_V], "", Sb.gameObject.transform);
        
       // _Baloon_Dialog_Town_keterangan.gameObject.SetActive (true);
    }

    public void Off_Hover_Town_keterangan () {
        _Baloon_Dialog_Town_keterangan.On_Set_Active (false);
    }
    #endregion
}
