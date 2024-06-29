using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sprite_Load : MonoBehaviour {
    [SerializeField] // langsung diisi.
    string Title_Sprite; // Code at : Sprite_Umum
    Image _Image;
    void Start () {
        _Image = this.gameObject.GetComponent <Image> ();
        _Image.sprite = All_Scene_Go_Script.Ins._Sprite_Umum.On_Get_Sprite_From_Name (Title_Sprite);  
    }
}
