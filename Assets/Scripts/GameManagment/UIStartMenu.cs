using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartMenu : MonoBehaviour
{

    AudioManagerBase audioManager;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject settingsCanvas;


    public static bool isMenuOpen = false;
    public static bool isSettingsOpen = false;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManagerBase>();

        isMenuOpen = false;

        menu.SetActive(true);
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }



   
    #region Menu

    public void OnSettingsClick() //Menu > Settings
    {
        audioManager.PlayClickSound();

        if (isMenuOpen && !isSettingsOpen)
        {
            isSettingsOpen = true;
            audioManager.PlayMenuSound();
            menuCanvas.SetActive(false);
            settingsCanvas.SetActive(true);
        }
    }

    public void OnSettingsClickBack()  // Settings > Menu
    {
        if (isMenuOpen && isSettingsOpen) 
        {
            audioManager.PlayMenuSound();
            isSettingsOpen = false;
            menuCanvas.SetActive(true);
            settingsCanvas.SetActive(false);
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

    public void OnClickStartGame()
    {
        audioManager.PlayClickSound();
        SceneManager.LoadScene(1);
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
