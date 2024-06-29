using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TMP_Text_Pengubah_Text_Sumber : MonoBehaviour {
    Dictionary <string, string> Dict_TMP_Text_Pengubah_Text = new Dictionary<string, string> ();
   #region Pengubah_String
    
    public void CustomStart () {
       // base.CustomStart ();
        Dict_TMP_Text_Pengubah_Text = new Dictionary<string, string> ();
        Dict_TMP_Text_Pengubah_Text.Add ("Child_Gender", "Gender");
        Dict_TMP_Text_Pengubah_Text.Add ("Child_Name", "Name");
        Dict_TMP_Text_Pengubah_Text.Add ("Child_Birthday", "Birthday");
        Dict_TMP_Text_Pengubah_Text.Add ("Child_Blood_Type", "Blood type");
        
    }
    
    
    #endregion
    #region Implementation
    // TMP_Text_Pengubah_Text
    void On_Example () {
        On_TMP_Text_Pengubah_Text ("Child_Gender");
    }
    public string On_TMP_Text_Pengubah_Text (string bal) {
       if (Dict_TMP_Text_Pengubah_Text.ContainsKey(bal)) {
            return Dict_TMP_Text_Pengubah_Text[bal];
        }
        else {
            return bal;
        }
    }
    #endregion
    #region Home_Scene
    // Character_Status_Sumber :
    public void On_Add_Dict_From_Home_Scene () {
        SetDictionaryValue ("Player_Child", Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1()[0].Child_Name);
        SetDictionaryValue ("Player_Caretaker", Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1()[0].Name);
        if (Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1()[0].Gender == "Male") {
            SetDictionaryValue ("Parent_Call", "Daddy");
        } else if (Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1()[0].Gender == "Female") {
            SetDictionaryValue ("Parent_Call", "Mommy");
        }
        
    }
    #endregion
    #region Set_Dictionary_Value
     void SetDictionaryValue(string key, string newValue)
    {
        // Periksa apakah dictionary mengandung kunci yang diberikan
        if (Dict_TMP_Text_Pengubah_Text.ContainsKey(key))
        {
            // Ubah nilai untuk kunci tersebut
            Dict_TMP_Text_Pengubah_Text[key] = newValue;
          //  Debug.Log("Value for " + key + " has been updated to " + newValue);
        }
        else
        {
            Dict_TMP_Text_Pengubah_Text.Add (key, newValue);
         //   Debug.LogWarning("Key " + key + " not found in the dictionary.");
        }
    }
    #endregion
}
