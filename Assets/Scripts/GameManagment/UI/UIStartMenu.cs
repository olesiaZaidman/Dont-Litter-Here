using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIStartMenu : MonoBehaviour
{
    AudioManagerBase audioManager;
    // ColorCollection colorPalette;

    [Header("Effects")]
    [SerializeField]  GameObject lights;
    [SerializeField] GameObject playerLight;
    [SerializeField] GameObject signsLight;

    [Header("Main Menu")]
    [SerializeField] protected GameObject mainMenu;

    [Header("Submenu Canvases")]
    [SerializeField] protected GameObject submenuPanelCanvas;
    [SerializeField] protected GameObject submenuSettingsCanvas;
    [SerializeField] protected GameObject submenuDataPersistence;

    //[SerializeField] TextMeshProUGUI[] buttonTexts;  OR List<TextMeshProUGUI> buttonTexts = new List<TextMeshProUGUI>();

    public static bool isSettingsOpen = false;
    private void Awake()
    {
      //  colorPalette = FindObjectOfType<ColorCollection>();
        audioManager = FindObjectOfType<AudioManagerBase>();
        UIStartSetUp();

   //     CreateListOfButtonTexts();
      //  ResetColorOfButtonTexts(buttonTexts, colorPalette.GetWhite());
    }

    #region Button Texts
    //void CreateListOfButtonTexts()
    //{
    // //   buttonTexts.Add(startButtonText);
    //    buttonTexts.Add(settingsButtonText);
    //    buttonTexts.Add(quitButtonText);
    //    buttonTexts.Add(creditsButtonText);
    //    buttonTexts.Add(backButtonText);
    //}

    //void ResetColorOfButtonTexts(List<TextMeshProUGUI> _collection, Color _color)
    //{
    //    foreach (var butText in _collection)
    //    {
    //        colorPalette.ChangeTextColour(butText, _color);
    //    }
    //}

    //void ChangeColorOfButtonText(TextMeshProUGUI _text, Color _color) //colorPalette.GetYellow()
    //{
    //    colorPalette.ChangeTextColour(_text, _color);
    //}

    #endregion

    public virtual void UIStartSetUp()
    {
        isSettingsOpen = false;
        lights.SetActive(false);
        playerLight.SetActive(false);
        signsLight.SetActive(false);
        mainMenu.SetActive(true);
        submenuPanelCanvas.SetActive(true);
        submenuSettingsCanvas.SetActive(false);
    }

    #region Settings Menu
    public virtual void OnSettingsClick() //Menu > Settings
    {
        // Settings > Menu
        /*UI_Start_Menu_Canvas > Panel_Menu > Settings_Button */
        audioManager.PlayClickSound();

        if (!isSettingsOpen)
        {
         //   ChangeColorOfButtonText(settingsButtonText, colorPalette.GetYellow());
            isSettingsOpen = true;
            audioManager.PlayMenuSound();
            submenuPanelCanvas.SetActive(false);
            submenuSettingsCanvas.SetActive(true);
        }
    }

    public virtual void OnSettingsClickBack()  // Settings > Menu
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Back_Button */
    {
        if (isSettingsOpen)
        {
            audioManager.PlayMenuSound();
            isSettingsOpen = false;
            submenuPanelCanvas.SetActive(true);
            submenuSettingsCanvas.SetActive(false);
        }
    }
   

    #endregion

    #region Start & Quit
    public void OnClickExitGame()  /*UI_Start_Menu_Canvas > Panel_Menu >  Quit_Button */
    {       
        audioManager.PlayClickSound();
        //  SceneManager.LoadScene(0);
        Application.Quit();
    }

    //[GAME STARTS at Level Manager]


    #endregion

    #region DataPersistent
    public void OnClickStartGame()
    /*UI_Start_Menu_Canvas > Panel_Menu >  Start_Button */
    {
        VolumeDataBetweenLevels.UpdateSoundData();
        audioManager.PlayClickSound();
        SceneManager.LoadScene(1);
    }

    public virtual void OnClickBackFromData()
    {
        audioManager.PlayClickSound();
        submenuPanelCanvas.SetActive(true);
        submenuDataPersistence.SetActive(false);
        lights.SetActive(false);
        playerLight.SetActive(false);
        signsLight.SetActive(false);
    }
    #endregion

    #region Credits
    public void OnClickCredits() /*UI_Start_Menu_Canvas > Panel_Menu >  Credits_Button*/
    {
        audioManager.PlayClickSound();
        //   SceneManager.LoadScene(1); Load Credits Scene
    }

    public virtual void OnClickBackFromCredits()
    {
        audioManager.PlayClickSound();
        SceneManager.LoadScene(0); //load Main menu
    }
    #endregion

}
