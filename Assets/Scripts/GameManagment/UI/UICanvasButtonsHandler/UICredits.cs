using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICredits : MonoBehaviour
{
    AudioManagerBase audioManagerBase;
    private void Awake()
    {
        audioManagerBase = FindObjectOfType<AudioManagerBase>();
    }
    public void OnClickBackFromCredits()
    {
        audioManagerBase.PlayClickSound();
        SceneManager.LoadScene("MainMenu");
    }
}
