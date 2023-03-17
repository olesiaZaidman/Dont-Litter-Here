using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    TimeController timeController;
    UIManager ui;

    static int moneyScore = 0;

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
        if (timeController.IsEndOfWorkingDay() && !GameManager.isGameOver)
        {
          //  Debug.Log("IsEndOfWorkingDay: " + timeController.IsEndOfWorkingDay());
            if (isSalaryTime)
            {
                IncreaseMoneyScoreUpdateUi(dailyWage);
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
    public float GetMoneyScore()
    { return moneyScore; }

    public void ResetMoneyScore()
    {
        moneyScore = 0;
    }

    public float IncreaseMoneyScoreUpdateUi(int num)
    {
        moneyScore += num;
        ui.SetScoreTextUI(moneyScore);
        return moneyScore;
    }

    public int GetDays()
    { return days; }

    public float IncreaseDaysByOne()
    {
        return days += 1;
    }
    public float DecreaseMoneyScore(int num)
    {
        return moneyScore -= num;
    }
    #endregion

}
