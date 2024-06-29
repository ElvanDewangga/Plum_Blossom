using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button_Sprite : MonoBehaviour {
    [SerializeField]
    Button _Button;


    // Selected_Button_Data :
    public void On_Set_Sprite (Sprite Sp) {
        _Button.image.sprite = Sp;
    }
}
