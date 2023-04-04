using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GamePlayUICanvasButtonsHandler : StartMenuUICanvasButtonsHandler
{
    AudioManager audioManager;

    [Header("Game Stats UI_BeachRating_Fatigue_etc")]
    [SerializeField] GameObject uiGameStats;
    [SerializeField] GameObject areYouSure;
    public static bool isMenuOpen = false;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

        UIStartSetUp();
    }

    public override void UIStartSetUp()
    {
        isMenuOpen = false;
        uiGameStats.SetActive(true);
        areYouSure.SetActive(false);
        mainMenu.SetActive(false);
        submenuPanelCanvas.SetActive(false);
        submenuSettingsCanvas.SetActive(false);
    }

    void Update()
    {
        OpenMenuOnInput();

    }

    #region User_UI

    public override void OpenMenuOnInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isMenuOpen && !isSettingsOpen)//Game > Menu 
            {
                Time.timeScale = 0;
                audioManager.PlayMenuSound();
                mainMenu.SetActive(true);
                uiGameStats.SetActive(false);
                isMenuOpen = true;
                submenuPanelCanvas.SetActive(true);
                submenuSettingsCanvas.SetActive(false);
            }

            else if (isMenuOpen && isSettingsOpen)  // Settings > Menu
            {
                audioManager.PlayMenuSound();
                isSettingsOpen = false;
                submenuPanelCanvas.SetActive(true);
                submenuSettingsCanvas.SetActive(false);
            }

            else if (isMenuOpen && !isSettingsOpen)//Menu > Game
            {
                Time.timeScale = 1;
                audioManager.PlayMenuSound();
                mainMenu.SetActive(false);
                uiGameStats.SetActive(true);
                submenuPanelCanvas.SetActive(false);
                submenuSettingsCanvas.SetActive(false);
                isMenuOpen = false;
            }
        }
    }

    #endregion

    #region Menu Canvas
    public void OnClickResume() //Resume
    /*UI_Menu_Canvas > Panel_Menu > Continue_Button */
    /*&& UI_Menu_Canvas > Panel_Menu > Back_Button */
    {
        Time.timeScale = 1;
        audioManager.PlayClickSound();
        mainMenu.SetActive(false);
        uiGameStats.SetActive(true);
        isMenuOpen = false;
    }

    public override void OnSettingsClick() //Menu > Settings
    {
        /*UI_Menu_Canvas > Panel_Menu >Settings_Button */
        audioManager.PlayClickSound();

        if (isMenuOpen && !isSettingsOpen)
        {
            isSettingsOpen = true;
            audioManager.PlayMenuSound();
            submenuPanelCanvas.SetActive(false);
            submenuSettingsCanvas.SetActive(true);
        }
    }

    public void OnClickFinishGame()  /*UI_Start_Menu_Canvas > Panel_Menu >  Quit_Button */
    {
        Time.timeScale = 1;
        audioManager.PlayClickSound();
        SceneManager.LoadScene("FinalLeaderboard");
        PlayerDataHandler.SaveDataEntryToTheList();
    }

    public void OnClickQuitSure()  /*UI_Start_Menu_Canvas > Panel_Menu >  Quit_Button */
    {
        audioManager.PlayClickSound();
        areYouSure.SetActive(true);
        submenuPanelCanvas.SetActive(false);
    }


    public void OnClickNotSureBAckToGame()  /*UI_Start_Menu_Canvas > Panel_Menu >  Quit_Button */
    {
        audioManager.PlayClickSound();
        areYouSure.SetActive(false);
        submenuPanelCanvas.SetActive(true);
    }


    public void OnQuitToRatingButtonClick()
    {
        Time.timeScale = 1;
        float _sceneLoadDelay = 1f;
        string _sceneName = "FinalLeaderboard";
        StartCoroutine(WaitAndLoadGameRoutine(_sceneLoadDelay, _sceneName));
    }

    #endregion
    #region Settings Canvas
    public override void OnSettingsClickBack() // Settings > Menu
    {
        /*&& UI_Menu_Canvas > Settings_Panels > Panel_Settings > Back_Button */
        if (isMenuOpen && isSettingsOpen) 
        {
           // VolumeDataBetweenLevels.UpdateSoundData();
            audioManager.PlayMenuSound();
            isSettingsOpen = false;
            submenuPanelCanvas.SetActive(true);
            submenuSettingsCanvas.SetActive(false);
        }
    }

    public void OnClickBackMenu() // Settings > Menu
    {
        /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Back_Button */
        audioManager.PlayClickSound();
        submenuPanelCanvas.SetActive(true);
        submenuSettingsCanvas.SetActive(false);
    }
    #endregion

  
}
