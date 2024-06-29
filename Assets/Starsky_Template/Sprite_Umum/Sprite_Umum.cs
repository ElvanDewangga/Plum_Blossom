using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
public class Sprite_Umum : MonoBehaviour {
   [SerializeField]
   Sprite Coin_Sprite;
   [SerializeField]
   Sprite Unknown_Sprite;
   [SerializeField]
   Sprite Polos_Sprite; // Sumber_Selected_Button
   [SerializeField]
   Sprite Hp_Sprite;
   [SerializeField]
   Sprite Mp_Sprite;
   [SerializeField]
   Sprite Stress_Sprite;
   [SerializeField]
   Sprite Male_Sprite;
   [SerializeField]
   Sprite Female_Sprite;
   [SerializeField]
   Sprite Housekeeping_Sprite, Babysitting_Sprite, Tutoring_Sprite, Singer_Sprite, Pickpocket_Sprite, Porter_Sprite;
   [SerializeField]
   Sprite Reading_Sprite;
   [SerializeField]
   Sprite Arithmetic_Sprite, Literature_Sprite, PE_Sprite, Sport_Club_Sprite, Tech_Club_Sprite ,Music_Club_Sprite;
   [SerializeField] 
   Sprite Taming_Class_Sprite, Apothecary_Class_Sprite, Crafting_Class_Sprite, Magic_Class_Sprite, Combat_Class_Sprite;
   [SerializeField]
   Sprite Advanced_Apothecary_Class_Sprite, Advanced_Crafting_Class_Sprite, Advanced_Magic_Class_Sprite, Advanced_Combat_Sprite;
   #region Get_Sprite_From_Name
   // Home_Scene, Sprite_Load :
    public Sprite On_Get_Sprite_From_Name (string Name) {
        Sprite Res = Unknown_Sprite;

        // Create an instance of ExampleClass
       // ExampleClass example = new ExampleClass();

        // Get the type information of ExampleClass
        Type type = typeof(Sprite_Umum);

        // Get the FieldInfo object for the private field "hiddenValue"
        FieldInfo fieldInfo = type.GetField(Name, BindingFlags.NonPublic | BindingFlags.Instance);

        // Check if the field was found
        if (fieldInfo != null)
        {
            Res = (Sprite)fieldInfo.GetValue (this);
            /*
            //Get the value of the private field
            int value = (int)fieldInfo.GetValue(example);
            Console.WriteLine("Hidden Value: " + value);
            
            // Set a new value to the private field
            fieldInfo.SetValue(example, 100);

            // Get the updated value of the private field
            int updatedValue = (int)fieldInfo.GetValue(example);
            Console.WriteLine("Updated Hidden Value: " + updatedValue);
            */
        }
        else {
            Debug.LogError ("Field tidak ditemukan");
        }

        return Res;
    }
   #endregion
}
