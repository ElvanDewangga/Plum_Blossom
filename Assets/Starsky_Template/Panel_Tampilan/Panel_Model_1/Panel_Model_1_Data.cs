using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Model_1_Data : MonoBehaviour {
    [SerializeField]
    List<Field_1> L_Effect_Field_1 = new List<Field_1>();
    // Plum_Blossom_Show_Kegiatan :
    public List<Field_1> On_Get_List_Field_1 () {
        return L_Effect_Field_1;
    }
    [SerializeField]
    public string Title;
    [SerializeField]
    public int Coin;
    [Header ("Variant Random Coin : 0 jika tidak dipakai. Jika ini dipakai maka Coin set ke 0")]
    [SerializeField]
    public int Min_Coin, Max_Coin;
    Panel_Model_1 _Panel_Model_1;
    Panel_Model_1_1 _Panel_Model_1_1;
    void Start () {
        if (this.GetComponent <Panel_Model_1> () != null) {
        _Panel_Model_1 = this.GetComponent <Panel_Model_1> ();
        _Panel_Model_1.On_Get_Data (Title,L_Effect_Field_1, Coin, Min_Coin, Max_Coin);
        }
        if (this.GetComponent <Panel_Model_1_1> () != null) {
            _Panel_Model_1_1 = this.GetComponent <Panel_Model_1_1> ();
        _Panel_Model_1_1.On_Get_Data (Title,L_Effect_Field_1, Coin, Min_Coin, Max_Coin);
        }
        
    }

    
    #region Start_Event
    /*
    [SerializeField]
    string Start_Event = "";
    void On_Start_Event () {
        if (Start_Event == "Add_To_Part_Time_job_Utama") {
            Home_Scene.Ins._Part_Time_Job_Utama.On_Add_Panel_Model_1_Data (this);
        }
    }
    */
    #endregion
}
