using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerBase : MonoBehaviour
{
    [Header("AudioSource")]
    [Header("Music")]
    [SerializeField] protected AudioSource backgroundMusic;
    [Header("Background Waves")]
    [SerializeField] protected AudioSource backgroundWaves;
    [Header("Background Ambient")]
    public AudioSource backgroundAmbientBirdsNoise;
    [Header("UISFX")]
    [SerializeField] protected AudioSource soundEffectsAudio;

    protected bool isClipSwitched = false;

    [Header("Player")]
    [SerializeField] protected AudioClip[] sighSound;

    [Header("UI SoundFX Clips")]
    [SerializeField] protected AudioClip clickSound;
    [SerializeField] protected  AudioClip menuOpenSound;
    [SerializeField] protected AudioClip messageSound;
    [SerializeField] protected AudioClip moneySound;

    protected bool isPlayed = false;

    //static AudioManagerBase Instance;

    //public AudioManagerBase GetAudioManagerInstance()
    //{ return Instance; }

    void Awake()
    {
        //  ManageSingleton();
        backgroundMusic.volume = PlayerPrefs.GetFloat("VolumeMusic", VolumeDataBetweenLevels.volumeLevelMusic);
        backgroundWaves.volume = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.volumeLevelMusic);
        backgroundAmbientBirdsNoise.volume = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.volumeLevelAmbient);
        soundEffectsAudio.volume = PlayerPrefs.GetFloat("VolumeSounds", VolumeDataBetweenLevels.volumeLevelSounds);
    }

    //void ManageSingleton()
    //{
    //    if (Instance != null)
    //    {
    //        gameObject.SetActive(false); /*we disable it on Awake before we destroy it, 
    //                                      * so no component will try to access it*/
    //        Destroy(gameObject);
    //    }

    //    else
    //    /* we need to transit this AudioPlayer  
    //     * through all the rest of the scenes on Load*/
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);  /*the existing AudiPlayer will be passed to another scene*/
    //    }
    //}

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
}
