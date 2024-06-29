using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Profile : Panel_Model_2_Utama {
     [SerializeField]
    Transform Layout_Close_Button;

    public override void On_Open () {
        All_Scene_Go_Script.Ins._Popup_Type._Close_Button.On_Active_Close_Button (Layout_Close_Button);

        Back_Menu.Keterangan_Menu Km = new Back_Menu.Keterangan_Menu ();
            Km.Code_Menu = "Profile"; Km.Object_Menu = 0;

            All_Scene_Go_Script.Ins._Back_Menu.On_Add_Menu (Km);

        base.On_Open ();

        
    }

    public override void Off_Open () {
         base.Off_Open ();
    }

    #region Menu_Option
     bool b_Dict_Menu =false;
    Dictionary <string, UnityAction> Dict_Menu = new Dictionary<string, UnityAction> ();

    void On_Load () {
        Dict_Menu = new Dictionary<string, UnityAction> ();
        Dict_Menu.Add ("Profile_Status",On_Profile_Status);
        Dict_Menu.Add ("Profile_Friend",On_Profile_Friend);
        Dict_Menu.Add ("Profile_Lover",On_Profile_Lover);
        Dict_Menu.Add ("Profile_Schedule",On_Profile_Schedule);
    }

    
    public void On_Menu (string Menu_Option) {
        if (!b_Dict_Menu) {
            b_Dict_Menu = true;
            On_Load ();
        }
        Off_All_Menu ();
        Dict_Menu[Menu_Option] ();
    }

    void Off_All_Menu () {
        foreach (GameObject x in A_Profile_Menu) {
            x.SetActive (false);
        }
    }
    
    [SerializeField]
    GameObject [] A_Profile_Menu;
    void On_Profile_Status () {
        A_Profile_Menu[0].gameObject.SetActive (true);
    }

    void On_Profile_Friend () {
         A_Profile_Menu[1].gameObject.SetActive (true);
         On_Show_Profile_Friend ();
    }

    void On_Profile_Lover () {
         A_Profile_Menu[2].gameObject.SetActive (true);
    }

    void On_Profile_Schedule () {
         A_Profile_Menu[3].gameObject.SetActive (true);
    }
    #endregion
    #region Profile_Friend
    [SerializeField]
    Character_Asset [] Friend_A_Character_Asset;
    [SerializeField]
    GameObject Friend_Label_Sample;
    [SerializeField]
    Transform Friend_Layout;
    void On_Show_Profile_Friend () {
        On_Destroy_Friend_Layout ();
        

        foreach (Character_Asset s in Friend_A_Character_Asset) {
            GameObject ss = GameObject.Instantiate (Friend_Label_Sample);
            ss.transform.SetParent (Friend_Layout);
            Clone_Sample Cs = ss.gameObject.GetComponent <Clone_Sample> ();
            Cs.On_Set_b_Clone (true);
            Profile_Friend_Label Ch = ss.gameObject.GetComponent <Profile_Friend_Label> ();
            Ch.On_Input_Form_1 (s);
        }

    }

    void On_Destroy_Friend_Layout () {
        foreach (Transform s in Friend_Layout.transform) {
            if (s.GetComponent <Clone_Sample> ().b_Clone) {
                Destroy (s.gameObject);
            }
        }
    }
    #endregion
}
