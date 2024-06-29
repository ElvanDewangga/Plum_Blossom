using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Convert_Season 
{
    public int day;
    public int month;

    void On_Example_Get_Season()
    {
        string season = GetSeason(day, month);
        Debug.Log("Season: " + season);
    }

    // Plum_Blossom_Data :
    public string GetSeason(int day, int month)
    {
        // Verifikasi validitas tanggal dan bulan
        if (month < 1 || month > 12 || day < 1 || day > DateTime.DaysInMonth(DateTime.Now.Year, month))
        {
            return "Invalid date";
        }

        // Tentukan musim berdasarkan tanggal dan bulan
        if ((month == 3 && day >= 21) || (month > 3 && month < 6) || (month == 6 && day < 21))
        {
            return "Spring";
        }
        else if ((month == 6 && day >= 21) || (month > 6 && month < 9) || (month == 9 && day < 23))
        {
            return "Summer";
        }
        else if ((month == 9 && day >= 23) || (month > 9 && month < 12) || (month == 12 && day < 21))
        {
            return "Autumn";
        }
        else
        {
            return "Winter";
        }
    }
}
