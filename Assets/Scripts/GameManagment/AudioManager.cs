using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AudioManagerBase
{
    [Header("Music Clips")]
    [SerializeField] AudioClip backgroundDayMusic;
    [SerializeField] AudioClip backgroundNightMusic;

    [Header("Background Ambient Clips")]
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip dayBirdsSound;
    [SerializeField] AudioClip parkSound;

    [Header("Player")]
    [SerializeField] AudioClip gulpSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    [Header("SoundFX")]
    [SerializeField] AudioClip lootBeepSound;
    [SerializeField] AudioClip lootBeepFoundSound;

    TimeController timeController;


    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();     
    }


    private void Start()
    {
        backgroundAmbientBirdsNoise.clip = dayBirdsSound;
    }

    void Update()
    {
        SwitchBetweenAmbientSound();
    }


    #region Ambient Night / Day
    public void PlayNightAmbience()
    {
        backgroundAmbientBirdsNoise.PlayOneShot(nightSound, backgroundAmbientBirdsNoise.volume);
        // Stop()
    }
    public void StopPlayNightAmbience()
    {
        backgroundAmbientBirdsNoise.Stop();
    }
    void SwitchBetweenAmbientSound()
    {
        if (GoldScanner.isWorking && !isClipSwitched && timeController.IsThisTimeInterval(5, 6)) //Start of Day
        {
            isClipSwitched = true;
            backgroundAmbientBirdsNoise.clip = dayBirdsSound;
            backgroundMusic.clip = backgroundDayMusic;
            backgroundMusic.Play();
            backgroundAmbientBirdsNoise.Play();
           // backgroundAmbientBirdsNoise.volume = backgroundAmbientBirdsNoise.volume;
        }

        else if (timeController.IsThisTimeInterval(9, 10) && isClipSwitched) //9 am
        {
            isClipSwitched = false;
            backgroundAmbientBirdsNoise.clip = parkSound;
            backgroundAmbientBirdsNoise.Play();
         //   backgroundAmbientBirdsNoise.volume = backgroundAmbientBirdsNoise.volume;
        }


        else  if (!isClipSwitched && timeController.IsThisTimeInterval(19,20)) //Night GoldScanner.isScanning && 
        {
            isClipSwitched = true;
            backgroundAmbientBirdsNoise.clip = nightSound;
            backgroundAmbientBirdsNoise.Play();
            backgroundAmbientBirdsNoise.volume = backgroundAmbientBirdsNoise.volume;
        }

        else if (isClipSwitched && GoldScanner.isScanning) //Night GoldScanner.isScanning && 
        {
            //  backgroundMusic.clip = backgroundNightMusic;
            backgroundMusic.Stop();
            isClipSwitched = false;
        }
    }

    #endregion
    public void PlayGulp()
    {
        PlayAudioClip(soundEffectsAudio, gulpSound, soundEffectsAudio.volume);
    }

    #region MoneySFX
    public void PlayMoneySFXOnce()
    {
        float _delay = 5f;
        PlayAudioClipOnce(soundEffectsAudio, moneySound, soundEffectsAudio.volume, _delay);
    }

    public void PlayMoneySFX()
    {
        PlayAudioClip(soundEffectsAudio, moneySound, soundEffectsAudio.volume);
    }
 
    #endregion

    #region LootSFX
    public void PlayLootBeepSFXOnce()
    {
        float _delay = 5f;
        PlayAudioClipOnce(soundEffectsAudio, lootBeepFoundSound, soundEffectsAudio.volume, _delay);
    }

    public void LootFoundBeepSFX()
    {
        PlayAudioClip(soundEffectsAudio, lootBeepFoundSound, soundEffectsAudio.volume);
    }

    #endregion

    #region WinLose
    public void PlayLoose()
    {
        PlayAudioClip(backgroundMusic, loseSound);
    }

    public void PlayWin()
    {
        PlayAudioClip(backgroundMusic, winSound);
    }

    #endregion

}
