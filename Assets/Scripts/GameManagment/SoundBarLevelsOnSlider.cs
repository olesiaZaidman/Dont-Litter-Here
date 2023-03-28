using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBarLevelsOnSlider : MonoBehaviour
{
    public Slider volumeLevelMusic;
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Music Volume Slider */
    public Slider volumeLevelAmbient;
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Ambient Volume Slider */
    public Slider volumeLevelSounds;
    /*UI_Start_Menu_Canvas > Settings_Panels > Panel_Settings > Sound Volume Slider */

    void Start()
    {
        SetVolumeLevel();
    }
    void SetVolumeLevel()
    {
        volumeLevelMusic.value = VolumeDataBetweenLevels.GetVolumeMusic();
        volumeLevelSounds.value = VolumeDataBetweenLevels.GetVolumeSounds();
        volumeLevelAmbient.value =  VolumeDataBetweenLevels.GetVolumeAmbient();
    }

    void Update()
    {
        SetVolumeLevels();
    }


    void SetVolumeLevels() //Updates Slider
    {
        VolumeDataBetweenLevels.SetVolumeMusic(volumeLevelMusic.value);
        VolumeDataBetweenLevels.SetVolumeSounds(volumeLevelSounds.value);
        VolumeDataBetweenLevels.SetVolumeAmbient(volumeLevelAmbient.value);
    }

}
