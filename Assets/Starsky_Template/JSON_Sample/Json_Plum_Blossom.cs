using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Json_Plum_Blossom : MonoBehaviour
{
        public class GameSaveSystem
        {
            #region JsonConvert.SerializeObject
            public static void SaveGame_2(int slot, Plum_Blossom_Data data)
            {
                // Menentukan path penyimpanan yang sesuai
                string savePath = Path.Combine(Application.persistentDataPath, $"save_slot_{slot}.json");
                
                // Serialisasi data menjadi format JSON
                string jsonData = JsonConvert.SerializeObject(data);
                
                // Menulis data ke file
                File.WriteAllText(savePath, jsonData);
                
                Debug.Log($"Data saved to: {savePath}");
            }
        

         public static Plum_Blossom_Data LoadGame_2(int slot)
            {
                string savePath = $"save_slot_{slot}.json";
                
                if (File.Exists(savePath))
                {
                    string jsonData = File.ReadAllText(savePath);
                    Plum_Blossom_Data data = JsonConvert.DeserializeObject<Plum_Blossom_Data>(jsonData);
                    Debug.Log($"Game saved to slot {slot} " + savePath);
                    return data;
                }
                else
                {
                    Debug.Log($"Game saved to slot {slot}" + savePath);
                    return null;
                }
            }

        #endregion

        #region JsonUtility & Application.persistentDataPath
                public static void SaveGame(int slot, Plum_Blossom_Data data)
            {
                string savePath = Path.Combine(Application.persistentDataPath, $"save_slot_{slot}.json");

                string jsonData = JsonUtility.ToJson(data);

                File.WriteAllText(savePath, jsonData);

                Debug.Log($"Data saved to: {savePath}");
            }

            public static Plum_Blossom_Data LoadGame(int slot)
            {
                string savePath = Path.Combine(Application.persistentDataPath, $"save_slot_{slot}.json");

                if (File.Exists(savePath))
                {
                    string jsonData = File.ReadAllText(savePath);
                    Plum_Blossom_Data data = JsonUtility.FromJson<Plum_Blossom_Data>(jsonData);
                 //   Debug.Log($"Data loaded from: {savePath}");
                    return data;
                }
                else
                {
                //    Debug.LogWarning($"Save file not found at: {savePath}");
                    return null;
                }
            }
        #endregion
           
        } // GameSaveSystem

}
