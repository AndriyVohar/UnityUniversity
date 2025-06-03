using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

[Serializable]
public class RecordData
{
    public List<int> recordTable = new List<int>();
    public int lives;
    public int collisions;
    public float levelStartTime;
    public int coinsCollected;
}

public class GlobalStorage : MonoBehaviour
{
    public static GlobalStorage Instance { get; private set; }

    public RecordData data = new RecordData();
    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.persistentDataPath, "saveData.json");
            Debug.Log("Save path: " + savePath);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        data.levelStartTime = Time.time;
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        try
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(savePath, json);
            Debug.Log("Data saved to: " + savePath);
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to save data: " + ex.Message);
        }
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            data = JsonUtility.FromJson<RecordData>(json);
            Debug.Log("Дані завантажено");
        }
        else
        {
            Debug.Log("Файл збереження не знайдено, створено новий запис.");
            data = new RecordData();
        }
    }
}