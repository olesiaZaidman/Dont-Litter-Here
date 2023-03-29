using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerBase : MonoBehaviour
{
    //TODO:
    //Make waves and birds abmbients sounds separtly from other sounds singleton

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

    [Header("Audio Clips")]
    [Header("Player")]
    [SerializeField] protected AudioClip[] sighSounds;

    [Header("Background Wave Clip")]
    [SerializeField] AudioClip wavesSound;

    [Header("UI SoundFX Clips")]
    [SerializeField] protected AudioClip clickSound;
    [SerializeField] protected AudioClip menuOpenSound;
    [SerializeField] protected AudioClip messageSound;
    [SerializeField] protected AudioClip moneySound;

    protected bool isPlayed = false;

   //static AudioManagerBase Instance;

    //public AudioManagerBase GetAudioManagerInstance()
    //{ return Instance; }

    void Awake()
    {
        // ManageSingleton();
       // PlayAudioClip(backgroundWaves, wavesSound);
    }

    void Update()
    {
        UpdateVolumeLevels();
    }

    void UpdateVolumeLevels() 
    {
        backgroundMusic.volume = VolumeDataBetweenLevels.GetVolumeMusic();
        backgroundWaves.volume = VolumeDataBetweenLevels.GetVolumeAmbient();
        backgroundAmbientBirdsNoise.volume = VolumeDataBetweenLevels.GetVolumeAmbient();
        soundEffectsAudio.volume = VolumeDataBetweenLevels.GetVolumeSounds();
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

    #region AbstractMethods
    public void PlayAudioClip(AudioSource _audioSource, AudioClip _clip)
    {
        if (_audioSource != null)
        {
            if (_clip != null)
            {
                _audioSource.PlayOneShot(_clip);
            }
        }
    }
    public void PlayRandomAudioClip(AudioSource _audioSource, AudioClip[] _clips)
    {
        int index = Random.Range(0, _clips.Length);
        if (_audioSource != null)
        {
            if (_clips[index] != null)
            {
                _audioSource.PlayOneShot(_clips[index]);
            }
        }
    }
    public void PlayRandomAudioClip(AudioSource _audioSource, AudioClip[] _clips, float _volume)
    {
        int index = Random.Range(0, _clips.Length);
        if (_audioSource != null)
        {
            if (_clips[index] != null) //(index <= _clips.Length)?
            {
                _audioSource.PlayOneShot(_clips[index], _volume);
            }
        }
    }

    public void PlayAudioClip(AudioSource _audioSource, AudioClip _clip, float _volume)
    {
        if (_audioSource != null)
        {
            if (_clip != null)
            {
                _audioSource.PlayOneShot(_clip, _volume);
            }
        }
    }

    public void PlayAudioClipOnce(AudioSource _audioSource, AudioClip _clip, float _delay)
    {
        StartCoroutine(PlayDelayedAudioClipRoutine(_audioSource, _clip, _delay));
    }

    public void PlayRandomAudioClipOnce(AudioSource _audioSource, AudioClip[] _clips, float _delay)
    {
        StartCoroutine(PlayRandomDelayedAudioClipRoutine(_audioSource, _clips, _delay));
    }
    public void PlayAudioClipOnce(AudioSource _audioSource, AudioClip _clip, float _volume, float _delay)
    {
        StartCoroutine(PlayDelayedAudioClipRoutine(_audioSource, _clip, _volume, _delay));
    }

    IEnumerator PlayDelayedAudioClipRoutine(AudioSource _audioSource, AudioClip _clip, float _delay)
    {
        if (!isPlayed)
        {
            isPlayed = true;
            PlayAudioClip(_audioSource, _clip);
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }

    IEnumerator PlayRandomDelayedAudioClipRoutine(AudioSource _audioSource, AudioClip[] _clips, float _delay)
    {
        if (!isPlayed)
        {
            isPlayed = true;
            PlayRandomAudioClip(_audioSource, _clips);
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }
    IEnumerator PlayDelayedAudioClipRoutine(AudioSource _audioSource, AudioClip _clip, float _volume, float _delay)
    {
        if (!isPlayed)
        {
            isPlayed = true;
            PlayAudioClip(_audioSource, _clip, _volume);
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }
    #endregion

    #region UI
    public void PlayClickSound()
    {
        //   PlayAudioClip(soundEffectsAudio, clickSound, VolumeDataBetweenLevels.GetVolumeSounds());
        PlayAudioClip(soundEffectsAudio, clickSound);
    }

    public void PlayMenuSound()
    {
        PlayAudioClip(soundEffectsAudio, menuOpenSound);
    }

    public void PlayMessageSound()
    {
        PlayAudioClip(soundEffectsAudio, messageSound);
    }

    public void PlayMessageSoundOnce()
    {
        float _delay = 5f;
        PlayAudioClipOnce(soundEffectsAudio, messageSound, _delay);
    }

    #endregion

    #region Player Sigh
    public void PlaySigh()
    {
        PlayRandomAudioClip(soundEffectsAudio, sighSounds, soundEffectsAudio.volume);
    }

    public void PlaySighOnce(float _delay)
    {
        PlayRandomAudioClipOnce(soundEffectsAudio, sighSounds, _delay);
    }

    #endregion
}
