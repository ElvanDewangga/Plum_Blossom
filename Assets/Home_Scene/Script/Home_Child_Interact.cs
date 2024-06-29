using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Child_Interact : MonoBehaviour {
    [SerializeField]
    Kumpulan_System_Requirements Kumpulan_About_Future;
    [SerializeField]
    Kumpulan_System_Requirements Kumpulan_About_Criticize;
    [SerializeField]
    Kumpulan_System_Requirements Kumpulan_Child_Give;
    [SerializeField]
    GameObject Baloon_Img_Position;
    // Button_Event_Server :
    string Event = "";
    public void On_Interact (string Event_V) {
        Event = Event_V;
        if (Event_V == "Child_Chat_About_Future" || Event_V == "Child_Chat_Criticize") {
            On_Dialog ();
        } else if (Event_V == "Child_Give_100_Coin" || Event_V == "Child_Give_500_Coin" || Event_V == "Child_Give_1000_Coin") {
            On_Give_Coin ();
        }
    }

    void On_Dialog () {
        
        if (Event == "Child_Chat_About_Future") {
            Kumpulan_About_Future.On_Check_All_Object_Requirements ();
            string Isi = Kumpulan_About_Future.On_Get_Random().GetComponent <Object_Data> ().On_Get_A_String ()[0];
            All_Scene_Go_Script.Ins._Baloon_Dialog.On_Call_Baloon_Dialog (Isi,"Can_Child_Chat_Again", Baloon_Img_Position.transform);

            Set_Data.Ins.On_Set_Data_Inc_By_Name ("Cur_Stress", -3); 
            Set_Data.Ins.On_Set_Data_Inc_By_Name ("Affection", 3); 
            Set_Data.Ins.On_Set_Data_Inc_By_Name ("Darkness", -3); 
        } else if (Event == "Child_Chat_Criticize") {
            
            Kumpulan_About_Criticize.On_Check_All_Object_Requirements ();
            string Isi = Kumpulan_About_Criticize.On_Get_Random().GetComponent <Object_Data> ().On_Get_A_String ()[0];
            All_Scene_Go_Script.Ins._Baloon_Dialog.On_Call_Baloon_Dialog (Isi,"Can_Child_Chat_Again", Baloon_Img_Position.transform); 
            Set_Data.Ins.On_Set_Data_Inc_By_Name ("Cur_Stress", 3); 
            Set_Data.Ins.On_Set_Data_Inc_By_Name ("Affection", -5); 
            Set_Data.Ins.On_Set_Data_Inc_By_Name ("Darkness", 5); 
        }
    }
    // Small_Popup_Menu_2
    public void On_Check_Object_Requirements () {
        Kumpulan_Child_Give.On_Check_All_Object_Requirements ();
    }
    void On_Give_Coin () {
        if (Event == "Child_Give_100_Coin") {
           // Kumpulan_Child_Give.On_Check_All_Object_Requirements ();
            string Isi = Kumpulan_Child_Give.On_Get_Object(0).GetComponent <Object_Data> ().On_Get_A_String ()[0];
            All_Scene_Go_Script.Ins._Baloon_Dialog.On_Call_Baloon_Dialog (Isi,"Can_Child_Chat_Again", Baloon_Img_Position.transform);
            Set_Data.Ins.On_Set_Data_Non_Mono_Inc_By_Name ("Coin", 100);
        } else if (Event == "Child_Give_500_Coin") {
          //  Kumpulan_Child_Give.On_Check_All_Object_Requirements ();
            string Isi = Kumpulan_Child_Give.On_Get_Object(1).GetComponent <Object_Data> ().On_Get_A_String ()[0];
            All_Scene_Go_Script.Ins._Baloon_Dialog.On_Call_Baloon_Dialog (Isi,"Can_Child_Chat_Again", Baloon_Img_Position.transform);  
            Set_Data.Ins.On_Set_Data_Non_Mono_Inc_By_Name ("Coin", 500);
        } else if (Event == "Child_Give_1000_Coin") {
           // Kumpulan_Child_Give.On_Check_All_Object_Requirements ();
           
            string Isi = Kumpulan_Child_Give.On_Get_Object(2).GetComponent <Object_Data> ().On_Get_A_String ()[0];
            All_Scene_Go_Script.Ins._Baloon_Dialog.On_Call_Baloon_Dialog (Isi,"Can_Child_Chat_Again", Baloon_Img_Position.transform);
           Set_Data.Ins.On_Set_Data_Non_Mono_Inc_By_Name ("Coin", 1000); 
        }
    }

}
