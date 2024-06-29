using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using System;
public class Form_Show_Label : MonoBehaviour {
    [SerializeField]
    GameObject _Form_1, _Form_2, _Form_3, _Form_4;
    Dictionary <string, GameObject> Dict_Form_Sample = new Dictionary<string, GameObject> ();
    void Start () {
        Dict_Form_Sample = new Dictionary<string, GameObject> ();
        Dict_Form_Sample.Add ("Form_1", _Form_1);
        Dict_Form_Sample.Add ("Form_2", _Form_2);
        Dict_Form_Sample.Add ("Form_3", _Form_3);
        Dict_Form_Sample.Add ("Form_4", _Form_4);
    }

    #region Panel_Form_Show
    public GameObject Get_GO_Sample (string b) {
        return Dict_Form_Sample[b];
    }
    #endregion
    #region Kumpulan_Form (NOT USED)
        void On_Add_Form (string Type_Form, GameObject Tar_Go) {
            if (Type_Form == "Form_3") {
                L_Form_3.Add (Tar_Go.GetComponent <Form_3> ());
            }
        }

        public void On_Set_Form (string Type_Form, GameObject Tar_Go, string Method_Name, object [] objects) {
            Debug.LogError (Tar_Go.name);
            if (Type_Form == "Form_3") {
                if (Method_Name == "On_Set_Isi") {
                    Tar_Go.GetComponent <Form_3> ().On_Set_Isi (Convert.ToInt32(objects[0]), Convert.ToInt32(objects[1]));
                }
            }
        }

        void On_Remove_Form () {

        }

        void On_Destroy_Form () {

        }

        #region Form_3
        public List <Form_3> L_Form_3 = new List<Form_3> ();
        public void On_Target_L_Form () {

        }
        #endregion
    #endregion
}
