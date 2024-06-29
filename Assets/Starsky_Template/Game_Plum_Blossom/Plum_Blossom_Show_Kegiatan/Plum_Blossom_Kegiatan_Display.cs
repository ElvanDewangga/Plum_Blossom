using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plum_Blossom_Kegiatan_Display : MonoBehaviour {
   #region Animation
    public void On_Animation_Plum_Blossom_Show_Kegiatan () {
        this.gameObject.SetActive (true);
    }

    public void Off_Animation_Plum_Blossom_Show_Kegiatan () {
        this.gameObject.SetActive (false);
    }
   #endregion
}
