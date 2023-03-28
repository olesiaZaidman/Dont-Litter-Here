using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDataBetweenLevels : MonoBehaviour
{
    //TODO:
    //CHANGE Player Pref to JSON


    [Header("Volume")]
    static float volumeLevelMusic;
    static float volumeLevelSounds;
    static float volumeLevelAmbient;

    static float defualtVolumeLevelMusic = 1f;
    static float defualtVolumeLevelSounds = 0.5f;
    static float defualtVolumeLevelAmbient = 0.5f;

    void Awake()
    {
        InitializeSoundData();
        //  Debug.Log("VolumeDataBetweenLevels");
    }

    public static void InitializeSoundData() // we call it when Press Button
    {
        volumeLevelMusic = PlayerPrefs.GetFloat("VolumeMusic", defualtVolumeLevelMusic);
        volumeLevelSounds = PlayerPrefs.GetFloat("VolumeSounds", defualtVolumeLevelSounds);
        volumeLevelAmbient = PlayerPrefs.GetFloat("VolumeAmbient", defualtVolumeLevelAmbient);
    }


    public static float GetVolumeMusic()
    {
        return volumeLevelMusic;
    }

    public static float GetVolumeSounds()
    {
        return volumeLevelSounds;
    }

    public static float GetVolumeAmbient()
    {
        return volumeLevelAmbient;
    }

    public static void SetVolumeMusic(float _value)
    {
        PlayerPrefs.SetFloat("VolumeMusic", _value);
        volumeLevelMusic = _value;

    }

    public static void SetVolumeSounds(float _value)
    {
        PlayerPrefs.SetFloat("VolumeSounds", _value);
        volumeLevelSounds = _value;
    }


    public static void SetVolumeAmbient(float _value)
    {
        PlayerPrefs.SetFloat("VolumeAmbient", _value);
        volumeLevelAmbient = _value;
    }

}
