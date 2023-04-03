using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StartMenuUICanvasButtonsHandler : MonoBehaviour
{
    /*// TODO
    change text color after lieck with 
    startButtonText.color = yellowColor; 
    OR colorPalette.ChangeTextColour(startButtonText, colorPalette.GetYellow());  
*/
    AudioManagerBase audioManagerBase;
    PlayerBase player;
    // ColorCollection colorPalette;

    [Header("Effects")]
    [SerializeField] GameObject lights;
    [SerializeField] GameObject playerLight;
    [SerializeField] GameObject signsLight;

    [Header("Main Menu")]
    [SerializeField] protected GameObject mainMenu;

    [Header("Submenu Canvases")]
    [SerializeField] protected GameObject submenuPanelCanvas;
    [SerializeField] protected GameObject submenuSettingsCanvas;
    [SerializeField] GameObject submenuDataPersistence;

    //[SerializeField] TextMeshProUGUI[] buttonTexts;  OR List<TextMeshProUGUI> buttonTexts = new List<TextMeshProUGUI>();
    bool isClicked = false;
    bool isPlayerStanding = false;
    public static bool isSettingsOpen = false;

    bool isDataNameColorPickerOpen = false;

    private InputUINameSaver inputNameSaver;

    private void Awake()
    {
        //  colorPalette = FindObjectOfType<ColorCollection>();
        player = FindObjectOfType<PlayerBase>();
        audioManagerBase = FindObjectOfType<AudioManagerBase>();
        UIStartSetUp();
        inputNameSaver = FindObjectOfType<InputUINameSaver>();
        Time.timeScale = 1;
        //     CreateListOfButtonTexts();
        //  ResetColorOfButtonTexts(buttonTexts, colorPalette.GetWhite());
    }


    void Update()
    {
        OpenMenuOnInput();
    }

    public virtual void OpenMenuOnInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsOpen)
            {
                audioManagerBase.PlayMenuSound();
                isSettingsOpen = false;
                submenuPanelCanvas.SetActive(true);
                submenuSettingsCanvas.SetActive(false);
            }

            if (isDataNameColorPickerOpen)
            {
                isDataNameColorPickerOpen = false;
                isClicked = false;
                audioManagerBase.PlayClickSound();
                submenuPanelCanvas.SetActive(true);
                submenuDataPersistence.SetActive(false);
                lights.SetActive(false);
                playerLight.SetActive(false);
                signsLight.SetActive(false);
            }

        }
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
        isDataNameColorPickerOpen = false;
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
        audioManagerBase.PlayClickSound();

        if (!isSettingsOpen)
        {
            //   ChangeColorOfButtonText(settingsButtonText, colorPalette.GetYellow());
            isSettingsOpen = true;
            audioManagerBase.PlayMenuSound();
            submenuPanelCanvas.SetActive(false);
            submenuSettingsCanvas.SetActive(true);
        }
    }

    public virtual void OnSettingsClickBack()  // Settings > Menu
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Back_Button */
    {
        if (isSettingsOpen)
        {
            audioManagerBase.PlayMenuSound();
            isSettingsOpen = false;
            submenuPanelCanvas.SetActive(true);
            submenuSettingsCanvas.SetActive(false);
        }
    }
    #endregion

    #region Quit
    public void OnClickQuitGame()  /*UI_Start_Menu_Canvas > Panel_Menu >  Quit_Button */
    {
        audioManagerBase.PlayClickSound();
        //  SceneManager.LoadScene(0);
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
#endif
    }

    public void OnClickExitGameLoadMainMenu()  /*UI_Start_Menu_Canvas > Panel_Menu >  Quit_Button */
    {
        audioManagerBase.PlayClickSound();
        SceneManager.LoadScene("MainMenu");
        isPlayerStanding = false;
        isClicked = false;

    }

    public void OnExitButtonClick()
    {
        SceneManager.LoadScene("FinalLeaderboard");
        PlayerDataHandler.SaveDataEntryToTheList();
    }
    #endregion

    #region Data_ColorPickerCanvas

    //[GAME STARTS at Level Manager]
    public void OnClickLoadNameColorPickerCanvas() /*UI_Start_Menu_Canvas > Panel_Menu >  Start_Button */
    {
        //TODO
        //REstart Animation after whole game loop
        //when we return from FinalLeaderboard to Main Menu
        float _loadDelay;
        isDataNameColorPickerOpen = true;

        if (!isClicked)
        {
           // VolumeDataBetweenLevels.UpdateSoundData();
            if (audioManagerBase != null)
            {
                audioManagerBase.PlayClickSound();
            }

            isClicked = true;

            if (ScoreManager.Instance != null)
            {
                GameOverHandler.Instance.ResetMoneyPoints();
            }

            lights.SetActive(true);
            signsLight.SetActive(true);

            if (!isPlayerStanding)
            {
                _loadDelay = 3f;
                isPlayerStanding = true;

                if (audioManagerBase != null)
                {
                    audioManagerBase.PlaySigh();
                }

                if (player != null)
                {
                    player.StandUpAnimation();
                }
            }
            else
            { _loadDelay = 0.5f; }

            StartCoroutine(WaitAndOpenDataCanvas(_loadDelay));
        }

    }

    IEnumerator WaitAndOpenDataCanvas(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        playerLight.SetActive(true);
        audioManagerBase.PlayMenuSound();
        submenuPanelCanvas.SetActive(false);
        submenuDataPersistence.SetActive(true);
    }

    public virtual void OnClickBackFromData()
    {
        if (isDataNameColorPickerOpen)
        {
            isDataNameColorPickerOpen = false;
            isClicked = false;
            audioManagerBase.PlayClickSound();
            submenuPanelCanvas.SetActive(true);
            submenuDataPersistence.SetActive(false);
            lights.SetActive(false);
            playerLight.SetActive(false);
            signsLight.SetActive(false);
        }
    }

    #endregion

    #region DataPersistent
    public void OnClickSavePlayerDetails()
    /*UI_Start_Menu_Canvas > 3_Panel_DataPersistent_NameColorPicker >  Start_Button */
    {
        if (inputNameSaver != null)
        {
            PlayerDataHandler.CurentPlayerNameSelected(inputNameSaver.GetInputPlayerName());
            /*GetInputPlayerName: gets playerName from inputField.text (playerName=inputField.text)*/
            /* CurentPlayerNameSelected sets this name from input to currentPlayerName (currentPlayerName = _name)*/
        }
        GameOverHandler.Instance.ResetMoneyPoints();
      //  InputEntriesHandler.AddEntryToTheList();

        //TO DO: should CurentPlayerColorSelected be triggered in OnClickSavePlayerDetails in UIStartMenu?
        //instead to be in  SetSelectedColor  in ColorHandler?

        audioManagerBase.PlayClickSound();
        SceneManager.LoadScene("Game");
    }

    #endregion

    #region Credits
    public void OnClickCredits() /*UI_Start_Menu_Canvas > Panel_Menu >  Credits_Button*/
    {
        audioManagerBase.PlayClickSound();
        //   SceneManager.LoadScene("Credits"); 
    }

    public virtual void OnClickBackToMainFromCredits()
    {
        audioManagerBase.PlayClickSound();
        SceneManager.LoadScene("MainMenu");
    }

    public virtual void OnClickBackToFinalFromCredits()
    {
        audioManagerBase.PlayClickSound();
        SceneManager.LoadScene("FinalLeaderboard");
    }
    #endregion


    #region Abstract Methods

    public IEnumerator WaitAndGameRoutine(float _delay, int _scene)
    {
        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(_scene);
    }

    public IEnumerator WaitAndLoadGameRoutine(float _delay, string _sceneName)
    {
        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(_sceneName);
    }

    //Examples:
    //public void LoadFinalScore()
    //{
    //    float _sceneLoadDelay = 3.5f;
    //    audioManager.PlayClickSound();
    //    StartCoroutine(WaitAndLoad("FinalScore", _sceneLoadDelay));
    //}

    //public void OnMenuButtonClickLoadStartScene()
    //{
    //    int startScene = 0;
    //    StartCoroutine(LoadGameRoutine(sceneLoadDelay, startScene));
    //}


    #endregion

}
