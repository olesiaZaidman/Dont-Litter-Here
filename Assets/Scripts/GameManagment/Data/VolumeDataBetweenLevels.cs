using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDataBetweenLevels : MonoBehaviour
{
    [Header("Volume")]
    public static float volumeLevelMusic;
    public static float volumeLevelAmbient;
    public static float volumeLevelSounds;

    //[Header("Score")]
    //public static int currentScore;

     void Awake()
    {
        volumeLevelMusic = 1f;
        volumeLevelAmbient = 0.5f;
        volumeLevelSounds = 0.5f;
    }


    public static void UpdateSoundData() // we call it in gamemanager's Update
    {
        PlayerPrefs.SetFloat("VolumeMusic", volumeLevelMusic);
        PlayerPrefs.SetFloat("VolumeSounds", volumeLevelSounds);
        PlayerPrefs.SetFloat("VolumeAmbient", volumeLevelAmbient);
    }

}
