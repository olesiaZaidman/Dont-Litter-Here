using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    public static List<HighScoreElement> highScoresList = new List<HighScoreElement>();
    static int maxCountEntries = 5;
    static string filename = "dontLitterHereHighScores.json";
    void Start()
    {
        LoadHighScores();
    }
    void LoadHighScores()
    {
        highScoresList = FileHandler.ReadListFromJSON<HighScoreElement>(filename);

        while (highScoresList.Count > maxCountEntries)
        {
            highScoresList.RemoveAt(maxCountEntries);
        }
    }

    static void SaveHighScore()
    {
        FileHandler.SaveToJSON<HighScoreElement>(highScoresList, filename);
    }

    public static void AddHighScoreIfPossiable(HighScoreElement element)
    {
        for (int i = 0; i < maxCountEntries; i++)
        {
            if (i >= highScoresList.Count || element.score > highScoresList[i].score)
            {
                //add new high score:
                highScoresList.Insert(i, element);

                while (highScoresList.Count > maxCountEntries)
                {
                    highScoresList.RemoveAt(maxCountEntries);
                }

                SaveHighScore();
                break;
            }
        }
    }

    public static HighScoreElement GetTopPlayer()
    {
        if (highScoresList != null && highScoresList.Count > 0)
        {
            Debug.Log(highScoresList[0].playerName);
            return highScoresList[0];
        }
        else return null;
        //new HighScoreElement("", 0);

    }
}
