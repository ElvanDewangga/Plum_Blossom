using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String_Change_String : MonoBehaviour {
    Dictionary <string, string> Dict_String = new Dictionary<string, string> ();
   #region Pengubah_String
    
    public void CustomStart () {
       // base.CustomStart ();
        Dict_String = new Dictionary<string, string> ();
        Dict_String.Add ("Gender", "Enter your gender (Fs)");
        Dict_String.Add ("Name", "Enter your name (Fs)");
        Dict_String.Add ("Birthday", "Enter your birthday (Fs)");
        Dict_String.Add ("Child_Gender", "Enter your child gender (Fs)");
        Dict_String.Add ("Child_Name", "Enter your child name (Fs)");
        Dict_String.Add ("Child_Birthday", "Enter your child birthday (Fs)");
        Dict_String.Add ("Child_Blood_Type", "Enter your child blood type (Fs)");
        
    }
    
 
    #endregion
    #region Implementation
    // TMP_Text_Pengubah_Text
    public string On_Change_String (string bal) {
       if (Dict_String.ContainsKey(bal)) {
            return Dict_String[bal];
        }
        else {
            return bal;
        }
    }
    #endregion
}
