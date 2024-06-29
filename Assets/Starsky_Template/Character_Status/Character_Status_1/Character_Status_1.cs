using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Status_1 : MonoBehaviour {
    public int Strength, Stamina, Agility, Intelligence, Charisma, Faith, Darkness, Luck, Cooking, Crafting,
    Inspection, Apothecary, Taming, Magic, Weapons, Spells;

    public int Cur_Hp, Max_Hp, Cur_Mp, Max_Mp, Cur_Stress, Max_Stress;
    public int Affection;
    public string Gender;
    public string Name;
    public string Birthday_Month;
    public int Birthday_Day;

    public int Child_Age;
    public string Child_Gender;
    public string Child_Name;
    public string Child_Birthday_Month;
    public int Child_Birthday_Day;
    public string Child_Blood_Type;

    
    // Character_Status_1_Sumber :
    public void On_Set_Field (string Field_Name, object Value) {
        Fungsi_Umum Fu = new Fungsi_Umum ();
       // int.TryParse (Value.ToString (), out int New_Value);
      //  New_Value = Home_Scene.Ins._Check_Quantity_Status.On_Check_Quantity ((int) New_Value);
        Fu.On_Set_Field (this, Field_Name, Value);
       
    }

    // Get_Data :
    public object On_Get_Field (string Field_Name) {
        object Res = null;
        Fungsi_Umum Fu = new Fungsi_Umum ();
        Res = Fu.On_Get_Field (this, Field_Name);
        return Res;
    }
    
    #region Get_Data
    // Character_Status_Sumber :
    public void Get_Data_On_Add_Dict_Object () {
        Get_Data.Ins.On_Add_Dict_Object ("Strength", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Strength", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Stamina", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Stamina", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Agility", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Agility", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Intelligence", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Intelligence", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Charisma", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Charisma", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Faith", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Faith", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Darkness", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Darkness", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Luck", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Luck", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Cooking", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Cooking", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Crafting", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Crafting", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Inspection", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Inspection", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Apothecary", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Apothecary", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Taming", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Taming", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Magic", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Magic", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Weapons", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Weapons", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Spells", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Spells", typeof(Character_Status_1));

        Get_Data.Ins.On_Add_Dict_Object ("Cur_Hp", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Cur_Hp", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Max_Hp", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Max_Hp", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Cur_Mp", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Cur_Mp", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Max_Mp", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Max_Mp", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Cur_Stress", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Cur_Stress", typeof(Character_Status_1));
        Get_Data.Ins.On_Add_Dict_Object ("Max_Stress", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Max_Stress", typeof(Character_Status_1));

        Get_Data.Ins.On_Add_Dict_Object ("Affection", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Affection", typeof(Character_Status_1));

        Get_Data.Ins.On_Add_Dict_Object ("Child_Age", this.gameObject);  Get_Data.Ins.On_Add_Dict_Type ("Child_Age", typeof(Character_Status_1));

    } 

    #endregion
}
