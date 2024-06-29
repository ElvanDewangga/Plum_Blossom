using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Bug_Layout_Local_Scale_0 : MonoBehaviour {
    /* NOTE: 
    * Canvas juga harus di set Default sesuai dengan objek ini dibuat misal Scale with screen size (1920 x 1080)
    * Pasang ini ketika UI rusak saat perubahaan resolusi. Scale biasa tidak seimbang untuk objek yang di Instantiate
    Example : Arrow_Yellow_1
    */
    void Start () {
        this.transform.localScale = new Vector3 (1,1,1);
    }
}
