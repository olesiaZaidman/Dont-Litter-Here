using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameInputInstructions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startNavigation;
    [SerializeField] GameObject startText;

    [SerializeField] GameObject garbagePickText;
    [SerializeField] GameObject fatigueText;

    // public static bool isGameOver;
    static bool isTimeForFatigueMessage = false;
    static bool isStartMessage = false;
    public static bool isGarbageMessage = false;
    int numberOfTexts = 0;
    static bool isMessageWindowOpen = false;

    AudioManager audioManager;
    public static GameInputInstructions Instance;

    public GameInputInstructions()
    /*Constructor is called before any Unity's Initialization Functions*/
    {
        Instance = this;
    }

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();


        fatigueText.SetActive(false);
        garbagePickText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isGarbageMessage)
        {
            isGarbageMessage = true;
            ShowGarbageMessage();
        }
    }
    void Update()
    {

        if ((Input.GetKey(KeyCode.Space)))
        {
            StopCoroutine(ShowFatigueTextRoutine());
            StopCoroutine(ShowGarbageTextRoutine());
            fatigueText.SetActive(false);
            garbagePickText.SetActive(false);
            isMessageWindowOpen = false;
        }

        if (Fatigue.Instance.GetFatiguePoints() >= 30 && !isTimeForFatigueMessage)
        {
            ShowFatigueMessage();
        }
    }


    #region Start Navigation Message

    void UpdateAndShowStartNavigationMessages()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (numberOfTexts == 1)
            {
                startText.SetActive(false);
                StopCoroutine(ShowStartNavigationRoutine("Press [W] or [S] or arrows to move"));
                StartCoroutine(StartNavigationCoolDownRoutine());
                StartCoroutine(ShowStartNavigationRoutine("Press [Left SHIFT] to run when moving"));
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (numberOfTexts == 2)
            {
                startText.SetActive(false);
                StopCoroutine(ShowStartNavigationRoutine("Press [Left SHIFT] to run when moving"));
            }
        }

    }
    public IEnumerator ShowStartNavigationRoutine(string _text)
    {
        if (!isStartMessage)
        {
            audioManager.PlayMessageSoundOnce();
            isStartMessage = true;
            float _delay = 5f;
            startNavigation.SetText(_text);
            startText.SetActive(true);
            numberOfTexts += 1;
            yield return new WaitForSeconds(_delay);
            startText.SetActive(false);
        }
    }
    public IEnumerator StartNavigationCoolDownRoutine()
    {
        yield return new WaitForSeconds(3f);
        isStartMessage = false;
    }
    #endregion

    #region Fatigue Message
    //public void ShowFatigueText()
    //{
    //    fatigueText.SetActive(true);
    //}
    void ShowFatigueMessage()
    {
        isTimeForFatigueMessage = true;
        StartCoroutine(ShowFatigueTextRoutine());
    }
    public IEnumerator ShowFatigueTextRoutine()
    {
        if (!isMessageWindowOpen)
        {
            audioManager.PlayMessageSoundOnce();
            isMessageWindowOpen = true;
            float _delay = 4f;
            fatigueText.SetActive(true);
            yield return new WaitForSeconds(_delay);
            fatigueText.SetActive(false);
            isMessageWindowOpen = false;
        }
    }
    #endregion


    #region Garbage Message
    public void ShowGarbageMessage()
    //Player triggers it with first OnTriggerEnter with garbage!
    {
        isTimeForFatigueMessage = true;
        StartCoroutine(ShowGarbageTextRoutine());
    }
    public IEnumerator ShowGarbageTextRoutine()
    {
        if (!isMessageWindowOpen)
        {
            isMessageWindowOpen = true;
            float _delay = 4f;
            audioManager.PlayMessageSoundOnce();
            garbagePickText.SetActive(true);
            yield return new WaitForSeconds(_delay);
            garbagePickText.SetActive(false);
            isMessageWindowOpen = false;
        }

    }
    #endregion
}
