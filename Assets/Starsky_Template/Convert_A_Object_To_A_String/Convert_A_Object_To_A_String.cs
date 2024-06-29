using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Convert_A_Object_To_A_String {
        /*
        void Start()
    {
        object[] objectArray = new object[] { 1, "hello", 3.14f, null };
        string[] stringArray = ConvertObjectArrayToStringArray(objectArray);

        foreach (var str in stringArray)
        {
            Debug.Log(str);  // This will log the actual value of each string
        }
    }
        */
        void On_Example () {
            Convert_A_Object_To_A_String Cs = new Convert_A_Object_To_A_String ();
            object[] objectArray = new object[] { 1, "hello", 3.14f, true };
            string[] stringArray = Cs.ConvertObjectArrayToStringArray(objectArray);
        }

        public string[] ConvertObjectArrayToStringArray(object[] objectArray)
        {
            return objectArray.Select(obj => obj?.ToString() ?? string.Empty).ToArray();
        }
    
}
