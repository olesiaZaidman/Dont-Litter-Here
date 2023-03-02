using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    TimeController timeController;
    UIManager ui;

    static int days = 0;
    static int moneyScore = 0;
    static int dailyWage = 100;
    bool isSalaryTime = true;


    private void Awake()
    {
        Instance = this;
        timeController = FindObjectOfType<TimeController>();
        ui = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (timeController.IsEndOfWorkingDay() && !UIManager.isGameOver)
        {
          //  Debug.Log("IsEndOfWorkingDay: " + timeController.IsEndOfWorkingDay());
            if (isSalaryTime)
            {
                IncreaseMoneyScore(dailyWage);
                ui.SetScoreTextUI(moneyScore);
                IncreaseDaysByOne();
                isSalaryTime = false;
                StartCoroutine(ui.ShowSalaryTextRoutine());
            }
        }

        if (timeController.IsMorning())
        {

            isSalaryTime = true;
        }
    }



    #region MoneyScore
    public float GetMoneyScore()
    { return moneyScore; }

    public float IncreaseMoneyScore(int num)
    {
        return moneyScore += num;
    }

    public float GetDays()
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
