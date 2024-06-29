using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hover_Sprite : MonoBehaviour {
    [SerializeField]
    Sprite Sprite_On;
    [SerializeField]
    Sprite Sprite_Off;
    [SerializeField]
    Button _Button;
    public void On_Hover () {
       _Button.image.sprite = Sprite_On;
    }

    public void Off_Hover () {
        _Button.image.sprite = Sprite_Off;
    }
}
