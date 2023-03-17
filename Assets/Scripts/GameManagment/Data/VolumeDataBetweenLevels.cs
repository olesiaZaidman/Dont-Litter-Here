using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDataBetweenLevels : MonoBehaviour
{
    [Header("Volume")]
    public static float volumeLevelMusic;
    public static float volumeLevelAmbient;
    public static float volumeLevelSounds;

    public static float defualtVolumeLevelMusic = 1f;
    public static float defualtVolumeLevelAmbient = 0.5f;
    public static float defualtVolumeLevelSounds = 0.5f;


    void Awake()
    {
        UpdateSoundData();
      //  Debug.Log("VolumeDataBetweenLevels");
    }


    public static void UpdateSoundData() // we call it when Press Button
    {
        Debug.Log("UpdateSoundData");
        PlayerPrefs.SetFloat("VolumeMusic", volumeLevelMusic);
        PlayerPrefs.SetFloat("VolumeSounds", volumeLevelSounds);
        PlayerPrefs.SetFloat("VolumeAmbient", volumeLevelAmbient);
    }

}
