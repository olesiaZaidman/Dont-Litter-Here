using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BestPlayerDataHandler : MonoBehaviour
{
    //public static BestPlayerDataHandler Instance;
    //public string bestScorePlayerName;
    //public int bestScore;


    //public BestPlayerDataHandler()
    ///*Constructor is called before any Unity's Initialization Functions*/
    //{
    //    Instance = this;
    //}

    //void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    DontDestroyOnLoad(gameObject);
    //    LoadPlayerData();
    //}

    //#region PlayerName
    //public void NewBestPlayerNameSaved(string _name)
    //{
    //    bestScorePlayerName = _name;
    //}

    //#endregion

    //#region Score
    //public void NewBestScoreSaved(int _score)
    //{
    //    bestScore = _score;
    //}

    //public void SetHighScoreIfGreater(int _score)
    //{
    //    if (_score > bestScore)
    //    {
    //        NewBestPlayerNameSaved(PlayerDataHandler.currentPlayerName);//to acces static variable put the class!
    //        NewBestScoreSaved(_score);
    //        GameOverHandler.isNewRecord = true;
    //    }
    //}
    //#endregion

    //[System.Serializable]
    //class SaveData
    //{
    //    public string bestScorePlayerName;
    //    public int bestScore;
    //}

    //public void SavePlayerData()
    //{
    //    SaveData data = new SaveData();
    //    data.bestScorePlayerName = bestScorePlayerName;
    //    data.bestScore = bestScore;

    //    // data.bestScores = bestScores;

    //    string json = JsonUtility.ToJson(data);
    //    // json now contains: '{"bestScorePlayerName":bestScorePlayerName,"bestScore":bestScore}'
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public void LoadPlayerData()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        bestScorePlayerName = data.bestScorePlayerName;
    //        bestScore = data.bestScore;
    //    }
    //}


}

