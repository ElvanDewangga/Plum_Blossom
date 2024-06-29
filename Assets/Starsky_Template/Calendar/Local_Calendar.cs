using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_Calendar : MonoBehaviour {
    #region Calendar_Data
    public int Day;
    public int Month;
    public int Year;
    public string Hari;
    
    //Character_Status_Sumber :
    public void On_Get_Calendar_Data (Character_Status_Sumber.Status_Universal Cs) {
        Day = Cs.Day;
        Month = Cs.Month;
        Year = Cs.Year;
        Hari = Cs.Hari;

    }

    void On_Send_Calendar_Data () {
        
        Home_Scene.Ins._Character_Status_Sumber.On_Get_Local_Calendar (Day,Month,Year,Hari);
    }
    #endregion
    #region On_Next_Day
    // Kegiatan_Home :
    public void On_Next_Day () {
         Day++;
        
        if (Day > GetDaysInMonth(Month)) {
            Day = 1;
            Month++;
            
            if (Month > 12) {
                Month = 1;
                Year++;
            }
        }

        // Update the day name (Hari) based on the new date
        Next_Hari();

        On_Send_Calendar_Data ();
    }    
    #endregion
    #region GetDaysInMonth
    private int GetDaysInMonth(int month) {
        switch (month) {
            case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                return 31;
            case 4: case 6: case 9: case 11:
                return 30;
            case 2:
                return 28; // Tidak perlu leap year
            default:
                Debug.LogError ("Bulan invalid");
                return 0;
        }
    }
    #endregion
    #region UpdateHari
    private static readonly string[] HariIndonesia = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

    private void Next_Hari() {
       int y = -1;
       foreach (string h in HariIndonesia) {
            y++;
            if (Hari == h) { 
                break;
            }
       }
       if (y+1 >= HariIndonesia.Length) {
        y =-1;
       }
       Hari = HariIndonesia[y+1];

    }
    #endregion
}

