using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Replace_String : MonoBehaviour {
     
    #region Function
    // Regex_Utama :
    public string On_Remove_Space (string v) {
        /*
        char [] Yang_Ingin_Dihilangkan = {' '};
        string Result = v;
        Result = Result.Trim (Yang_Ingin_Dihilangkan);
        Debug.Log (Result);
        */
        string Result = v.Replace (" ", "");
       // Result = Remove_Some_Text (Result);
        return Result;
    
    }

    string Remove_Some_Text (string v) {
        string Result = v;
        Result = Result.Replace ("Syarat", "");
        Result = Result.Replace ("Effect", "");
        Result = Result.Replace ("((", "(");
        Result = Result.Replace ("))", ")");
        return Result;
    
    }

    // Visual_Novel_Canvas :
    public string On_Replace_String (string Kalimat, string Cari, string Pengganti) {
        string Result = Kalimat;
        Result = Result.Replace (Cari, Pengganti);
        return Result;
    }
    #endregion

    
}
