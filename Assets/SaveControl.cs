using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

public class SaveControl : MonoBehaviour
{
    public GameObject player;
    public string saveFile;
    public SaveData saveData = new SaveData();

    private void Awake()
    {
        saveFile = Application.dataPath + "/savedata.json";
        //player = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    public void LoadData()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            saveData = JsonUtility.FromJson<SaveData>(content);
        }
        else
        {
            Debug.Log("File not found!");
        }
    }

    public void SavingData()
    {
        SaveData newData = new SaveData()
        {
            position = player.transform.position
        };
        string JSONFile = JsonUtility.ToJson(newData);
        File.WriteAllText(saveFile, JSONFile);
    }
}
