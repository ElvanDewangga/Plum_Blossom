using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bug_Layout_Scalling : MonoBehaviour {
    /* NOTE: 
    * Pasang ini jika Layout kamu mencentang Use Child Scale.
    * Dan object child yang dimiliki oleh Layout di Instantiate
    Example : Layout_Data_Slot
    */
   void Start () {
    this.gameObject.SetActive (false);
    this.gameObject.SetActive (true);
   }
}
