using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    TimeController timeController;
    UIManager ui;

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
        ui = FindObjectOfType<UIManager>();
      //  ManageSingleton();
    }

    void ManageSingleton()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (timeController.IsEndOfWorkingDay() && !GameOverHandler.isGameOver)
        {
          //  Debug.Log("IsEndOfWorkingDay: " + timeController.IsEndOfWorkingDay());
            if (isSalaryTime)
            {
                AddMoneyPoint(dailyWage);
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
    { return HighScoreManager.Instance.CurrentScore; }

    public void ResetMoneyPoints()
    {
        HighScoreManager.Instance.CurrentScore = 0;// moneyScore = 0;
    }

    public void AddMoneyPoint(int _point)
    {
        HighScoreManager.Instance.CurrentScore += _point;//  moneyScore += _point;
        ui.SetScoreTextUI(HighScoreManager.Instance.CurrentScore);// ui.SetScoreTextUI(moneyScore);
        HighScoreManager.Instance.SetHighScoreIfGreater(HighScoreManager.Instance.CurrentScore);
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
