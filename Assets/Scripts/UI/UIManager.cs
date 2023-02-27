using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    ScoreManager scoreManager;
    [SerializeField] GameObject gameOvertext;
    public static bool isGameOver;
    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();//ScoreManager.Instance;
        isGameOver = false;
        gameOvertext.SetActive(isGameOver);

    }
    private void Start()
    {
        SetScoreTextUI();
    }


    void Update()
    {
        if (isGameOver)
        {
            gameOvertext.SetActive(isGameOver);
        }
    }

    public void SetScoreTextUI()
    {
       // score.SetText(scoreManager.GetCleanRatingPoints().ToString());
    }
}
