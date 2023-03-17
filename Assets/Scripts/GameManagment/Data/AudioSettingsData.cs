using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsData : MonoBehaviour
{
    [Header("AudioSource")]
    [Header("Music")]
    [SerializeField] AudioSource music;
    [Header("Sounds")]
    [SerializeField] AudioSource sounds;
    [Header("Ambient")]
    [SerializeField] AudioSource waves;
    [SerializeField] AudioSource birds;
    private void Update()
    {
        SaveVolumeSettingsData();
    }

    public void SaveVolumeSettingsData()
    {
        VolumeDataBetweenLevels.volumeLevelMusic = music.volume;
        VolumeDataBetweenLevels.volumeLevelSounds = sounds.volume;
        VolumeDataBetweenLevels.volumeLevelAmbient = birds.volume;
        VolumeDataBetweenLevels.volumeLevelAmbient = waves.volume;
    }
}
