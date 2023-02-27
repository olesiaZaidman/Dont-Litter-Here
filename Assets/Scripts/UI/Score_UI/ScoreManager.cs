using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    //Cleaningness


    //Money
    static float moneyScore = 0;

 

    private void Awake()
    {
        Instance = this;
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
