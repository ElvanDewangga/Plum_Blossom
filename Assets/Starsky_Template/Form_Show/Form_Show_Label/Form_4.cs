using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Form_4 : MonoBehaviour {
   [SerializeField]
    TMP_Text _Tmp_Field;
    [SerializeField]
    public TMP_Text _Tmp_Isi;
    [SerializeField]
    public TMP_Text _Tmp_Inc;
    
    public void On_Set_Tmp_Field (string Field_V, string Isi_V, string Inc_V) {
        _Tmp_Field.text = Field_V;
        _Tmp_Isi.text = Isi_V;
        _Tmp_Inc.text = Inc_V;
    }
}
