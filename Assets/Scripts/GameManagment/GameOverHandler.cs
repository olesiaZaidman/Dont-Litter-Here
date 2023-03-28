using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public static bool isGameReadyToStart;
    public static bool isGameOver;
    public static GameOverHandler Instance;

    // ScoreManager.Instance

    private void Awake()
    {
        isGameReadyToStart = false;
        isGameOver = false;
        Instance = this;
    }

    public void GameOver() //DeathZone calls this method
    {
        isGameOver = true;
        HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(HighScoreManager.currentPlayerName, HighScoreManager.Instance.CurrentScore));
        /*AddHighScoreIfPossiable Adds the data 'name-score' to the highScoresList*/
        UIManager.Instance.ShowGameOverText(GameOverHandler.isGameOver);
    }

}
