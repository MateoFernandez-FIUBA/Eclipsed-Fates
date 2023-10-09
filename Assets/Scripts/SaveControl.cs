using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

public class SaveControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Character character;
    [SerializeField] FlashLight flashLight;
    public string saveFile;
    public SaveData saveData = new SaveData();

    private void Awake()
    {
        saveFile = Application.dataPath + "/savedata.json";
    }

    public void LoadData()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            saveData = JsonUtility.FromJson<SaveData>(content);
            player.transform.position = saveData.position;
            character.SetLife(saveData.life);
            flashLight.SetBatteryLevel(saveData.currentBatteryLevel);
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
            position = player.transform.position,
            life = character.GetLife(),
            currentBatteryLevel = flashLight.GetBatteryLevel()
        };
        string JSONFile = JsonUtility.ToJson(newData);
        File.WriteAllText(saveFile, JSONFile);
    }
}