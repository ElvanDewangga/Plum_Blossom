using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Form_2 : MonoBehaviour {
    [SerializeField]
    Image Form_Img;
    [SerializeField]
    TMP_Text _Tmp_Isi;
    #region InitializationManager
    
    void Awake () {
       // Form_Img = this.gameObject.transform.Find ("Form_Img").GetComponent <Image> ();
      //  _Tmp_Isi = this.gameObject.transform.Find ("TMP_Isi").GetComponent <TMP_Text> ();
    }
    
    #endregion
    public void On_Set_Form_Img (Sprite Sp) {
        Form_Img.sprite = Sp;
    }

    public void On_Set_Isi (string v) {
        _Tmp_Isi.text = v;
        /*
        if (_Tmp_Isi.GetComponent<TMP_Text_Pengubah_Text> () != null) {
            _Tmp_Isi.GetComponent<TMP_Text_Pengubah_Text> ().On_Change_Text (_Tmp_Isi);
        }
        */
    }
}
