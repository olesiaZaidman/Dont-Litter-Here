using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData : MonoBehaviour
{
    //or put it int scoreManager
    public List<Score> bestScores;

    public ScoreData()
    {
        bestScores = new List<Score>();
    }
}
