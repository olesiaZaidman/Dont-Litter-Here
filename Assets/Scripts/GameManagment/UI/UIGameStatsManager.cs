using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIGameStatsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeHourText;
    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] TextMeshProUGUI temperatureText;

    //18°C
    [SerializeField] GameObject salaryTextPanel;
    [SerializeField] GameObject gameOverTextPanel;

    ColorCollection colorPalette;

    AudioManager audioManager;
    public static UIGameStatsManager Instance;

    void Awake()
    {
        Instance = this;
        audioManager = FindObjectOfType<AudioManager>();
        colorPalette = FindObjectOfType<ColorCollection>();
        salaryTextPanel.SetActive(false);
        gameOverTextPanel.SetActive(GameOverHandler.isGameOver);        
    }

    private void Start()
    {
        SetScoreTextUI(HighScoreManager.Instance.CurrentScore);

    //    StartCoroutine(ShowStartNavigationRoutine("Press [W] or [S] or arrows to move"));
    }

 

    void Update()
    {
        ChangeTextColorIfNeeded(scoreText, GameOverHandler.isNewRecord);

        if (GameOverHandler.isGameOver)
        {
            ShowGameOverText(GameOverHandler.isGameOver);
            HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(HighScoreManager.currentPlayerName, HighScoreManager.Instance.CurrentScore));

        }

        if ((Input.GetKey(KeyCode.Space)))
        {
            StopCoroutine(ShowSalaryTextRoutine());
            salaryTextPanel.SetActive(false);
        }
        //  UpdateAndShowStartNavigationMessages();
    }


    #region SalaryScore Message

    public IEnumerator ShowSalaryTextRoutine()
    {//We've all got to earn our daily bread somehow
        float _delay = 3f;
        audioManager.PlayMoneySFXOnce();
        salaryTextPanel.SetActive(true);
        yield return new WaitForSeconds(_delay);
        salaryTextPanel.SetActive(false);
    }

    public void SetScoreTextUI(int _moneyPoints)
    {
        scoreText.SetText(_moneyPoints.ToString());//ToString("00000")
    }

    public void ChangeTextColorIfNeeded(TextMeshProUGUI _text, bool _isChange)
    {
        if (_isChange)
        {
            colorPalette.ChangeTextColour(_text, colorPalette.GetYellow());
        }
        else if (!_isChange)
        {
            colorPalette.ChangeTextColour(_text, colorPalette.GetWhite());
        }           
    }

    #endregion

    #region Game Over
    public void ShowGameOverText(bool _isGameOver)
    {
        gameOverTextPanel.SetActive(_isGameOver);
    }
    #endregion

    #region Date Time
    public void SetTimeTextUI(DateTime _time)
    {
        timeHourText.SetText(_time.ToString("HH : mm")); // HH : mm "mm : ss"
        dayText.SetText(_time.ToString("ddd"));
    }
    #endregion

    #region Weather
    public void SetTemperatureTextUI(int _num)
    {
        temperatureText.SetText(_num.ToString()+ "°C"); 
    }
    #endregion


}
