using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public bool isGameReadyToStart = false;
    public static GameManager Instance;
    TimeController timeController;
    AudioManager audioManager;
    // ScoreManager.Instance

    [SerializeField] GameObject settingsMenu;
    public static bool isMenuOpen = false;
    private void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        audioManager = FindObjectOfType<AudioManager>();
        isGameOver = false;
        Instance = this;

        isMenuOpen = false;
        settingsMenu.SetActive(false);
    }


    void Update()
    {
        OpenMenuOnInput();
    }

    #region User_UI
    //public void OnClickOpenMenu()
    //{
    //    if (!isMenuOpen)
    //    {
    //        audioManager.PlayClickSound();
    //        settingsMenu.SetActive(true);
    //        isMenuOpen = true;
    //    }
    //    else if (isMenuOpen)
    //    {
    //        audioManager.PlayClickSound();
    //        settingsMenu.SetActive(false);
    //        isMenuOpen = false;
    //    }
    //}

    void OpenMenuOnInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isMenuOpen)
            {
                Time.timeScale = 0;
                audioManager.PlayMenuSound();
                settingsMenu.SetActive(true);
                isMenuOpen = true;
            }
            else if (isMenuOpen)
            {
                Time.timeScale = 1;
                audioManager.PlayMenuSound();
                settingsMenu.SetActive(false);
                isMenuOpen = false;
            }
        }
    }

    #endregion
    #region Menu
    public void OnClickResume() //Resume
    {
        audioManager.PlayClickSound();
        settingsMenu.SetActive(false);
      //  volumeSettingsCanvas.SetActive(false);
    }

    public void OnClickVolumeSettings() //Settings
    {
        audioManager.PlayClickSound();
        settingsMenu.SetActive(false);
       // volumeSettingsCanvas.SetActive(true);
    }

    public void OnClickExitGame()
    {
        audioManager.PlayClickSound();
        SceneManager.LoadScene(0);
        //  Application.Quit();
    }

    #endregion

    #region Volume
    public void OnClickBackMenu()
    {
        audioManager.PlayClickSound();
        settingsMenu.SetActive(true);
      //  volumeSettingsCanvas.SetActive(false);
    }
    #endregion
}
