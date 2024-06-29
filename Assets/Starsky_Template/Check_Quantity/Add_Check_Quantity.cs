using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Starsky;
using UnityEngine.Events;
using UnityEngine.UI;
public class Add_Check_Quantity : MonoBehaviour {
    [SerializeField]
    Slider Target_Slider;
    [Tooltip ("Untuk objek yang tidak diinstantiate. Bisa instantiate code langsung disini :")]
    [SerializeField]
    int Code_Quantity;
    Check_Quantity _Check_Quantity;

    #region Add_Code_Quantity
    void On_Example_On_Set_Code_Quantity () {
        /*
        Star_GameObject St = new Star_GameObject();
        St = new Star_GameObject();
            St.On_Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_3"),Layout_Currency, true);       
            St.On_Input_Method ("Add_Check_Quantity","On_Set_Code_Quantity",new Type[] { typeof(int)}, new object[] {4});
            St.On_Input_Method ("Form_3","On_Set_Form_Img",new Type[] { typeof(Sprite)}, new object[] {All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name ("Mp_Sprite")});
            Dict_Star_GameObject_Value.Add ("Mp", St);
            */
    }
    // Header_Canvas :
    public void On_Set_Code_Quantity (int Code_Quantity_V) {
        // panggil ini sebelum menyalakan set Active :
      //  Debug.Log (Code_Quantity_V);
        Code_Quantity = Code_Quantity_V;
        On_Start ();
    }
    #endregion
    void On_Start () {
        if (_Check_Quantity == null) {_Check_Quantity = Home_Scene.Ins._Check_A_Quantity.On_Get_Check_Quantity (Code_Quantity);}
        _Check_Quantity.On_Add_Max_Slider (Target_Slider);
    }
}
