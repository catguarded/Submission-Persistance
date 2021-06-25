using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SavingThings : MonoBehaviour
{
    public static SavingThings Instance;

    public int HighScore;
    public string PlayerName;
    public string HighPlayerName;

    public Text playerText;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();


    }

    public void Update()
    {
        SetName();
    }

    public void SetName()
    {
        PlayerName = playerText.text;

    }


    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string PlayerName;
        public string HighPlayerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
      //  data.PlayerName = PlayerName;
        data.HighPlayerName = HighPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            PlayerName = data.PlayerName;
            HighPlayerName = data.HighPlayerName;
        }
    }



}
