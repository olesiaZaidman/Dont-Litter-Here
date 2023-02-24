using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    //Cleaningness
    static float cleanRatingPoints;
    public float MaxCleaningnessLevelPoints { get { return 10; } }
    static float amountOfGarbageInScene; //Make it private with getter!
    public float amGarbInScene;


    //Fatigue
    static float fatiguePoints = 0;
    public float MaxEnergyLevelPoints { get { return 100; } }


    //Money
    static float moneyScore = 0;
    private void Awake()
    {
        Instance = this;
        SetStartCleanRatingPoints();
    }

    private void Start()
    {
        
    }

 
    void Update()
    {
        amountOfGarbageInScene = FindGarbageInScene();
        amGarbInScene = amountOfGarbageInScene;
    }

    int FindGarbageInScene()
    {
        //Calculate Amount of garbage in the scene:
        var foundGarbageObjects = FindObjectsOfType<Litter>(); 
         //   Debug.Log(foundGarbageObjects + " : " + foundGarbageObjects.Length);
           return foundGarbageObjects.Length;
    }
    #region MoneyScore
    public float GetMoneyScore()
    { return moneyScore; }

    public float IncreaseMoneyScore(int num)
    {
        return moneyScore += num; 
    }
    public float DecreaseMoneyScore(int num)
    {
        return moneyScore -= num;
    }
    #endregion

    #region Fatigue

    public float ZeroDownFatigue()
    { return fatiguePoints = 0; }

    public float GetFatiguePoints()
    { return fatiguePoints; }

    public float IncreaseFatiguePoints(float num)
    {
     //  Debug.Log("current fatiguePoints: " + fatiguePoints);
        if (fatiguePoints >= MaxEnergyLevelPoints)
        {
            fatiguePoints = MaxEnergyLevelPoints;
            return fatiguePoints;
        }
        else
        { return fatiguePoints += num; }
       
    }

    public float DecreaseFatiguePoints(float num)
    {
      //  Debug.Log("rested a little: " + fatiguePoints);
        if (fatiguePoints <= 0)
        {
            fatiguePoints = 0;
            return fatiguePoints;
        }
        else
        { return fatiguePoints -= num; }       
    }

    public void RestDown(float _time) //works in Update
    {
        if (fatiguePoints > 0)
        {
            float acceleration = (MaxEnergyLevelPoints - 0) / _time;
            fatiguePoints -= acceleration * Time.deltaTime;
        }
        else
            fatiguePoints = 0;
    }

    #endregion

    #region CleanRating
    void SetStartCleanRatingPoints()
    {
        cleanRatingPoints = MaxCleaningnessLevelPoints - amountOfGarbageInScene;
        //Debug.Log("Start for cleanRatingPoints: " + cleanRatingPoints);
    }

    public float GetCleanRatingPoints()
    { return cleanRatingPoints; }

    //private int GetAmountOfGarbageInScene()
    //{ return amountOfGarbageInScene; }
    public void UpdateCleanRatingPoints()
    {
        if (cleanRatingPoints < 0)
        {
            cleanRatingPoints = 0;

            //GAMEOVER
         //   return cleanRatingPoints;
        }
        else
        {
            cleanRatingPoints = MaxCleaningnessLevelPoints - amountOfGarbageInScene;
          //  Debug.Log("damn garbage!: " + cleanRatingPoints);
           // return cleanRatingPoints;
        }
    }

    //public int IncreaseCleanRatingPoints(int num)
    //{
    //    //MaxCleaningnessLevelPoints
    //    //cleanRatingPoints
    //    //amountOfGarbageInScene
    //    Debug.Log("cleaned a little: " + cleanRatingPoints);
    //    if (cleanRatingPoints >= MaxCleaningnessLevelPoints)
    //    {
    //        cleanRatingPoints = MaxCleaningnessLevelPoints;
    //        return cleanRatingPoints;
    //    }
    //    else
    //    {
    //        return cleanRatingPoints = MaxCleaningnessLevelPoints + amountOfGarbageInScene;
    //    }

    //}



    #endregion


    //public int IncreaseScorePoints(int num)
    //{
    //    //Debug.Log("current scorePoints: " + scorePoints);

    //    return scorePoints += num;
    //}

    //public int DecreaseScorePoints(int num)
    //{
    //    // Debug.Log("cleaned a little: "+ scorePoints);
    //    return scorePoints -= num;
    //}


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



}
