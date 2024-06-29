using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class TMP_Text_Target : MonoBehaviour {
    TMP_Text _Tmp_Text;
    [SerializeField]
    string Name_Script_Target = "";
    [SerializeField]
    string Code_Field = "";
    GameObject Target_GO;
    Character_Status_1 _Character_Status_1;
    Character_Status_Sumber _Character_Status_Sumber;
  void OnEnable () {
    if (_Tmp_Text == null) {
        _Tmp_Text = this.gameObject.GetComponent <TMP_Text> ();
    }
    if (Name_Script_Target == "Character_Status_1") {
        if (Target_GO == null) {
            Target_GO = Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0].gameObject;
            _Character_Status_1 = Target_GO.GetComponent <Character_Status_1> ();
        }
    } else if (Name_Script_Target == "Direct_Convert") {
        if (Code_Field == "Get_Convert_Child_Birthday") {
            Character_Status_1 Cs = Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0];
            _Tmp_Text.text = Cs.Child_Birthday_Month + ", " + Cs.Child_Birthday_Day.ToString ();
        } 
    } else if (Name_Script_Target == "Character_Status_Sumber") {
        if (Target_GO == null) {
            Target_GO = Home_Scene.Ins._Character_Status_Sumber.gameObject;
            _Character_Status_Sumber = Target_GO.GetComponent <Character_Status_Sumber> ();
        }

        if (Code_Field == "Character_Status_Sumber_On_Get_Day") {
            _Tmp_Text.text = _Character_Status_Sumber._Status_Universal.Day.ToString ();
        }  else if (Code_Field == "Character_Status_Sumber_On_Get_Year_Month") {
            Convert_Local_Month Cv = new Convert_Local_Month ();
            _Tmp_Text.text =  Cv.On_Get_Month_Name(_Character_Status_Sumber._Status_Universal.Month) + ", " + _Character_Status_Sumber._Status_Universal.Year.ToString ();
        } else if (Code_Field == "Character_Status_Sumber_On_Get_Season") {
            _Tmp_Text.text = _Character_Status_Sumber._Status_Universal.Season;
        } else if (Code_Field == "Character_Status_Sumber_On_Get_Hari") {
             _Tmp_Text.text = _Character_Status_Sumber._Status_Universal.Hari;
        }
    }

    if (_Character_Status_1 != null) {
        _Tmp_Text.text = _Character_Status_1.On_Get_Field (Code_Field).ToString ();
    }

  }
}
