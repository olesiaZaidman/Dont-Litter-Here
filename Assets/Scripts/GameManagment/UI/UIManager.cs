using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI day;
    [SerializeField] TextMeshProUGUI temperature;
    [SerializeField] TextMeshProUGUI startNavigation;

    //18°C
    [SerializeField] GameObject startText;
    [SerializeField] GameObject garbagePickText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject salaryText;
    [SerializeField] GameObject fatigueText;

   // public static bool isGameOver;
    static bool isTimeForFatigueMessage = false;
    static bool isStartMessage = false;
    public static bool isGarbageMessage = false;
    int numberOfTexts = 0;


    static bool isMessageWindowOpen = false;
    AudioManager audioManager;
    void Awake()
    {     
        audioManager = FindObjectOfType<AudioManager>();
        gameOverText.SetActive(GameManager.isGameOver);
        salaryText.SetActive(false);
        fatigueText.SetActive(false);
        garbagePickText.SetActive(false);
    }

    private void Start()
    {
        SetScoreTextUI(0);
    //    StartCoroutine(ShowStartNavigationRoutine("Press [W] or [S] or arrows to move"));
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isGarbageMessage)
        {
            isGarbageMessage = true;
            ShowGarbageMessage();
        }
    }

    void Update()
    {
        if (GameManager.isGameOver)
        {
            ShowGameOverText();
        }

        if ((Input.GetKey(KeyCode.Space)))
        {
            StopCoroutine(ShowSalaryTextRoutine());
            StopCoroutine(ShowFatigueTextRoutine());
            StopCoroutine(ShowGarbageTextRoutine());

            salaryText.SetActive(false);
            fatigueText.SetActive(false);
            garbagePickText.SetActive(false);
            isMessageWindowOpen = false;
        }

        if (Fatigue.Instance.GetFatiguePoints() >= 30 && !isTimeForFatigueMessage)
        {
            ShowFatigueMessage();
        }

    //  UpdateAndShowStartNavigationMessages();
    }


    #region Start Navigation Message

    void UpdateAndShowStartNavigationMessages()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (numberOfTexts == 1)
            {
                startText.SetActive(false);
                StopCoroutine(ShowStartNavigationRoutine("Press [W] or [S] or arrows to move"));
                StartCoroutine(StartNavigationCoolDownRoutine());
                StartCoroutine(ShowStartNavigationRoutine("Press [Left SHIFT] to run when moving"));
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (numberOfTexts == 2)
            {
                startText.SetActive(false);
                StopCoroutine(ShowStartNavigationRoutine("Press [Left SHIFT] to run when moving"));
            }
        }

    }
    public IEnumerator ShowStartNavigationRoutine(string _text)
    {
        if (!isStartMessage)
        {
            audioManager.PlayMessageSoundOnce();
            isStartMessage = true;
            float _delay = 5f;
            startNavigation.SetText(_text);
            startText.SetActive(true);
            numberOfTexts += 1;
            yield return new WaitForSeconds(_delay);
            startText.SetActive(false);
        }
    }
    public IEnumerator StartNavigationCoolDownRoutine()
    {
        yield return new WaitForSeconds(3f);
        isStartMessage = false;
    }
    #endregion

    #region Garbage Message
    public void ShowGarbageMessage() 
        //Player triggers it with first OnTriggerEnter with garbage!
    {
        isTimeForFatigueMessage = true;
        StartCoroutine(ShowGarbageTextRoutine());
    }
    public IEnumerator ShowGarbageTextRoutine()
    {
        if (!isMessageWindowOpen)
        {
            isMessageWindowOpen = true;
            float _delay = 4f;
            audioManager.PlayMessageSoundOnce();
            garbagePickText.SetActive(true);
            yield return new WaitForSeconds(_delay);
            garbagePickText.SetActive(false);
            isMessageWindowOpen = false;
        }

    }
    #endregion

    #region Salary Message

    public IEnumerator ShowSalaryTextRoutine()
    {//We've all got to earn our daily bread somehow
        float _delay = 3f;
        audioManager.PlayMoneySFXOnce();
        salaryText.SetActive(true);
        yield return new WaitForSeconds(_delay);
        salaryText.SetActive(false);
    }

    public void SetScoreTextUI(int _money)
    {
        score.SetText(_money.ToString());
    }

    #endregion

    #region Fatigue Message
    //public void ShowFatigueText()
    //{
    //    fatigueText.SetActive(true);
    //}
    void ShowFatigueMessage()
    {
        isTimeForFatigueMessage = true;
        StartCoroutine(ShowFatigueTextRoutine());
    }
    public IEnumerator ShowFatigueTextRoutine()
    { 
        if (!isMessageWindowOpen)
        {
            audioManager.PlayMessageSoundOnce();
            isMessageWindowOpen = true;
            float _delay = 4f;
            fatigueText.SetActive(true);
            yield return new WaitForSeconds(_delay);
            fatigueText.SetActive(false);
            isMessageWindowOpen = false;
        }
    }
    #endregion

    #region Game Over
    public void ShowGameOverText()
    {
        gameOverText.SetActive(GameManager.isGameOver);
    }
    #endregion

    #region Date Time
    public void SetTimeTextUI(DateTime _time)
    {
        time.SetText(_time.ToString("HH : mm")); // HH : mm "mm : ss"
        day.SetText(_time.ToString("ddd"));
    }
    #endregion

    #region Weather
    public void SetTemperTextUI(int _num)
    {
        temperature.SetText(_num.ToString()+ "°C"); 
    }
    #endregion


}
