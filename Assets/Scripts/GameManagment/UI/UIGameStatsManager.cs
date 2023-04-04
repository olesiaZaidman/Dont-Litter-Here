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
    TemperatureManager temperatureManager;
    AudioManager audioManager;
    public static UIGameStatsManager Instance;

    void Awake()
    {
        Instance = this;
        audioManager = FindObjectOfType<AudioManager>();
        colorPalette = FindObjectOfType<ColorCollection>();
        temperatureManager = FindObjectOfType<TemperatureManager>();
        salaryTextPanel.SetActive(false);
        gameOverTextPanel.SetActive(GameOverHandler.isGameOver);        
    }

    private void Start()
    {
        SetScoreTextUI(PlayerDataHandler.CurrentScore);
    }

 

    void Update()
    {
        ChangeTextColorIfNeeded(temperatureText,  colorPalette.GetRed(), colorPalette.GetWhite(), temperatureManager.GetTemperature() > 29);   
     //   ChangeTextColorIfNeeded(scoreText, colorPalette.GetYellow(), colorPalette.GetWhite(), GameOverHandler.isNewRecord);

        //if (GameOverHandler.isNewRecord)
        //{
        //    GameOverHandler.Instance.NewRecord();
        //}

        if (GameOverHandler.isGameOver)
        {
           ShowGameOverText(GameOverHandler.isGameOver);
           GameOverHandler.Instance.GameOver();
        }

        if ((Input.GetKey(KeyCode.Space)))
        {
           StopCoroutine(ShowSalaryTextRoutine());
           salaryTextPanel.SetActive(false);
        }
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

    public void ChangeTextColorIfNeeded(TextMeshProUGUI _text, Color _colorWhenChange, Color _defaultColor, bool _isChange)
    {
        if (_isChange)
        {
            colorPalette.ChangeTextColour(_text, _colorWhenChange);
        }
        else if (!_isChange)
        {
            colorPalette.ChangeTextColour(_text, _defaultColor);
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
