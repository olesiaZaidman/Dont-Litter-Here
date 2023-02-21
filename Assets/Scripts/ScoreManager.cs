using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //public static ScoreManager Instance;

    static int scorePoints = 0;
    public int DirtLevelPoints { get { return 1; } }
    public int MaxDirtLevelPoints { get { return 100; } }
    public int GetScorePoints()
    { return scorePoints; }

    public int IncreaseScorePoints(int points)
    { return scorePoints += points; }

    public int DecreaseScorePoints(int points)
    {
        Debug.Log("cleaned a little: "+ scorePoints);
        return scorePoints -= points;
    }

    //private void Awake()
    //{
    //    Instance = this;
    //}
    void Start()
    {

    }


    void Update()
    {

    }
}
