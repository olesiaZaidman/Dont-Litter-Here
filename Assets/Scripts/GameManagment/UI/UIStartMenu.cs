using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIStartMenu : MonoBehaviour
{
    AudioManagerBase audioManager;
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
    [SerializeField] protected GameObject submenuDataPersistence;

    //[SerializeField] TextMeshProUGUI[] buttonTexts;  OR List<TextMeshProUGUI> buttonTexts = new List<TextMeshProUGUI>();
    bool isClicked = false;
    bool isPlayerStanding = false;
    public static bool isSettingsOpen = false;

    bool isDataNameColorPickerOpen = false;


    private void Awake()
    {
        //  colorPalette = FindObjectOfType<ColorCollection>();
        player = FindObjectOfType<PlayerBase>();
        audioManager = FindObjectOfType<AudioManagerBase>();
        UIStartSetUp();
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
                audioManager.PlayMenuSound();
                isSettingsOpen = false;
                submenuPanelCanvas.SetActive(true);
                submenuSettingsCanvas.SetActive(false);
            }

            if (isDataNameColorPickerOpen)
            {
                isDataNameColorPickerOpen = false;
                isClicked = false;
                audioManager.PlayClickSound();
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

    #region Quit
    public void OnClickExitGame()  /*UI_Start_Menu_Canvas > Panel_Menu >  Quit_Button */
    {
        audioManager.PlayClickSound();
        //  SceneManager.LoadScene(0);
        Application.Quit();
    }
    #endregion

    #region Data_ColorPickerCanvas

    //[GAME STARTS at Level Manager]
    public void OnClickLoadNameColorPickerCanvas() /*UI_Start_Menu_Canvas > Panel_Menu >  Start_Button */
    {
        float _loadDelay;
        isDataNameColorPickerOpen = true;

        if (!isClicked)
        {
            VolumeDataBetweenLevels.UpdateSoundData();
            if (audioManager != null)
            {
                audioManager.PlayClickSound();
            }

            isClicked = true;
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.ResetMoneyScore();
            }
            lights.SetActive(true);
            signsLight.SetActive(true);

            if (!isPlayerStanding)
            {
                _loadDelay = 3f;
                isPlayerStanding = true;
                if (audioManager != null)
                {
                    audioManager.PlaySigh();
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
        audioManager.PlayMenuSound();
        submenuPanelCanvas.SetActive(false);
        submenuDataPersistence.SetActive(true);
    }

    public virtual void OnClickBackFromData()
    {
        if (isDataNameColorPickerOpen)
        {
            isDataNameColorPickerOpen = false;
            isClicked = false;
            audioManager.PlayClickSound();
            submenuPanelCanvas.SetActive(true);
            submenuDataPersistence.SetActive(false);
            lights.SetActive(false);
            playerLight.SetActive(false);
            signsLight.SetActive(false);
        }
    }

    #endregion

    #region DataPersistent
    public void OnClickStartGame()
    /*UI_Start_Menu_Canvas > Panel_Menu >  Start_Button */
    {
        //    startButtonText.color = yellowColor;   OR colorPalette.ChangeTextColour(startButtonText, colorPalette.GetYellow());  

        VolumeDataBetweenLevels.UpdateSoundData();
        audioManager.PlayClickSound();
        SceneManager.LoadScene(1);


        //  StartCoroutine(WaitAndLoad("Game", _sceneLoadDelay));
    }



    //IEnumerator WaitAndLoad(string _sceneName, float _delay)
    //{
    //    yield return new WaitForSeconds(_delay);

    //    SceneManager.LoadScene(_sceneName);
    //}

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


    //public void LoadMainMenu()
    //{
    //    audioManager.PlayClickSound();
    //    SceneManager.LoadScene("MainMenu"); //by name
    //}

    //public void LoadFinalScore()
    //{
    //    float _sceneLoadDelay = 3.5f;
    //    audioManager.PlayClickSound();
    //    StartCoroutine(WaitAndLoad("FinalScore", _sceneLoadDelay));
    //}

}
