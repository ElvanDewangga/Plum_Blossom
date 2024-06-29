using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
public class Plum_Blossom_Data
{
    // Character_Status_Sumber_Utama :
    public int Day;
    public int Month;
    public int Year;
    public string Season; // "Spring", "Summer", "Autumn", "Winter"
    public int First_Home = 0;
    public int Coin = 0;
    public string Hari = "";
    // END

    

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

    #region Part_Time_Job_Utama
    // Part_Time_Job_Utama : (Selected_Button_Data)
    public string[] Plan_Monday;
    public string[] Plan_Tuesday;
    public string[] Plan_Wednesday;
    public string[] Plan_Thursday;
    public string[] Plan_Friday;
    public string[] Plan_Saturday;
    
    
    void On_Save_Part_Time_job () {
        Part_Time_Job_Utama Ptj = Home_Scene.Ins._Part_Time_Job_Utama;
        Plan_Monday = Ptj.A_Plan_Day[0].A_String;
        Plan_Tuesday = Ptj.A_Plan_Day[1].A_String;
        Plan_Wednesday = Ptj.A_Plan_Day[2].A_String;
        Plan_Thursday = Ptj.A_Plan_Day[3].A_String;
        Plan_Friday = Ptj.A_Plan_Day[4].A_String;
        Plan_Saturday = Ptj.A_Plan_Day[5].A_String;
    }


    void On_Load_Part_Time_Job (Plum_Blossom_Data loadedData) {
        Plan_Monday = loadedData.Plan_Monday;
        Plan_Tuesday = loadedData.Plan_Tuesday;
        Plan_Wednesday = loadedData.Plan_Wednesday;
        Plan_Thursday = loadedData.Plan_Thursday;
        Plan_Friday = loadedData.Plan_Friday;
        Plan_Saturday = loadedData.Plan_Saturday;
    }
    #endregion

   // public Character_Status_1 _Character_Status_1;
   /*
    public Plum_Blossom_Data(Character_Status_1 _Character_Status_1_V)
    {
        // _Character_Status_1 = _Character_Status_1_V;
    }
    */
    #region Cur_Slot
    int Cur_Slot = 0;
    #endregion
    
    /*
    public void On_Save () {
        // Simpan data permainan
        Plum_Blossom_Data player1Data = new Plum_Blossom_Data(1, "Player1",0, "",new Character_Status_1 ());
        Json_Plum_Blossom.GameSaveSystem.SaveGame(Cur_Slot, player1Data);
    }
    */

    public void On_Set_Field (string Field_Name, object Value) { // First_Home
        Fungsi_Umum Fu = new Fungsi_Umum ();
        Fu.On_Set_Field (this, Field_Name, Value);
    }

    // Data_Slot_System :
    public void On_Save (int Cur_Slot, Character_Status_1 Cs) {
        On_Save_Part_Time_job ();

        Character_Status_Sumber Sumber = Home_Scene.Ins._Character_Status_Sumber;
        Day = Sumber._Status_Universal.Day;
        Month = Sumber._Status_Universal.Month;
        Year = Sumber._Status_Universal.Year;
        Season = Sumber._Status_Universal.Season;
        Coin = Sumber._Status_Universal.Coin;
        Hari = Sumber._Status_Universal.Hari;

        Strength = Cs.Strength; Stamina = Cs.Stamina; Agility = Cs.Agility; Intelligence = Cs.Intelligence;
        Charisma = Cs.Charisma; Faith = Cs.Faith; Darkness = Cs.Darkness; Luck = Cs.Luck; Cooking = Cs.Cooking; Crafting = Cs.Crafting;

        Cur_Hp = Cs.Cur_Hp; Max_Hp = Cs.Max_Hp; Cur_Mp = Cs.Cur_Mp; Max_Mp = Cs.Max_Mp;
        Cur_Stress = Cs.Cur_Stress; Max_Stress = Cs.Max_Stress;
        Affection = Cs.Affection;
        Child_Age = Cs.Child_Age;
        Gender = Cs.Gender; Name = Cs.Name; Birthday_Month = Cs.Birthday_Month; Birthday_Day = Cs.Birthday_Day;
        Child_Gender = Cs.Child_Gender; Child_Name = Cs.Child_Name; Child_Birthday_Month = Cs.Child_Birthday_Month;
        Child_Birthday_Day = Cs.Child_Birthday_Day; Child_Blood_Type = Cs.Child_Blood_Type;
        // Simpan data permainan
       //  Plum_Blossom_Data player1Data = new Plum_Blossom_Data(1, "Player1",First_Home_Menu, Child_Name,Cs);
        Plum_Blossom_Data player1Data = this;
        Json_Plum_Blossom.GameSaveSystem.SaveGame(Cur_Slot, player1Data);
        
    }
    
    // Data_Slot_Canvas :
    public Plum_Blossom_Data On_Load (int Cur_Slot) {
         // Muat data permainan
        Plum_Blossom_Data loadedData = Json_Plum_Blossom.GameSaveSystem.LoadGame(Cur_Slot);
        if (loadedData != null)
        {
            On_Load_Part_Time_Job (loadedData);
            // Blm pernah diinput datanya :
           if (loadedData.Year ==0) {loadedData.Year = 2232;}
           if (loadedData.Month == 0) {loadedData.Month = 1;}
           if (loadedData.Day == 0) {loadedData.Day = 1;} 
           
           if (loadedData.Season == "") {
                Convert_Season Cv = new Convert_Season ();
                loadedData.Season = Cv.GetSeason (loadedData.Day, loadedData.Month);
            } 
            if (loadedData.Hari == "") {
                loadedData.Hari = "Sunday";
            }
           if (loadedData.Day == 0) {loadedData.Day = 1;} 
         //   Debug.Log ("Load " + Cur_Slot);
           
        }
        return loadedData;
    }    
    
    #region Convert_Data_To_Status_Universal (Character_Status_Sumber)
    // Data_Slot_Canvas :
    public Character_Status_Sumber.Status_Universal On_Convert_Data_To_Status_Universal(Plum_Blossom_Data Data) {
        Character_Status_Sumber.Status_Universal Res = new Character_Status_Sumber.Status_Universal ();
        Res.Year = Data.Year;
        Res.Month = Data.Month;
        Res.Day = Data.Day;
        Res.Season = Data.Season;
        Res.First_Home = Data.First_Home;
        Res.Coin = Data.Coin;
        Res.Hari = Data.Hari;
        return Res;
    }
    #endregion

    #region Convert_Data_To_Character_Status_1
    // Data_Slot_Canvas - Character_Status_Sumber : 
    public void On_Convert_Data_To_Character_Status_1 (Plum_Blossom_Data Data, Character_Status_1 Res) {

        Res.On_Set_Field ("Strength", Strength);
        Res.On_Set_Field ("Stamina", Stamina);
        Res.On_Set_Field ("Agility", Agility);
        Res.On_Set_Field ("Intelligence", Intelligence);
        Res.On_Set_Field ("Charisma", Charisma);
        Res.On_Set_Field ("Faith", Faith);
        Res.On_Set_Field ("Darkness", Darkness);
        Res.On_Set_Field ("Luck", Luck);
        Res.On_Set_Field ("Cooking", Cooking);
        Res.On_Set_Field ("Crafting", Crafting);
        Res.On_Set_Field ("Inspection", Inspection);
        Res.On_Set_Field ("Apothecary", Apothecary);
        Res.On_Set_Field ("Taming", Taming);
        Res.On_Set_Field ("Magic", Magic);
        Res.On_Set_Field ("Weapons", Weapons);
        Res.On_Set_Field ("Spells", Spells);

        Res.On_Set_Field ("Cur_Hp", Data.Cur_Hp);
        Res.On_Set_Field ("Max_Hp", Data.Max_Hp);
        Res.On_Set_Field ("Cur_Mp", Data.Cur_Mp);
        Res.On_Set_Field ("Max_Mp", Data.Max_Mp);
        Res.On_Set_Field ("Cur_Stress", Data.Cur_Stress);
        Res.On_Set_Field ("Max_Stress", Data.Max_Stress);
        Res.On_Set_Field ("Affection", Data.Affection);

        Res.On_Set_Field ("Gender", Data.Gender);
        Res.On_Set_Field ("Name", Data.Name);
        Res.On_Set_Field ("Birthday_Month", Data.Birthday_Month);
        Res.On_Set_Field ("Birthday_Day", Data.Birthday_Day);

        Res.On_Set_Field ("Child_Age", Data.Child_Age);
        Res.On_Set_Field ("Child_Gender", Data.Child_Gender);
        Res.On_Set_Field ("Child_Name", Data.Child_Name);
        Res.On_Set_Field ("Child_Birthday_Month", Data.Child_Birthday_Month);
        Res.On_Set_Field ("Child_Birthday_Day", Data.Child_Birthday_Day);
        Res.On_Set_Field ("Child_Blood_Type", Data.Child_Blood_Type);

       // Debug.LogError (Res.Max_Hp);
    }
    #endregion
    #region Dict_Data
    Dictionary <string, string[]> Dict_A_String = new Dictionary<string, string[]> ();
    bool b_On_Load_Dict_Data = false;
    void On_Load_Dict_Data () {
        Dict_A_String = new Dictionary<string, string[]> ();
        Dict_A_String.Add ("Plan_Monday", Plan_Monday);
        Dict_A_String.Add ("Plan_Tuesday", Plan_Tuesday);
        Dict_A_String.Add ("Plan_Wednesday", Plan_Wednesday);
        Dict_A_String.Add ("Plan_Thursday", Plan_Thursday);
        Dict_A_String.Add ("Plan_Friday", Plan_Friday);
        Dict_A_String.Add ("Plan_Saturday", Plan_Saturday);
    }
    
    void Example_On_Get_Data () {
        Plum_Blossom_Data Data = All_Scene_Go_Script.Ins._Data_Slot_Canvas.Target_Plum_Blossom_Data;
        Data.On_Get_Data ("Plum_Monday");
    }
    //--- Selected_Button_Data :
    public string [] On_Get_Data (string val) {
        if (!b_On_Load_Dict_Data) {
            b_On_Load_Dict_Data = true;
            On_Load_Dict_Data ();
        }
        return Dict_A_String [val];
    }
    #endregion
    
}
