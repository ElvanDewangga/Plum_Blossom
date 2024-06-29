using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel_Model_1_Utama : MonoBehaviour {
    [SerializeField]
    Image _Panel_Model_1_Utama;
   
    public virtual void On_Open () {
        _Panel_Model_1_Utama.gameObject.SetActive (true);

        
    }

    public virtual void Off_Open () {
        _Panel_Model_1_Utama.gameObject.SetActive (false);
    }
}
