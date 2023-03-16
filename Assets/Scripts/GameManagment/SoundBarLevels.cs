using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBarLevels : MonoBehaviour
{
    public AudioSource music;
    public AudioSource birdsAmbient;
    public AudioSource wavesAmbient;
    public AudioSource sounds;

    public Slider volumeLevelMusic;
    public Slider volumeLevelAmbient;
    public Slider volumeLevelSounds;

    void Awake()
    {
        SetVolumeLevel();
       // TimeController.maxBirdsVolume = volumeLevelAmbient.value;
    }
    void Update()
    {
        TweakVolumeLevel();
    }


    void TweakVolumeLevel() //Updates Slider
    {
     //   TimeController.maxBirdsVolume = volumeLevelAmbient.value;
        music.volume = volumeLevelMusic.value;
        birdsAmbient.volume = volumeLevelAmbient.value;
        wavesAmbient.volume = volumeLevelAmbient.value;
        sounds.volume = volumeLevelSounds.value;
    }

    void SetVolumeLevel()
    {
        volumeLevelMusic.value = PlayerPrefs.GetFloat("VolumeMusic", VolumeDataBetweenLevels.volumeLevelMusic);
        volumeLevelSounds.value = PlayerPrefs.GetFloat("VolumeSounds", VolumeDataBetweenLevels.volumeLevelSounds);
        volumeLevelAmbient.value = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.volumeLevelAmbient);
    }
}
