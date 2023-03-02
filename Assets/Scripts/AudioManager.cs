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
    [SerializeField] AudioClip moneySound;

    [Header("Player")]
    [SerializeField] AudioClip[] sighSound;
    [SerializeField] AudioClip whistleSound;
    [SerializeField] AudioClip gulpSound;
    // [Header("SoundFX")]

    float audioVolume = 0.5f;
    bool isPlayed = false;
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
        if (!isPlayed)
        {
            isPlayed = true;
            PlaySigh();
        }
        yield return new WaitForSeconds(_delay);
        isPlayed = false;
    }



    public void PlayGulp()
    {
        sfx.PlayOneShot(gulpSound, audioVolume);
    }
    public void PlayWhistle()
    {
        sfx.PlayOneShot(whistleSound, audioVolume);
    }

    public void PlayMoneySFXOnce()
    {
        StartCoroutine(PlayMoneySFXRoutine());
    }

    public void PlayMoneySFX()
    {
        sfx.PlayOneShot(moneySound, audioVolume);
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


}
