using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TMP_Text_Pengubah_Text : MonoBehaviour {
    // Form_1 :
    public void On_Change_Text (TMP_Text tp) {
        tp.text = All_Scene_Go_Script.Ins._Pengubah_String._TMP_Text_Pengubah_Text_Sumber.On_TMP_Text_Pengubah_Text (tp.text);
    }
}
