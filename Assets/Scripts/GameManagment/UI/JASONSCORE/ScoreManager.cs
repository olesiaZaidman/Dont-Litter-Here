using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    TimeController timeController;
    UIGameStatsManager ui;

    //   static int moneyScore = 0;

    static int days = 0;
    static int dailyWage = 20;
    bool isSalaryTime = true;

    public ScoreManager()
    /*Constructor is called before any Unity's Initialization Functions*/
    {
        Instance = this;
    }

    private void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        ui = FindObjectOfType<UIGameStatsManager>();
        //  ManageSingleton();
    }



    //void ManageSingleton()
    //{
    //    if (Instance != null)
    //    {
    //        gameObject.SetActive(false);
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    private void Update()
    {

        //TEST:
        //if ((Input.GetKey(KeyCode.M)))
        //{
        //    AddMoneyPoints(10);
        //}

        if (timeController.IsEndOfWorkingDay() && !GameOverHandler.isGameOver)
        {
            //  Debug.Log("IsEndOfWorkingDay: " + timeController.IsEndOfWorkingDay());
            if (isSalaryTime)
            {
                AddMoneyPoints(dailyWage);
                IncreaseDaysByOne();
                isSalaryTime = false;
                // Debug.Log("You worked days: " + days);
                StartCoroutine(ui.ShowSalaryTextRoutine());

            }
        }

        if (timeController.IsEarlyMorning())
        {

            isSalaryTime = true;
        }
    }

    #region MoneyScore
    public float GetMoneyPoints()
    {
        return PlayerDataHandler.CurrentScore;
    }


    public void AddMoneyPoints(int _point)
    {

        PlayerDataHandler.CurrentScore += _point;//  moneyScore += _point;
        ui.SetScoreTextUI(PlayerDataHandler.CurrentScore);// ui.SetScoreTextUI(moneyScore);
    //    Debug.Log("Added money points:" + _point);
    //    Debug.Log("CurrentScore:" + PlayerDataHandler.CurrentScore);
       // HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(PlayerDataHandler.currentPlayerName, PlayerDataHandler.CurrentScore));
      //  BestPlayerDataHandler.Instance.SetHighScoreIfGreater(PlayerDataHandler.CurrentScore);
    }


    public int GetDays()
    { return days; }

    public float IncreaseDaysByOne()
    {
        return days += 1;
    }
    //public float DecreaseMoneyScore(int num)
    //{
    //    return moneyScore -= num;
    //}
    #endregion

}
