using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Form_1 :Custom_Initialization {
    [SerializeField]
    public static  TMP_Text _Tmp_Field;
    [SerializeField]
    public static TMP_Text _Tmp_Isi;
    #region InitializationManager
    /*
    public override void CustomAwake () {
        base.CustomAwake ();
        _Tmp_Field = this.gameObject.transform.Find ("TMP_Field").GetComponent <TMP_Text> ();
        _Tmp_Isi = this.gameObject.transform.Find ("TMP_Isi").GetComponent <TMP_Text> ();
    }
    */
    
    void Awake () {
        _Tmp_Field = this.gameObject.transform.Find ("TMP_Field").GetComponent <TMP_Text> ();
        _Tmp_Isi = this.gameObject.transform.Find ("TMP_Isi").GetComponent <TMP_Text> ();
    }
    
    #endregion

    public static void On_Set (string v, string v2) {
        _Tmp_Field.text = v; _Tmp_Isi.text = v2;
        if (_Tmp_Field.GetComponent<TMP_Text_Pengubah_Text> () != null) {
            _Tmp_Field.GetComponent<TMP_Text_Pengubah_Text> ().On_Change_Text (_Tmp_Field);
        }

         if (_Tmp_Isi.GetComponent<TMP_Text_Pengubah_Text> () != null) {
            _Tmp_Isi.GetComponent<TMP_Text_Pengubah_Text> ().On_Change_Text (_Tmp_Isi);
        }
    }
}
