using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsData : MonoBehaviour
{
    [Header("AudioSource")]
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
        VolumeDataBetweenLevels.volumeLevelMusic = waves.volume;
        VolumeDataBetweenLevels.volumeLevelSounds = sounds.volume;
    }
}
