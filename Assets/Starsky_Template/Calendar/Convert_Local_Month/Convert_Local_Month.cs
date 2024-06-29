using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convert_Local_Month {
    #region Get_Month_Name
    // Sample_Scene :
    public string On_Get_Month_Name (int b) {
        string Res = "";
        if (b==1) {Res = "January";}
        else if (b==2) {Res = "February";}
        else if (b==3) {Res = "March";}
        else if (b==4) {Res = "April";}
        else if (b==5) {Res = "May";}
        else if (b==6) {Res = "June";}
        else if (b==7) {Res = "July";}
        else if (b==8) {Res = "August";}
        else if (b==9) {Res = "September";}
        else if (b==10) {Res = "October";}
        else if (b==11) {Res = "November";}
        else if (b==12) {Res = "December";}
        return Res;
    }
    #endregion
    #region Get_Total_Day
    // Sample_Scene :
    public int On_Get_Total_Day (int b) {
        int Res = 0;
        if (b==1) {Res = 31;}
        else if (b==2) {Res = 28;}
        else if (b==3) {Res = 31;}
        else if (b==4) {Res = 30;}
        else if (b==5) {Res = 31;}
        else if (b==6) {Res = 30;}
        else if (b==7) {Res = 31;}
        else if (b==8) {Res = 31;}
        else if (b==9) {Res = 30;}
        else if (b==10) {Res = 31;}
        else if (b==11) {Res = 30;}
        else if (b==12) {Res = 31;}
     
        return Res;
    }
    #endregion
    #region Get_Month_Day
    void On_Example_Get_Month_Day () {
        string date = "August,5";
        
        // Panggil method untuk memisahkan string
        On_Get_Month_Day(date, out string month, out int day);

        // Tampilkan hasil
        Debug.Log($"Month: {month}, Day: {day}");
    }
    
    public void On_Get_Month_Day (string date, out string month, out int day)
    {
        // Pisahkan string berdasarkan koma
        string[] parts = date.Split(',');

        // Asumsikan bahwa string selalu memiliki dua bagian
        month = parts[0];
        day = int.Parse(parts[1]);
    }
    #endregion
}
