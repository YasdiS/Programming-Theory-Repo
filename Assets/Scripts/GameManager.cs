using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ENCAPSULATION
    public static GameManager Instance { get; private set; }

    public UnitHealth playerHealth = new UnitHealth(100, 100);
    public int pointScore;
    public string nameInput;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int m_Points;
        public string m_Name;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.m_Points = pointScore;
        data.m_Name = nameInput;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            pointScore = data.m_Points;
            nameInput = data.m_Name;
        }
    }

    public void ResetData()
    {
        foreach (var directory in Directory.GetDirectories(Application.persistentDataPath))
        {
            DirectoryInfo data_dir = new DirectoryInfo(directory);
            data_dir.Delete(true);
        }

        foreach (var file in Directory.GetFiles(Application.persistentDataPath))
        {
            FileInfo file_info = new FileInfo(file);
            file_info.Delete();
        }
    }
}
