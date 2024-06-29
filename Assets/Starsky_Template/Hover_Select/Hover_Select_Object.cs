using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover_Select_Object : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {// Sumber
    // Hover_Select :
    public string On_Event = "";
    public string Off_Event = "";
    [Tooltip ("Tidak wajib isi :")]
    [HideInInspector]
    public Animator _Animator;

    void Start () {
        if (this.gameObject.GetComponent<Animator> () != null) {
            _Animator = this.gameObject.GetComponent<Animator> ();
        }
    }
    #region Input_Event
    void On_Set_On_Event (string bal) {
        On_Event = bal;
    }
    void On_Set_Off_Event (string bal) {
        Off_Event = bal;
    }
    #endregion
    #region Hover
    void On_Hover () {
       _Hover_Select.On_Doing_Event (this);
    }

    void Off_Hover () {
        _Hover_Select.Off_Doing_Event (this);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
       // Debug.Log("Mouse entered the UI element.");
       On_Hover ();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      //  Debug.Log("Mouse exited the UI element.");
        Off_Hover ();
    }
    
    #endregion
    #region Hover_Select
    [SerializeField]
    Hover_Select _Hover_Select;
    void On_Input_Line_Selected_Button (Hover_Select s) {
        _Hover_Select = s;
    }
    #endregion

}
