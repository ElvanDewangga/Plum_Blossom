using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Asset : MonoBehaviour {
    public string Character_Code;
    public string Character_Name;
    [System.Serializable]
    public class C_Expression {
        public string Title;
        public Sprite Sprite;
    }

    [SerializeField]
    C_Expression [] A_C_Expression;
    
    public C_Expression On_Get_C_Expression (string Style_V) {
        C_Expression Res = null ;
        Res = A_C_Expression[0];
        foreach (C_Expression s in A_C_Expression) {
            if (s.Title == Style_V) {
                Res = s;
                break;
            }
        } 

        return Res;
    }
    #region Information
    public int Age;
    public string Gender;
    public string Birthday_Month;
    public int Birthday_Day;
    public string Blood_Type;
    public string Informasi_Singkat;
    #endregion
}
