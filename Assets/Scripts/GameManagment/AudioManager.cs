using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AudioManagerBase
{
    [Header("Music Clips")]
    [SerializeField] AudioClip backgroundDayMusic;
    [SerializeField] AudioClip backgroundNightMusic;

    [Header("Background Wave Clip")]
    [SerializeField] AudioClip wavesSound;

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
        soundEffectsAudio.PlayOneShot(gulpSound, soundEffectsAudio.volume);
    }

    #region MoneySFX
    public void PlayMoneySFXOnce()
    {
        StartCoroutine(PlayMoneySFXRoutine());
    }

    public void PlayMoneySFX()
    {
        soundEffectsAudio.PlayOneShot(moneySound, soundEffectsAudio.volume);
    }
    IEnumerator PlayMoneySFXRoutine()
    {
        float _delay = 5f;

        if (!isPlayed)
        {
            isPlayed = true;
            PlayMoneySFX();
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }
    #endregion

    #region LootSFX
    public void PlayLootBeepSFXOnce()
    {
        StartCoroutine(PlayLootBeepSFXRoutine());
    }

    public void LootBeepSFX()
    {
        //sfx.PlayOneShot(lootBeepSound, audioVolume);
        // lootBeepSound
    }

    public void LootFoundBeepSFX()
    {
        soundEffectsAudio.PlayOneShot(lootBeepFoundSound, soundEffectsAudio.volume);
    }
    IEnumerator PlayLootBeepSFXRoutine()
    {
        float _delay = 5f;
        if (!isPlayed)
        {
            isPlayed = true;
            LootBeepSFX(); //LootFoundBeepSFX?
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }
    #endregion



}
