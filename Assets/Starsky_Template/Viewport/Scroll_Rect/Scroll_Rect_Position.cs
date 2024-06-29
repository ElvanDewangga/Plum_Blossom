using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class Scroll_Rect_Position : MonoBehaviour
{
    // Referensi ke komponen ScrollRect
    ScrollRect scrollRect;

    void Start () {
        scrollRect = GetComponent<ScrollRect> ();
        ScrollToTopPosition ();
    }
    // Data_Slot_Canvas : :
    // Method untuk menggulir ke atas
    public void ScrollToTopPosition()
    {
        if (!scrollRect) {
            scrollRect = GetComponent<ScrollRect> ();
        }
        scrollRect.verticalNormalizedPosition = 1;
    }
}
