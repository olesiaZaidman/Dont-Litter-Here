using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource backgroundSFXAudio;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource sfx;


    [Header("Background")]
    [SerializeField] AudioClip wavesSound;


    [Header("Player")]
    [SerializeField] AudioClip[] sighSound;
    [SerializeField] AudioClip whistleSound;
    [SerializeField] AudioClip gulpSound;
    // [Header("SoundFX")]

    float audioVolume = 0.5f;
    bool sighed = false;
    private void Start()
    {
      //  backgroundSFXAudio.PlayOneShot(wavesSound, audioVolume);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySigh()
    {
        int index = Random.Range(0, sighSound.Length);
        sfx.PlayOneShot(sighSound[index], audioVolume);
    }

    public void PlaySighOnce(float _delay)
    {
        StartCoroutine(PlaySighRoutine(_delay));
    }

    IEnumerator PlaySighRoutine(float _delay)
    {
        if (!sighed)
        {
            sighed = true;
            PlaySigh();
        }
        yield return new WaitForSeconds(_delay);
        sighed = false;
    }

    public void PlayWhistle()
    {
        sfx.PlayOneShot(whistleSound, audioVolume);
    }

    public void PlayGulp()
    {
        sfx.PlayOneShot(gulpSound, audioVolume);
    }
}
