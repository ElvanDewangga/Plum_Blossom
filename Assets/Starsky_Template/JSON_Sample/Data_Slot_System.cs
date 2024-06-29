using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Data_Slot_System : MonoBehaviour {
    [SerializeField]
    int Cur_Slot = 0;
    #region Empty & Not_Empty
    [SerializeField]
    GameObject Empty_Go;
    [SerializeField]
    GameObject Not_Empty_Go;
    
    void On_Empty () {
        Empty_Go.gameObject.SetActive (true);
        Not_Empty_Go.gameObject.SetActive (false);
    }

    void On_Not_Empty () {
        On_Process_Not_Empty ();
        Empty_Go.gameObject.SetActive (false);
        Not_Empty_Go.gameObject.SetActive (true);
        
    }
    #endregion
    #region Click
    public void On_Click () {
        All_Scene_Go_Script.Ins._Data_Slot_Canvas.On_Data_Slot_System (Cur_Slot,this);
    }
    #endregion
    #region Data_Load
    Plum_Blossom_Data loadedData = new Plum_Blossom_Data ();
    // Data_Slot_Canvas :
    public void On_Check_Cur_Slot (int Slot_V) {
        Cur_Slot = Slot_V;
        On_Load_Data ();
    }

    void On_Load_Data () {
        loadedData = loadedData.On_Load(Cur_Slot);
        if (loadedData != null)
        {
            On_Not_Empty ();
//            Debug.Log ("Load " + Cur_Slot);
        } else {
            On_Empty ();
       //     Debug.Log ("Blm ada slot");
        }
    }
    #endregion

    #region Not_Empty
    [SerializeField]
    TMP_Text Calendar_Tx;
    [SerializeField]
    TMP_Text Number_Tx, Your_Name_Tx;
    [SerializeField]
    Image Your_Gender_Img;
    [SerializeField]
    TMP_Text Child_Age_Tx, Child_Name_Tx;
    [SerializeField]
    Image Child_Gender_Img;

    void On_Process_Not_Empty () {
        Convert_Local_Month Cl = new Convert_Local_Month (); 
        Calendar_Tx.text = Cl.On_Get_Month_Name (loadedData.Month) + ", " + loadedData.Day.ToString ();
        Number_Tx.text = Cur_Slot.ToString () + ".";
        Your_Name_Tx.text = loadedData.Name;
        Your_Gender_Img.sprite = All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name (loadedData.Gender + "_Sprite");
        Child_Age_Tx.text = "AGE : " + loadedData.Child_Age.ToString ();
        Child_Name_Tx.text = loadedData.Child_Name;
        Child_Gender_Img.sprite = All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name (loadedData.Gender + "_Sprite");
    }
    #endregion
}
