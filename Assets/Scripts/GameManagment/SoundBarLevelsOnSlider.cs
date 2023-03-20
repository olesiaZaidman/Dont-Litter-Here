using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBarLevelsOnSlider : MonoBehaviour
{
    public AudioSource music;
    public AudioSource birdsAmbient;
    public AudioSource wavesAmbient;
    public AudioSource sounds;

    public Slider volumeLevelMusic;
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Music Volume Slider */
    public Slider volumeLevelAmbient;
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Ambient Volume Slider */
    public Slider volumeLevelSounds;
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Sound Volume Slider */

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
        volumeLevelMusic.value = PlayerPrefs.GetFloat("VolumeMusic", VolumeDataBetweenLevels.defualtVolumeLevelMusic);
        volumeLevelSounds.value = PlayerPrefs.GetFloat("VolumeSounds", VolumeDataBetweenLevels.defualtVolumeLevelSounds);
        volumeLevelAmbient.value = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.defualtVolumeLevelAmbient);
    }
}
