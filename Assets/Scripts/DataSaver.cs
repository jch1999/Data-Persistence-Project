using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance;

    public string Bestname;
    public int BestScore;
    public string userName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestData();
    }

    [System.Serializable]
    class BestData
    {
        public string Bestname;
        public int BestScore;
    }
    public void SaveName(string name)
    {
        userName = name;
    }
    public void UpdateBest(int newScore)
    {
        Bestname = userName;
        BestScore = newScore;
        SaveBestData();
    }
    public void SaveBestData()
    {
        BestData data = new BestData();
        data.Bestname = Bestname;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestData data = JsonUtility.FromJson<BestData>(json);
            Bestname = data.Bestname;
            BestScore = data.BestScore;
        }
    }
}
