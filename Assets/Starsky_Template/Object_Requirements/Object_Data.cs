using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Data : MonoBehaviour {
    [SerializeField]
    string [] A_String;

    public string [] On_Get_A_String () {
        return A_String;
    }

    [SerializeField]
    GameObject [] A_GameObject;

    public GameObject [] On_Get_A_GameObject () {
        return A_GameObject;
    }
}
