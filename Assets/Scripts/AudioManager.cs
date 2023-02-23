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
    // [Header("SoundFX")]

    float audioVolume = 0.5f;

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

    public void PlaySighOnce()
    {
        StartCoroutine(PlaySighRoutine());
    }

    IEnumerator PlaySighRoutine()
    {
        bool sighed = false;
        if (!sighed)
        { PlaySigh(); }
        yield return new WaitForSeconds(0.1f);
        sighed = true;
    }

    public void PlayWhistle()
    {
        sfx.PlayOneShot(whistleSound, audioVolume);
    }
}
