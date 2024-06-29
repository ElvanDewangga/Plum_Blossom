using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Sample : MonoBehaviour{
    public bool b_Clone = false;
    // Sample_Scene :
    public void On_Set_b_Clone (bool s) {
        b_Clone = s;
        this.gameObject.SetActive (true);
    }

}
