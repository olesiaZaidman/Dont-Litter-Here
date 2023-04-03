using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;


public class ScoreHandler : MonoBehaviour
{
    //private ScoreData scoreData;

    //void Awake()
    //{
    //    LoadScore();      // used to bescoreData = new ScoreData();
    //}

    //public IEnumerable<Score> GetHighScores()
    //{
    //    return scoreData.bestScores.OrderByDescending(player => player.score); 
    //    //LINQ Extension Method to SORT
    //    //we sort it by score
    //}

    //public void AddScore(Score _score)
    //{
    //    scoreData.bestScores.Add(_score);
    //}

    //private void OnDestroy()
    //{
    //    SaveScore();
    //}

    //public void SaveScore() //on GameOver
    //{
    //    string json = JsonUtility.ToJson(scoreData);
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public void LoadScore()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        scoreData = JsonUtility.FromJson<ScoreData>(json);
    //    }
    //}
}
