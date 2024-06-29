using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Raw_World : MonoBehaviour {
    [SerializeField]
    GameObject _Particle_Sakura_1;
    Dictionary <string, GameObject> Dict_GO = new Dictionary<string, GameObject> ();
    void Start () {
        Dict_GO = new Dictionary<string, GameObject> ();
        Dict_GO.Add ("Particle_Sakura_1", _Particle_Sakura_1);
    }

    #region Get_GO_Sample
    // Home_Scene :
    public GameObject Get_GO_Sample (string b) {
        return Dict_GO[b];
    }
    #endregion
}
