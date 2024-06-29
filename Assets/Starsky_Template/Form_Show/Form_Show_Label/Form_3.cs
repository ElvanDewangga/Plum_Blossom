using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Form_3 : MonoBehaviour {
    public Image Form_Img;
    public Slider _Point_Bar;
    [SerializeField]
    TMP_Text _Tmp_Isi;
    #region InitializationManager
    
    void Awake () {
        /*
        Form_Img = this.gameObject.transform.Find ("Form_Img").GetComponent <Image> ();
        _Point_Bar = this.gameObject.transform.Find ("Point_Bar").GetComponent<Slider> ();
    //    _Tmp_Isi = this.gameObject.transform.Find ("TMP_Isi").GetComponent <TMP_Text> ();
    */
    }
    
    #endregion
    public void On_Set_Form_Img (Sprite Sp) {
         Form_Img.sprite = Sp;
    }

    public void On_Set_Isi (int Cur_Value, int Max_Value) {
        _Point_Bar.maxValue = Max_Value;
        _Point_Bar.value = Cur_Value; 
        string Isian = "<size=40>" + Cur_Value.ToString () + " / </size=40>" + "<size=28>" + Max_Value.ToString () + "</size=28>";
        _Tmp_Isi.text = Isian;
        /*
        if (GetComponent <Add_Check_Quantity> ()) {
            On_Add_Check_Quantity ();
        }
        */
    }
    /*
    #region Add_Check_Quantity
    [SerializeField]
    int Code_Quantity;
    void On_Add_Check_Quantity () {
      GetComponent <Add_Check_Quantity> ().On_Set_Code_Quantity (Code_Quantity);  
    }
    #endregion
    */
}
