using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Starsky;
using UnityEngine.Events;
public class Header_Canvas : MonoBehaviour {
    
   bool b_Create_Header = false;
    [SerializeField]
    Transform Layout_Currency;
    [SerializeField]
    Transform Layout_Option;
    [SerializeField]
    public GameObject Bg_Calendar;
    #region Finish_Load
    // Character_Status_Sumber
    public void On_Finish_Load () {
        Bg_Calendar.SetActive (true);
    }
    #endregion
   // Home_Scene : 
   public void On_Header () {
       if (!b_Create_Header) {
            b_Create_Header = true;

            /*
            GameObject Form_Sample = GameObject.Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_2"));
            Form_Sample.transform.SetParent (Layout_Currency);
            
            Form_Sample.gameObject.SetActive (true);
            
            GetComponentByName Gb = new GetComponentByName ();
            Type s = Gb.On_Get_Name ("Form_2");
            if (s!= null) {
                Component component = GetComponent(s);

                Call_Method_Type Cm = new Call_Method_Type ();
                Cm.On_Call_Method (component,s,"On_Set_Form_Img", new Type[] { typeof(Sprite)}, new object[] {All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name ("Coin_Sprite")});
                Cm.On_Call_Method (component,s,"On_Set_Isi", new Type[] { typeof(string)}, new object[] {"0"});
        
            }
            */
            Dict_Star_GameObject_Value = new Dictionary<string, Star_GameObject> ();
            On_Load_Star_GameObject_Value ();

            Star_GameObject St = new Star_GameObject();
            St.On_Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_2"),Layout_Currency, true);       
            St.On_Input_Method ("Form_2","On_Set_Form_Img",new Type[] { typeof(Sprite)}, new object[] {All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name ("Coin_Sprite")});
            Dict_Star_GameObject_Value.Add ("Coin", St);
          ////  On_Call_Set_Star_GameObject ("Coin", new object [] {"0"});

            St = new Star_GameObject();
            St.On_Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_3"),Layout_Currency, true);      
            St.On_Input_Method ("Add_Check_Quantity","On_Set_Code_Quantity",new Type[] { typeof(int)}, new object[] {3});
            St.On_Input_Method ("Form_3","On_Set_Form_Img",new Type[] { typeof(Sprite)}, new object[] {All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name ("Hp_Sprite")});
           // St.On_Input_Method ("Form_3","On_Set_Isi",new Type[] { typeof(int), typeof(int)}, new object[] {75,100});
            Dict_Star_GameObject_Value.Add ("Hp", St);

           ////  On_Call_Set_Star_GameObject ("Hp", new object [] {75,100});
             St = new Star_GameObject();
            St.On_Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_3"),Layout_Currency, true);       
            St.On_Input_Method ("Add_Check_Quantity","On_Set_Code_Quantity",new Type[] { typeof(int)}, new object[] {4});
            St.On_Input_Method ("Form_3","On_Set_Form_Img",new Type[] { typeof(Sprite)}, new object[] {All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name ("Mp_Sprite")});
            Dict_Star_GameObject_Value.Add ("Mp", St);
            
            St = new Star_GameObject();
            St.On_Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_3"),Layout_Currency, true);  
            St.On_Input_Method ("Add_Check_Quantity","On_Set_Code_Quantity",new Type[] { typeof(int)}, new object[] {2});    
            St.On_Input_Method ("Form_3","On_Set_Form_Img",new Type[] { typeof(Sprite)}, new object[] {All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name ("Stress_Sprite")});
            Dict_Star_GameObject_Value.Add ("Cur_Stress", St);
           //// On_Call_Set_Star_GameObject ("Mp", new object [] {100,100});
            if (Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ().Count > 0) {
           On_Call_Set_Star_GameObject ("Coin", new object [] {Home_Scene.Ins._Character_Status_Sumber._Status_Universal.Coin.ToString ()});
            On_Call_Set_Star_GameObject ("Mp", new object [] {Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0].Cur_Mp, Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0].Max_Mp});
            On_Call_Set_Star_GameObject ("Hp", new object [] {Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0].Cur_Hp, Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0].Max_Hp});
            On_Call_Set_Star_GameObject ("Cur_Stress", new object [] {Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0].Cur_Stress, Home_Scene.Ins._Character_Status_Sumber.On_Get_L_Player_Character_Status_1 ()[0].Max_Stress});

            }

            
           //// On_Call_Set_Star_GameObject ("Mp", new object [] {100,100});
            
       }
   }
   #region Star_GameObject_Value
   Dictionary <string, Star_GameObject> Dict_Star_GameObject_Value = new Dictionary<string, Star_GameObject> ();
   Dictionary <string, UnityAction <object[]>> Dict_Set_Star_GameObject = new Dictionary<string, UnityAction<object[]>> ();
    void On_Load_Star_GameObject_Value () {
         Dict_Set_Star_GameObject = new Dictionary<string, UnityAction<object[]>> ();

        Dict_Set_Star_GameObject.Add ("Coin", On_Set_Coin);
        Dict_Set_Star_GameObject.Add ("Hp", On_Set_Hp);
        Dict_Set_Star_GameObject.Add ("Mp", On_Set_Mp);
        Dict_Set_Star_GameObject.Add ("Cur_Stress", On_Set_Stress);
    }

    // Character_Status_Sumber :
    public void On_Call_Set_Star_GameObject (string Title, object [] objects) {
        Dict_Set_Star_GameObject[Title] (objects);
    }
    #region Set_Star_GameObject
    void On_Set_Coin (object [] objects) {
       // Debug.LogError ("Coin 2");
        Dict_Star_GameObject_Value["Coin"].On_Input_Method ("Form_2","On_Set_Isi",new Type[] { typeof(string)}, objects);
    }
    
    void On_Set_Hp (object [] objects) {
        Dict_Star_GameObject_Value["Hp"].On_Input_Method ("Form_3","On_Set_Isi",new Type[] { typeof(int), typeof(int)}, objects);
    }

    void On_Set_Mp (object [] objects) {
        Dict_Star_GameObject_Value["Mp"].On_Input_Method ("Form_3","On_Set_Isi",new Type[] { typeof(int), typeof(int)}, objects);
    }

    void On_Set_Stress (object [] objects) {
        Dict_Star_GameObject_Value["Cur_Stress"].On_Input_Method ("Form_3","On_Set_Isi",new Type[] { typeof(int), typeof(int)}, objects);
    }
    #endregion
   #endregion
   void Off_Header () {
        if (b_Create_Header) {
            b_Create_Header = false;
        }
   }
}
