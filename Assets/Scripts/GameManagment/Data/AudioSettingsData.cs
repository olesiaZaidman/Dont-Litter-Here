using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsData : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sounds;
    [SerializeField] AudioSource waves;
    [SerializeField] AudioSource birds;
    private void Update()
    {
        SaveVolumeSettingsData();
    }

    public void SaveVolumeSettingsData()
    {
        VolumeDataBetweenLevels.volumeLevelAmbient = birds.volume;
        VolumeDataBetweenLevels.volumeLevelAmbient = waves.volume;
        VolumeDataBetweenLevels.volumeLevelMusic = music.volume;
        VolumeDataBetweenLevels.volumeLevelSounds = sounds.volume;
    }
}
