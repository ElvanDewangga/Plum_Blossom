
using UnityEngine;
using UnityEditor;

public class PauseOnSpace : MonoBehaviour
{
    void Update()
    {
        // Check if the space key was pressed this frame
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle the pause state
            if (EditorApplication.isPaused == false)
            {
                // Pause Editor :
                EditorApplication.isPaused = true;
               // Time.timeScale = 0.0f; // Pause the game
                Debug.Log("Game Paused");
            }
            else
            {
                //Pause Editor :
                EditorApplication.isPaused = false;
               // Time.timeScale = 1.0f; // Resume the game
                Debug.Log("Game Resumed");
            }
        }
    }
}
