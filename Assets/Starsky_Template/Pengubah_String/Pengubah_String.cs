using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengubah_String : Custom_Initialization {
    public TMP_Text_Pengubah_Text_Sumber _TMP_Text_Pengubah_Text_Sumber;
    public String_Change_String _String_Change_String;
    public Replace_String _Replace_String;
    public On_Check_String _On_Check_String;
    #region InitializationManager
    
    public override void CustomStart () {
        base.CustomStart ();
        _TMP_Text_Pengubah_Text_Sumber.CustomStart ();
        _String_Change_String.CustomStart ();
        
    }
    
 
    #endregion
}
