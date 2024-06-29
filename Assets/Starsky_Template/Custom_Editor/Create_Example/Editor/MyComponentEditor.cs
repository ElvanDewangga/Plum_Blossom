// MyComponentEditor.cs
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyComponent))]
public class MyComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MyComponent myComponent = (MyComponent)target;

        // Start the vertical layout
        GUILayout.BeginVertical();

        // Display each string in the list with a delete button
        for (int i = 0; i < myComponent.stringList.Count; i++)
        {
            GUILayout.BeginHorizontal();

            // Display the string value
            myComponent.stringList[i] = EditorGUILayout.TextField(myComponent.stringList[i]);

            // Add a delete button
            if (GUILayout.Button("Delete"))
            {
                myComponent.stringList.RemoveAt(i);
            }

            GUILayout.EndHorizontal();
        }

        // Add button to add new string to the list
        if (GUILayout.Button("Add"))
        {
            myComponent.stringList.Add(string.Empty);
        }

        // End the vertical layout
        GUILayout.EndVertical();

        // Apply changes to the serialized object
        if (GUI.changed)
        {
            EditorUtility.SetDirty(myComponent);
        }
    }
}
