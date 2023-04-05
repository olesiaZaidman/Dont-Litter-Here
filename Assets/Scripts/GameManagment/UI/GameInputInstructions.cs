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

    void Start()
    {
     //   StartCoroutine(ShowStartNavigationRoutine());
    }
    void Update()
    {
        //    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
        //|| Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    startText.SetActive(false);
        //    StopCoroutine(ShowStartNavigationRoutine());
        //}

        if (Input.GetKey(KeyCode.Space))
        {
            StopCoroutine(ShowGarbageTextRoutine());   
            garbagePickText.SetActive(false);
            isMessageWindowOpen = false;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            StopCoroutine(ShowFatigueTextRoutine());
            fatigueText.SetActive(false);
            isMessageWindowOpen = false;
        }

        if (Fatigue.Instance.GetFatiguePoints() >= 30 && !isTimeForFatigueMessage)
        {
            ShowFatigueMessage();
        }
    }


    #region Start Navigation Message

    public IEnumerator ShowStartNavigationRoutine()
    {
        if (!isStartMessage)
        {
          //  audioManager.PlayMessageSoundOnce();
            isStartMessage = true;
            float _delay = 4f;
            startText.SetActive(true);
            yield return new WaitForSeconds(_delay);
            startText.SetActive(false);
        }
    }

    #endregion

    #region Fatigue Message
    void ShowFatigueMessage()
    {
        isTimeForFatigueMessage = true;
        StartCoroutine(ShowFatigueTextRoutine());
    }
    public IEnumerator ShowFatigueTextRoutine()
    {
        if (!isMessageWindowOpen)
        {
            garbagePickText.SetActive(false);
            startText.SetActive(false);
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
            fatigueText.SetActive(false);
            startText.SetActive(false);
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
