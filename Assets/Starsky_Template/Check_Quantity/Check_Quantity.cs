using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check_Quantity : MonoBehaviour {
    [SerializeField]
    bool b_Using_Min_Quantity = false;
    [SerializeField]
    float Min_Quantity;

    [SerializeField]
    bool b_Using_Max_Quantity = false;
    [SerializeField]
    float Max_Quantity;
    [Tooltip ("Tidak harus diisi : untuk yang memiliki Max Target dinamis")]
    [SerializeField]
    Slider Max_Slider;
    #region Add_Check_Quantity
    public void On_Add_Max_Slider (Slider s) {
        Max_Slider= s;
    }
    #endregion
    #region Implementation
    void On_Example_On_Check_Quantity () {
        Home_Scene.Ins._Check_A_Quantity.On_Check_Quantity ("Affection", 200);
    }
    // Set_Data :
    public int On_Check_Quantity (int Quantity_Saat_Ini) {
        int Res = Quantity_Saat_Ini;
        if (b_Using_Min_Quantity) {
            if (Res < Min_Quantity) {
                Res = (int)Min_Quantity;
            }
        }

        if (b_Using_Max_Quantity) {
            if (Max_Slider != null) {
                Max_Quantity = Max_Slider.maxValue;
            }
            if (Res > Max_Quantity) {
                Res = (int)Max_Quantity;
            }
        }
        return Res;
    }

    #endregion
}
