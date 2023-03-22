using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public bool isGameReadyToStart = false;
    public static GameManager Instance;

    // ScoreManager.Instance

    private void Awake()
    {
        isGameOver = false;
        Instance = this;
    }

    public void GameOver() //DeathZone calls this method
    {
        // HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(HighScoreManager.Instance.bestScorePlayerName, HighScoreManager.Instance.bestScore));
        HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(HighScoreManager.currentPlayerName, HighScoreManager.Instance.CurrentScore));
        UIManager.Instance.ShowBestPlayerScoreUIInfo();
        isGameOver = true;
        UIManager.Instance.ShowGameOverText(GameManager.isGameOver);
    }

}
