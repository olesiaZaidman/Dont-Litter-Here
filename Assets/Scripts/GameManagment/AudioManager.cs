using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource backgroundMusic;
    public AudioSource backgroundCrowdNoise;

    [Header("UISFX")]
    [SerializeField] AudioSource soundEffectsAudio;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip menuOpenSound;
    [SerializeField] AudioClip messageSound;
    [SerializeField] AudioClip moneySound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    [Header("Background Waves")]
    [SerializeField] AudioSource backgroundAmbientWaves;
    [SerializeField] AudioClip wavesSound;

    [Header("Background Ambient")]
    public AudioSource backgroundAmbientBirdsNoise;
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip dayBirdsSound;
    bool isClipSwitched = false;

    [Header("Player")]
    [SerializeField] AudioClip[] sighSound;
    [SerializeField] AudioClip whistleSound;
    [SerializeField] AudioClip gulpSound;

    [Header("SoundFX")]
    [SerializeField] AudioClip lootBeepSound;
    [SerializeField] AudioClip lootBeepFoundSound;

    float audioVolumeHalf = 0.5f;
    float audioVolumeMax = 1f;
  //  float audioVolumeMin= 0.1f;

    bool isPlayed = false;

    static AudioManager Instance;

    public AudioManager GetAudioManagerInstance()
    { return Instance; }

    void Awake()
    {
        soundEffectsAudio.volume = audioVolumeHalf;
        backgroundAmbientBirdsNoise.volume = audioVolumeMax;
        backgroundAmbientWaves.volume = audioVolumeHalf;
        //  ManageSingleton();

        //   backgroundMusic.volume = PlayerPrefs.GetFloat("VolumeMusic", DataBetweenLevels.volumeLevelMusic);
        //  backgroundAmbient.volume = PlayerPrefs.GetFloat("VolumeMusic", DataBetweenLevels.volumeLevelMusic);
        //  soundEffectsAudio.volume = PlayerPrefs.GetFloat("VolumeEffects", DataBetweenLevels.volumeLevelEffects);
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
        if (GoldScanner.isScanning && isClipSwitched)
        {
            isClipSwitched = false;
            backgroundAmbientBirdsNoise.clip = nightSound;
            backgroundAmbientBirdsNoise.Play();
         //   backgroundAmbientWaves.volume = backgroundAmbientBirdsNoise.volume / 2;
        }
        else if(GoldScanner.isWorking &&!isClipSwitched)
        {
            isClipSwitched = true;
            backgroundAmbientBirdsNoise.clip = dayBirdsSound;
            backgroundAmbientBirdsNoise.Play();
          //  backgroundAmbientWaves.volume = audioVolumeHalf;
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
        soundEffectsAudio.PlayOneShot(moneySound, audioVolumeHalf);
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
        soundEffectsAudio.PlayOneShot(lootBeepFoundSound, audioVolumeHalf);
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
