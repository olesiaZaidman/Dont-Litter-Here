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

    //public void OnClickExitGame()
    //{
    //    audioManager.PlayClickSound();
    //  //  SceneManager.LoadScene(0);
    //   Application.Quit();
    //}


}
