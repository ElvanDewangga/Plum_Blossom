using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Profile_Friend_Label : MonoBehaviour {
    [SerializeField]
    TMP_Text Form_1_Name;
    [SerializeField]
    TMP_Text Form_1_Age;
    [SerializeField]
    TMP_Text Form_1_Birthday;
    [SerializeField]
    TMP_Text Form_1_Blood_Type;
    [SerializeField]
    TMP_Text Note_Tx;
    [SerializeField]
    Image Avatar_Img;
    // Profile :
    public void On_Input_Form_1 (Character_Asset ss) {
        string Name_V = ss.Character_Name;
        int Age = ss.Age;
        string Birthday_Month = ss.Birthday_Month;
        int Birthday_Day = ss.Birthday_Day;
        Form_1_Name.text = ss.Character_Name;
        Form_1_Age.text = ss.Age.ToString ();
        Form_1_Birthday.text = (ss.Birthday_Month + ", " + ss.Birthday_Day.ToString ());
        Form_1_Blood_Type.text = ss.Blood_Type;
        Note_Tx.text = ss.Informasi_Singkat;
        Avatar_Img.sprite = ss.On_Get_C_Expression ("Avatar").Sprite;
    }
}
