using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form_Show : MonoBehaviour {
    public Form_Show_Label _Form_Show_Label;
    [System.Serializable]
    public class Form_Id {
        public int Id ;
        public Form_String _Form_String;
    }

    [System.Serializable]
    public class Form_String {
        public string Title ;
        public string Isi ;

        // Constructor to initialize properties
        public Form_String(int id, string title, string isi) {
          //  Id = id;
            Title = title;
            Isi = isi;
          //  Debug.Log (id + title + isi);
        }
    }
    [SerializeField]
    List <Form_Id> L_Form_Id = new List <Form_Id> ();
    
    //C Character_Status_Sumber :
    public List <Form_Id> On_Get_L_Form_Id () {
        return L_Form_Id;
    }

    // Sample_Scene :
    public void On_Refresh_Form () {
        L_Form_Id = new List <Form_Id> ();
    }
    #region Implementation
    // Sample_Scene
    public void On_Add_Form_String (string Title, string Isi) {
        Form_Id idx = new Form_Id ();
        Form_String F = new Form_String (L_Form_Id.Count, Title, Isi);
        idx._Form_String = F;
        bool b_Check_Same = On_Check_Same_Form_Title (idx);
        if (!b_Check_Same) {
            L_Form_Id.Add (idx);
        }
        
    }

    bool On_Check_Same_Form_Title (Form_Id _Form_Id) {
        bool Res = false;
        int Val = -1;
        foreach (Form_Id x in L_Form_Id) {
            Val++;
            if (x._Form_String.Title.Equals (_Form_Id._Form_String.Title)) {
                L_Form_Id[Val] = _Form_Id;
                Res = true;
                break;
            }
        }
        return Res;
    }
    
    #endregion
    #region Show_The_Form
    
    // Sample_Scene
    public void On_Show_The_Form (Panel_Form_Show Ps, string Type_Form, int From, int To) {
        int x = From;
        for (x = From; x <= To; x++) {
            Ps.On_Add_Form_Show (Type_Form, L_Form_Id[x]._Form_String.Title, L_Form_Id[x]._Form_String.Isi);
        }
    }

    // Sample_Scene
    public void Off_Show_The_Form (Panel_Form_Show Ps) {
       if (Ps.GetComponent <Panel_Destroyer> () != null) {
            Panel_Destroyer Be = Ps.GetComponent <Panel_Destroyer> ();
            Be.On_Destroy_All_Clone ();
       }
    }
    #endregion
    
}
