using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationManager : MonoBehaviour
{
    [SerializeField]
    //List<MonoBehaviour> initializationScripts;
    List<Custom_Initialization> Awake_initializationScripts;
    
    [SerializeField]
    //List<MonoBehaviour> initializationScripts;
    List<Custom_Initialization> Start_initializationScripts;
    void Awake()
    {
        foreach (var script in Awake_initializationScripts)
        {
            script.CustomAwake ();
        }
        /*
        foreach (var script in initializationScripts)
        {
            script.SendMessage ("CustomAwake");
        }
        */
    }

    void Start()
    {
        
        foreach (var script in Start_initializationScripts)
        {
            script.CustomStart ();
        }
        
    }
}
