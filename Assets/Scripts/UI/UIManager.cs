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
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject salaryText;
    public static bool isGameOver;

    AudioManager audioManager;
    void Awake()
    {
        isGameOver = false;
        audioManager = FindObjectOfType<AudioManager>();
        gameOverText.SetActive(isGameOver);
        salaryText.SetActive(false);
    }

    private void Start()
    {
        SetScoreTextUI(0);
    }


    void Update()
    {
        if (isGameOver)
        {
            ShowGameOverText();
        }

        if ((Input.GetKey(KeyCode.Space)))
        {
            StopCoroutine(ShowSalaryTextRoutine());
            salaryText.SetActive(false);
        }
    }

    public IEnumerator ShowSalaryTextRoutine()
    {//We've all got to earn our daily bread somehow
        float _delay = 3f;
        audioManager.PlayMoneySFXOnce();
        salaryText.SetActive(true);
        yield return new WaitForSeconds(_delay);
        salaryText.SetActive(false);
    }

    public void ShowGameOverText()
    {
        gameOverText.SetActive(isGameOver);
    }
    public void SetScoreTextUI(int _money)
    {
       score.SetText(_money.ToString());
    }

    public void SetTimeTextUI(DateTime _time)
    {
        time.SetText(_time.ToString("HH : mm")); // HH : mm "mm : ss"
        day.SetText(_time.ToString("ddd"));
    }
}
