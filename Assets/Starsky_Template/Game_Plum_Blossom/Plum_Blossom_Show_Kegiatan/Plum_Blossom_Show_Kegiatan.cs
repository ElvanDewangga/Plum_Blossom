using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Starsky;
using System;
public class Plum_Blossom_Show_Kegiatan : MonoBehaviour {
    [SerializeField]
    Plum_Blossom_Kegiatan_Display [] A_Plum_Blossom_Kegiatan_Display;

    [SerializeField]
    GameObject Raw_Screen;

    [SerializeField]
    Button Confirm_Button;

    [SerializeField]
    Image Tab_Result;
    [SerializeField]
    Transform Content_Tab_Result;
    #region Implementation (Kegiatan_Home)
    Selected_Button_Data Selected_Button_Data_Kegiatan;
    // Kegiatan_Home
    public void On_Doing_Kegiatan (Selected_Button_Data v) { // Plan_Day Selected_Button
        Selected_Button_Data_Kegiatan =v;
        On_Destroy_All_Clone_Tab_Result ();
        Tab_Result.gameObject.SetActive (false);
        Home_Scene.Ins._Home_Child_Interact.gameObject.SetActive (false);
        string Doing_Kegiatan = "Free_Time";
        if (v.A_String.Length > 0) {
           Doing_Kegiatan = Home_Scene.Ins._Part_Time_Job_Utama.On_Get_Type_Plan (v.A_String[0]);
        } else {
            Doing_Kegiatan = "Free_Time";
        }
        foreach (Plum_Blossom_Kegiatan_Display s in A_Plum_Blossom_Kegiatan_Display) {
            s.Off_Animation_Plum_Blossom_Show_Kegiatan (); 
        }
        if (Doing_Kegiatan ==  "Class") {
            A_Plum_Blossom_Kegiatan_Display [0].On_Animation_Plum_Blossom_Show_Kegiatan ();
        } else if (Doing_Kegiatan ==  "Part_Time_Job") {
            A_Plum_Blossom_Kegiatan_Display [1].On_Animation_Plum_Blossom_Show_Kegiatan ();
        } else {
            A_Plum_Blossom_Kegiatan_Display [2].On_Animation_Plum_Blossom_Show_Kegiatan ();
        }

        this.gameObject.SetActive (true);
        Raw_Screen.gameObject.SetActive (true);
        
        StartCoroutine (N_Result_Doing_Kegiatan ());
    }

    IEnumerator N_Result_Doing_Kegiatan () {
        yield return new WaitForSeconds (2.5f);
        Confirm_Button.gameObject.SetActive (true);
        Tab_Result.gameObject.SetActive (true);
        On_Show_Field ();
    }

    public void On_Confirm_Button () {
        this.gameObject.SetActive (false);
        Raw_Screen.gameObject.SetActive (false);
        // Home_Scene.Ins._Home_Child_Interact.gameObject.SetActive (true);
        Confirm_Button.gameObject.SetActive (false);
        Home_Scene.Ins._Kegiatan_Home.On_Doing_Sleep ();
    }

        #region Show_Field
        public GameObject Target_Data_Kegiatan_Home;
        void On_Show_Field () {
            if (Selected_Button_Data_Kegiatan.A_String.Length > 0) {
                Target_Data_Kegiatan_Home = Home_Scene.Ins._Part_Time_Job_Utama.On_Get_Panel_Model_1_Data_From_Name (Selected_Button_Data_Kegiatan.A_String[0]).gameObject;
                Panel_Model_1_Data Pm_1 = Target_Data_Kegiatan_Home.gameObject.GetComponent <Panel_Model_1_Data> ();
                List <Field_1> Lf = Pm_1.On_Get_List_Field_1 ();
                foreach (Field_1 s in Lf) {
                    int Rand = UnityEngine.Random.Range (s.Min_Int, s.Max_Int +1);
                    /*
                    Star_GameObject St = new Star_GameObject();
                    St.On_Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_4"),Tab_Result.transform, true);  
                    St.On_Input_Method ("Clone_Sample","On_Set_b_Clone",new Type[] { typeof(bool)}, new object[] {true});
                    st.On_Input_Method ("Form_4","On_Set_Tmp_Field",new Type[] { typeof(string), typeof(string), typeof(string)}, new object[] {s.Code_Str, Get_Data.Ins.On_Get_Data_By_Name (s.Code_Str).ToString (), Rand.ToString ()});
                   // GameObject Ins_Go = St.Target_GO;
                  //  Ins_Go.gameObject.transform.GetComponent <Form_4> ().On_Set_Tmp_Field (s.Code_Str, Get_Data.Ins.On_Get_Data_By_Name (s.Code_Str).ToString (), Rand.ToString ());
                    */
                    GameObject Ins = GameObject.Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_4"));
                    Ins.transform.SetParent (Content_Tab_Result.transform);
                    Ins.SetActive (true);
                    Clone_Sample Cs = Ins.GetComponent <Clone_Sample> ();
                    Cs.On_Set_b_Clone (true);
                    Form_4 F4 = Ins.GetComponent <Form_4> ();
                    F4.On_Set_Tmp_Field (s.Code_Str, ((int)Get_Data.Ins.On_Get_Data_By_Name (s.Code_Str) + Rand).ToString (), "(+ " +Rand.ToString () + ")");
                    Set_Data.Ins.On_Set_Data_Inc_By_Name (s.Code_Str, Rand);
                    
                }
                if (Pm_1.Coin >0) {
                    int Rand = Pm_1.Coin;
                    GameObject Ins = GameObject.Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_4"));
                    Ins.transform.SetParent (Content_Tab_Result.transform);
                    Ins.SetActive (true);
                    Clone_Sample Cs = Ins.GetComponent <Clone_Sample> ();
                    Cs.On_Set_b_Clone (true);
                    Form_4 F4 = Ins.GetComponent <Form_4> ();
                    F4.On_Set_Tmp_Field ("Coin", (Home_Scene.Ins._Character_Status_Sumber._Status_Universal.Coin+ Rand).ToString (), "(+ " +Rand.ToString () + ")");
                    Set_Data.Ins.On_Set_Data_Non_Mono_Inc_By_Name ("Coin", Rand);
                } else {
                    if (Pm_1.Min_Coin >0) {
                        int Rand = UnityEngine.Random.Range (Pm_1.Min_Coin, Pm_1.Max_Coin +1);
                        GameObject Ins = GameObject.Instantiate (All_Scene_Go_Script.Ins._Form_Show._Form_Show_Label.Get_GO_Sample ("Form_4"));
                        Ins.transform.SetParent (Content_Tab_Result.transform);
                        Ins.SetActive (true);
                        Clone_Sample Cs = Ins.GetComponent <Clone_Sample> ();
                        Cs.On_Set_b_Clone (true);
                        Form_4 F4 = Ins.GetComponent <Form_4> ();
                        F4.On_Set_Tmp_Field ("Coin", (Home_Scene.Ins._Character_Status_Sumber._Status_Universal.Coin + Rand).ToString (), "(+ " +Rand.ToString () + ")");
                        Set_Data.Ins.On_Set_Data_Non_Mono_Inc_By_Name ("Coin", Rand);
                    }
                }
            }
        }

        void On_Destroy_All_Clone_Tab_Result () {
            foreach (Transform s in Content_Tab_Result.transform) {
                if (s.GetComponent <Clone_Sample> ().b_Clone) {
                    Destroy (s.gameObject);
                }
            }
        }
        #endregion
    #endregion

}
