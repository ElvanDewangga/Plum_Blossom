using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Position_UI : MonoBehaviour {
    public RectTransform uiElement; // Assign UI element in the inspector

    Vector2 mousePosition;
    // Panel_Small_Popup :
    public Vector2 On_Get_Mouse_Position () {
        return mousePosition;
    }
    
    void Update()
    {
        // Check for mouse click (left button)
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            mousePosition = Input.mousePosition;
            /*
            // Convert the screen point to a local point in the UI element's parent canvas
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                uiElement.parent as RectTransform, 
                mousePosition, 
                Camera.main, 
                out Vector2 localPoint);
            */

            // Set the UI element's position
            //uiElement.localPosition = localPoint;
           // Debug.LogError (mousePosition);

        }
    }

}
