using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource backgroundMusic;
    public AudioSource backgroundCrowdNoise;
    [SerializeField] AudioClip backgroundDayMusic;
    [SerializeField] AudioClip backgroundNightMusic;

    [Header("Background Waves")]
    [SerializeField] AudioSource backgroundWaves;
    [SerializeField] AudioClip wavesSound;

    [Header("Background Ambient")]
    public AudioSource backgroundAmbientBirdsNoise;
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip dayBirdsSound;
    [SerializeField] AudioClip parkSound;
    bool isClipSwitched = false;


    [Header("UISFX")]
    [SerializeField] AudioSource soundEffectsAudio;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip menuOpenSound;
    [SerializeField] AudioClip messageSound;
    [SerializeField] AudioClip moneySound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    [Header("Player")]
    [SerializeField] AudioClip[] sighSound;
    [SerializeField] AudioClip whistleSound;
    [SerializeField] AudioClip gulpSound;

    [Header("SoundFX")]
    [SerializeField] AudioClip lootBeepSound;
    [SerializeField] AudioClip lootBeepFoundSound;

    bool isPlayed = false;

    static AudioManager Instance;
    TimeController timeController;
    public AudioManager GetAudioManagerInstance()
    { return Instance; }

    void Awake()
    {
        //  ManageSingleton();
        timeController = FindObjectOfType<TimeController>();
        backgroundMusic.volume = PlayerPrefs.GetFloat("VolumeMusic", VolumeDataBetweenLevels.volumeLevelMusic);
        backgroundWaves.volume = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.volumeLevelMusic);
        backgroundAmbientBirdsNoise.volume = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.volumeLevelAmbient);
        soundEffectsAudio.volume = PlayerPrefs.GetFloat("VolumeSounds", VolumeDataBetweenLevels.volumeLevelSounds);
    }

    void ManageSingleton()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false); /*we disable it on Awake before we destroy it, 
                                          * so no component will try to access it*/
            Destroy(gameObject);
        }

        else
        /* we need to transit this AudioPlayer  
         * through all the rest of the scenes on Load*/
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  /*the existing AudiPlayer will be passed to another scene*/
        }
    }

    private void Start()
    {
        backgroundAmbientBirdsNoise.clip = dayBirdsSound;
    }

    void Update()
    {
        SwitchBetweenAmbientSound();
    }

    #region Player Sigh
    public void PlaySigh()
    {
        int index = Random.Range(0, sighSound.Length);
        soundEffectsAudio.PlayOneShot(sighSound[index], soundEffectsAudio.volume);
    }

    public void PlaySighOnce(float _delay)
    {
        StartCoroutine(PlaySighRoutine(_delay));
    }

    IEnumerator PlaySighRoutine(float _delay)
    {
        if (!isPlayed)
        {
            isPlayed = true;
            PlaySigh();
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }

    #endregion

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
            backgroundMusic.clip = backgroundNightMusic;
            backgroundMusic.Play();
            isClipSwitched = false;
        }
    }

    #endregion
    public void PlayGulp()
    {
        soundEffectsAudio.PlayOneShot(gulpSound, soundEffectsAudio.volume);
    }
    public void PlayWhistle()
    {
        soundEffectsAudio.PlayOneShot(whistleSound, soundEffectsAudio.volume);
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
            LootBeepSFX();
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }
    #endregion

    #region UI
    public void PlayClickSound()
    {
        soundEffectsAudio.PlayOneShot(clickSound, soundEffectsAudio.volume);
    }

    public void PlayMenuSound()
    {
        soundEffectsAudio.PlayOneShot(menuOpenSound, soundEffectsAudio.volume);
    }

    public void PlayMessageSound()
    {
        soundEffectsAudio.PlayOneShot(messageSound, soundEffectsAudio.volume);
    }

    public void PlayMessageSoundOnce()
    {
        StartCoroutine(PlayMessageSFXRoutine());
    }

    IEnumerator PlayMessageSFXRoutine()
    {
        float _delay = 5f;

        if (!isPlayed)
        {
            isPlayed = true;
            PlayMessageSound();
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }

    #endregion

}
