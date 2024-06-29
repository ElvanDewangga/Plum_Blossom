using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Dictionary_Load_Example : MonoBehaviour
{
    bool b_Dict_Menu =false;
    Dictionary <string, UnityAction> Dict_Menu = new Dictionary<string, UnityAction> ();

    void On_Load () {
        Dict_Menu = new Dictionary<string, UnityAction> ();
        Dict_Menu.Add ("Profile_Status",On_Profile_Status);
        Dict_Menu.Add ("Profile_Friend",On_Profile_Status);
        Dict_Menu.Add ("Profile_Lover",On_Profile_Status);
        Dict_Menu.Add ("Profile_Schedule",On_Profile_Status);
    }

    void On_Example () {
        if (!b_Dict_Menu) {
            b_Dict_Menu = true;
            On_Load ();
        }
        Dict_Menu["Profile_Status"] ();
    }

    void On_Profile_Status () {

    }
}
