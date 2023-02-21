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
}
