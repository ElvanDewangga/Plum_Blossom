using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class System_Requirements {
   public enum Requirements {More_Or_Same, Less_Or_Same}
   [SerializeField]
   Requirements _Requirements;

   [System.Serializable]
    public class C_Cur_Target {
        public int Cur_Int;
        public string Cur_String;

        public int Target_Int;
        public string Target_String;
    }
    #region TMP_Input_Field
   // Input_Field_Umum :
   public enum Input_Field_Requirements_Start{Max_Length}
   [System.Serializable]
    public class C_Input_Field_Requirements_Start :C_Cur_Target {
        public Input_Field_Requirements_Start _Requirements;
    }

   // Input_Field_Umum :
   public void On_Process_Requirements_Start (C_Input_Field_Requirements_Start s, TMP_InputField IF) {
      if (s._Requirements == Input_Field_Requirements_Start.Max_Length) {
         On_Max_Length (s, IF);
      }
   }
   
   void On_Max_Length (C_Input_Field_Requirements_Start s, TMP_InputField IF) {
      IF.characterLimit = s.Target_Int;
   }

      #region Input_Field_Requirements_Bool
         public enum Input_Field_Requirements_Bool {Min_Length}
         [System.Serializable]
         public class C_Input_Field_Requirements_Bool :C_Cur_Target {
            public Input_Field_Requirements_Bool _Requirements;
         }
         // Input_Field_Umum :
         public bool On_Process_Requirements_Bool (C_Input_Field_Requirements_Bool s, TMP_InputField IF) {
            bool Res = true;
            if (s._Requirements == Input_Field_Requirements_Bool.Min_Length) {
               Res = On_Min_Length (s, IF);
            }
            return Res;
         }
         
         bool On_Min_Length (C_Input_Field_Requirements_Bool s, TMP_InputField IF) {
            if (IF.text.Length >= s.Target_Int) {
               return true;
            } else {
               return false;
            }
         }
      #endregion
   #endregion
}
