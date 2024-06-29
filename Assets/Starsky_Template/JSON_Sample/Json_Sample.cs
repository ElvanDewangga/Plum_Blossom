using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
public class SaveData
{
    public int playerLevel;
    public string playerName;
    public int First_Home_Menu = 0;
    public string Child_Name = "";
    // Tambahkan atribut lain yang ingin Anda simpan di sini

    public SaveData(int level, string name, int First_Home_Menu_V, string Child_Name_V)
    {
        playerLevel = level;
        playerName = name;
        First_Home_Menu = First_Home_Menu_V;
        Child_Name = Child_Name_V;
    }
}

public class GameSaveSystem
{
    public static void SaveGame(int slot, SaveData data)
    {
        string savePath = $"save_slot_{slot}.json";
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(savePath, jsonData);
        Debug.Log($"Game saved to slot {slot}");
    }

    public static SaveData LoadGame(int slot)
    {
        string savePath = $"save_slot_{slot}.json";
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            SaveData data = JsonConvert.DeserializeObject<SaveData>(jsonData);
            Debug.Log($"Game saved to slot {slot}");
            return data;
        }
        else
        {
            Debug.Log($"Game saved to slot {slot}");
            return null;
        }
    }
}

class Test_Progam
{
    static void Main(string[] args)
    {
        // Simpan data permainan
        SaveData player1Data = new SaveData(10, "Player1", 0, "");
        GameSaveSystem.SaveGame(1, player1Data);

        // Muat data permainan
        SaveData loadedData = GameSaveSystem.LoadGame(1);
        if (loadedData != null)
        {
            Console.WriteLine($"Player Name: {loadedData.playerName}, Player Level: {loadedData.playerLevel}");
        }
    }
}