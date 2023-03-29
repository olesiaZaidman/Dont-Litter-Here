using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    //  TODO: 
    //MAYBE Connect NewRecord() to TimeMorning and show only in the morning once

    public static bool isGameReadyToStart;

    public static bool isGameFinished;
    public static bool isGameOver;

    public static bool isNewRecord;
    public static bool isRecordUpdated;

    public static GameOverHandler Instance;
    AudioManager audioManager;

    private void Awake()
    {
        isNewRecord = false;
        isRecordUpdated = false;
        isGameFinished = false;
        isGameReadyToStart = false;
        isGameOver = false;
        Instance = this;
        audioManager = FindObjectOfType<AudioManager>();
        ResetMoneyPoints();
    }

     void Update()
    {
        GameOver();
        NewRecord();
    }

    public void ResetMoneyPoints()
    {
        Debug.Log("CurrentScore is reset to 0");
        HighScoreManager.Instance.CurrentScore = 0;// moneyScore = 0;
    }


    public void GameOver() //DeathZone calls this method
    {
        if (isGameOver && !isGameFinished)
        {
            isGameFinished = true;
            HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(HighScoreManager.currentPlayerName, HighScoreManager.Instance.CurrentScore));
            /*AddHighScoreIfPossiable Adds the data 'name-score' to the highScoresList*/
            UIGameStatsManager.Instance.ShowGameOverText(GameOverHandler.isGameOver);
            StartCoroutine(WaitAndLoadGameRoutine(4f, "FinalLeaderboard"));
            if (audioManager != null)
            {
                audioManager.PlayLoose();
                audioManager.PlayMessageSoundOnce();
            }
        }
    }

    public void NewRecord() 
    {
        if (isNewRecord & !isRecordUpdated)
        {
            isRecordUpdated = true; 
            HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(HighScoreManager.currentPlayerName, HighScoreManager.Instance.CurrentScore));
            /*AddHighScoreIfPossiable Adds the data 'name-score' to the highScoresList*/

            if (audioManager != null)
            {
                audioManager.PlayWin();
            }
            StartCoroutine(NewRecordCooldDownRoutine(3f));
        }
    }

    IEnumerator NewRecordCooldDownRoutine(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        isNewRecord = false;
        isRecordUpdated = false;
    }

    IEnumerator WaitAndLoadGameRoutine(float _delay, string _sceneName)
    {
        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(_sceneName);
    }

}
