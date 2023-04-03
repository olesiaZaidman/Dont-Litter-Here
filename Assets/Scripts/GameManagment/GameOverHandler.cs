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
    UIGameStatsManager uiManager;
    private void Awake()
    {
        isNewRecord = false;
        isRecordUpdated = false;
        isGameFinished = false;
        isGameReadyToStart = false;
        isGameOver = false;
        Instance = this;
        audioManager = FindObjectOfType<AudioManager>();
        uiManager = FindObjectOfType<UIGameStatsManager>();
        // ResetMoneyPoints();
    }

     void Update()
    {

        //if (GameOverHandler.isGameOver)
        //{
        //    uiManager.ShowGameOverText(GameOverHandler.isGameOver);
        //    GameOverHandler.Instance.GameOver();
        //}

        //if ((Input.GetKey(KeyCode.Space)))
        //{
        //    uiManager.StopCoroutine(uiManager.ShowSalaryTextRoutine());
        //    uiManager.salaryTextPanel.SetActive(false);
        //}
        //  UpdateAndShowStartNavigationMessages();
       
    }

    public void ResetMoneyPoints()
    {
        Debug.Log("CurrentScore is reset to 0");
        PlayerDataHandler.CurrentScore = 0;// moneyScore = 0;
    }


    public void GameOver() //UIGameStatsManager calls this method in  Update()
    {
        if (isGameOver && !isGameFinished)
        {
            Debug.Log("GameOver");
            isGameFinished = true;

            PlayerDataHandler.SaveDataEntryToTheList();

         //   HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(PlayerDataHandler.currentPlayerName, PlayerDataHandler.CurrentScore));
            /*AddHighScoreIfPossiable Adds the data 'name-score' to the highScoresList*/
            UIGameStatsManager.Instance.ShowGameOverText(isGameOver);
            StartCoroutine(WaitAndLoadGameRoutine(4f, "FinalLeaderboard"));
            if (audioManager != null)
            {
                audioManager.PlayLoose();
                audioManager.PlayMessageSoundOnce();
            }
        }
    }

    public void NewRecord()  //UIGameStatsManager calls this method in  Update()
    {

        if (isNewRecord & !isRecordUpdated)
        {

            Debug.Log("NewRecord");
            isRecordUpdated = true; 
         //   HighScoreHandler.AddHighScoreIfPossiable(new HighScoreElement(PlayerDataHandler.currentPlayerName, PlayerDataHandler.CurrentScore));
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
