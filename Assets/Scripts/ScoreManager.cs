using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    //Cleaningness
    static int scorePoints = 0;
    // public int DirtLevelPoints { get { return 1; } }
    public int MaxCleaningnessLevelPoints { get { return 200; } }


    //Fatigue
     static int fatiguePoints = 0;
    public int MaxEnergyLevelPoints { get { return 100; } }





    //Money

    public int ZeroDownFatigue()
    { return fatiguePoints = 0; }

    public int GetScorePoints()
    { return scorePoints; }

    public int GetFatiguePoints()
    { return fatiguePoints; }

    public int IncreaseFatiguePoints(int num)
    {
       Debug.Log("current fatiguePoints: " + fatiguePoints);
        if (fatiguePoints >= MaxEnergyLevelPoints)
        {
            fatiguePoints = MaxEnergyLevelPoints;
            return fatiguePoints;
        }
        else
        { return fatiguePoints += num; }
       
    }

    public int DecreaseFatiguePoints(int num)
    {
        Debug.Log("rested a little: " + fatiguePoints);
        if (fatiguePoints <= 0)
        {
            fatiguePoints = 0;
            return fatiguePoints;
        }
        else
        { return fatiguePoints -= num; }       
    }


    public int IncreaseScorePoints(int num)
    {
        //Debug.Log("current scorePoints: " + scorePoints);

        return scorePoints += num; 
    }

    public int DecreaseScorePoints(int num)
    {
       // Debug.Log("cleaned a little: "+ scorePoints);
        return scorePoints -= num;
    }

    //public int IncreasePoints(int points, int num)
    //{
    //    Debug.Log("current points: " + points);

    //    return points += num;
    //}

    //public int DecreasePoints(int points, int num)
    //{
    //    Debug.Log("current points: " + points);
    //    return points -= num;
    //}



    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }


    void Update()
    {

    }
}
