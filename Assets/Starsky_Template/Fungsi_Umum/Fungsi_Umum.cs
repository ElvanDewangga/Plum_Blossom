using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
public class Fungsi_Umum {
   #region Unity_Action
   // Array_Time_Event :
    public virtual void On_Set_Active (GameObject s, bool v) {
        s.gameObject.SetActive (v);
    }

    // Character_Status_1
    public virtual void On_Set_Field(object obj, string fieldName, object value)
    {
        // Dapatkan tipe objek
        Type type = obj.GetType();

        // Dapatkan informasi field berdasarkan nama
        FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        // Periksa apakah field ditemukan
        if (fieldInfo != null)
        {
            // Atur nilai field
            fieldInfo.SetValue(obj, value);
        }
        else
        {
            Debug.LogError($"Field {fieldName} tidak ditemukan di {type.FullName}");
        }
    }

    void Example_On_Get_Field () {
        // Fungsi_Umum Fu = new Fungsi_Umum ();
        // On_Get_Field (Object_Script_Tujuan, "Nama_Field");
    }
    // Character_Status_1, Selected_Button_Data :
    public virtual object On_Get_Field(object obj, string fieldName)
    {
        object Res = null;
        // Dapatkan tipe objek
        Type type = obj.GetType();

        // Dapatkan informasi field berdasarkan nama
        FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        // Periksa apakah field ditemukan
        if (fieldInfo != null)
        {
            // Atur nilai field
            Res = fieldInfo.GetValue(obj);
        }
        else
        {
            Debug.LogError($"Field {fieldName} tidak ditemukan di {type.FullName}");
        }

        
        return Res;
    }

     public virtual object[] On_Get_Fields(object obj, string fieldNames)
    {
        // Split the comma-separated field names
        string[] fieldNameArray = fieldNames.Split(',');

        object[] results = new object[fieldNameArray.Length];
        
        // Get the type of the object
        Type type = obj.GetType();
        
        for (int i = 0; i < fieldNameArray.Length; i++)
        {
            string fieldName = fieldNameArray[i].Trim();  // Remove any leading/trailing whitespace
            object result = null;
            
            // Get field info based on the name
            FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            if (fieldInfo != null)
            {
                // Get the field value
                result = fieldInfo.GetValue(obj);
            }
            else
            {
                // Try to get property info if field not found
                PropertyInfo propertyInfo = type.GetProperty(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                
                if (propertyInfo != null)
                {
                    // Get the property value
                    result = propertyInfo.GetValue(obj);
                }
                else
                {
                    Debug.LogError($"Field or Property {fieldName} not found in {type.FullName}");
                }
            }
            
            results[i] = result;
        }
        
        return results;
    }
    
   #endregion
}
