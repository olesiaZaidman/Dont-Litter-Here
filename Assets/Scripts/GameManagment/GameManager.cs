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

    [SerializeField] GameObject menu;
    [SerializeField] GameObject uiGameStats;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject volumeCanvas;


    public static bool isMenuOpen = false;
    public static bool isSettingsOpen = false;
    private void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        audioManager = FindObjectOfType<AudioManager>();
        isGameOver = false;
        Instance = this;

        isMenuOpen = false;
        uiGameStats.SetActive(true);
        menu.SetActive(false);
        menuCanvas.SetActive(false);
        volumeCanvas.SetActive(false);
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
            if (!isMenuOpen && !isSettingsOpen)//Game > Menu 
            {
                Time.timeScale = 0;
                audioManager.PlayMenuSound();
                menu.SetActive(true);
                uiGameStats.SetActive(false);
                isMenuOpen = true;
                menuCanvas.SetActive(true);
                volumeCanvas.SetActive(false);
            }

            else if (isMenuOpen && isSettingsOpen)  // Settings > Menu
            {
                audioManager.PlayMenuSound();
                isSettingsOpen = false;
                menuCanvas.SetActive(true);
                volumeCanvas.SetActive(false);
            }

            else if (isMenuOpen && !isSettingsOpen)//Menu > Game
            {
                Time.timeScale = 1;
                audioManager.PlayMenuSound();
                menu.SetActive(false);
                uiGameStats.SetActive(true);
                menuCanvas.SetActive(false);
                volumeCanvas.SetActive(false);
                isMenuOpen = false;                
            }
        }
    }

    #endregion
    #region Menu
    public void OnClickResume() //Resume
    {
        Time.timeScale = 1;
        audioManager.PlayClickSound();
        menu.SetActive(false);
        uiGameStats.SetActive(true);
        isMenuOpen = false;
    }

    public void OnSettingsClick() //Menu > Settings
    {
        audioManager.PlayClickSound();

        if (isMenuOpen && !isSettingsOpen)
        {
            isSettingsOpen = true;
            audioManager.PlayMenuSound();
            menuCanvas.SetActive(false);
            volumeCanvas.SetActive(true);
        }
    }

    public void OnSettingsClickBack() //Menu > Settings
    {
        if (isMenuOpen && isSettingsOpen)  // Settings > Menu
        {
            audioManager.PlayMenuSound();
            isSettingsOpen = false;
            menuCanvas.SetActive(true);
            volumeCanvas.SetActive(false);
        }
    }

    public void OnClickVolumeSettings() //Settings
    {
        audioManager.PlayClickSound();
        menu.SetActive(false);
       // volumeSettingsCanvas.SetActive(true);
    }

    public void OnClickExitGame()
    {
        audioManager.PlayClickSound();
      //  SceneManager.LoadScene(0);
       Application.Quit();
    }

    #endregion

    #region Volume
    public void OnClickBackMenu()
    {
        audioManager.PlayClickSound();
        menu.SetActive(true);
      //  volumeSettingsCanvas.SetActive(false);
    }
    #endregion
}
