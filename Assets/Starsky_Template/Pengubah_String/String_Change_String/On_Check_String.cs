using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Check_String : MonoBehaviour {
     string On_Check_Space (string V) {
        string Result = "";
        if (V != "") {

            char[] A_Text = V.ToCharArray();

            int i = 0;
            for (i=0; i < A_Text.Length; i++) {
                if (A_Text[i] == ' ') {A_Text[i] = '_';}
            }

            // Tar.text = "";
            int j = 0;
            for (j=0; j < A_Text.Length; j++) {
                Result = Result + A_Text[j];
            }
        }
        return Result;
    }

    string On_Check_Char (string Kalimat, char Find_Char, char Replace_Char) {
        string Result = "";
        if (Kalimat != "") {

            char[] A_Text = Kalimat.ToCharArray();

            int i = 0;
            for (i=0; i < A_Text.Length; i++) {
                if (A_Text[i] == Find_Char) {A_Text[i] = Replace_Char;}
            }

            // Tar.text = "";
            int j = 0;
            for (j=0; j < A_Text.Length; j++) {
                Result = Result + A_Text[j];
            }
        }
        return Result;
    }
}
