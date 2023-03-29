using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float timeMultiplier = 800;    //it controls how fast time passes in the game
    private float startHour = 5;

    private DateTime currentTime;  //using System; namespace
    private DateTime currentDate = new DateTime(2023, 5, 1); //(int year, int month, int day);
    //starts on monday
    AudioManager audioManager;

    UIGameStatsManager ui;
    [SerializeField] Light sunLight;
    private float endWorkingDayHour = 21;

    private float sunriseHour = 5;
    private float blueHour = 7;
    private float dayHour = 12;
    private float goldenHour = 16;
    private float sunsetHour = 20;
    private float nightHour = 00;
    private float elevenEveningHour =23;

    private TimeSpan sunriseTime;
    private TimeSpan blueHourTime;
    private TimeSpan dayTime;
    private TimeSpan goldenHourTime;
    private TimeSpan sunsetTime;
    private TimeSpan nightTime;
    private TimeSpan elevenEveningTime;
    private TimeSpan endDayTime;

    public static bool isMorning = false;
    public static bool isDay = false;
    public static bool isEvening = false;
    public static bool isNight = false;

    //HeatWave:
    TemperatureManager temperatureManager;
    bool isMaxTempSet = false;
    float minIntensity = 1f;
    float maxIntensity = 1.55f;
   public static float maxBirdsVolume;
  //  bool isNewVolumeMax = false;
    void Awake()
    {
        ui = FindObjectOfType<UIGameStatsManager>();
        audioManager = FindObjectOfType<AudioManager>();
        temperatureManager = FindObjectOfType<TemperatureManager>();
    }
    void Start()
    {
        currentTime = currentDate + TimeSpan.FromHours(startHour);
        endDayTime = TimeSpan.FromHours(endWorkingDayHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        blueHourTime = TimeSpan.FromHours(blueHour);
        dayTime = TimeSpan.FromHours(dayHour);
        goldenHourTime = TimeSpan.FromHours(goldenHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
        elevenEveningTime = TimeSpan.FromHours(elevenEveningHour);
        nightTime = TimeSpan.FromHours(nightHour);
    }
 
    void Update()
    {
        UpdateTime();
        RotateSun();
        CreateHeatWave();
        //  ToggleBirdsSoundLevel();
        //  CreateCrowdNoise();
    }

    #region Time
    private void UpdateTime()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if (ui != null)
        { ui.SetTimeTextUI(currentTime); }
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        //it helps to determine how long untill sunset or sunsrise - and set sun accordingly
        TimeSpan timeDifference = toTime - fromTime;

        if (timeDifference.TotalSeconds < 0)
        {
            //it means transition from one day to another
            //so we need add up 24 hours to correct the value
            timeDifference += TimeSpan.FromHours(24);
        }
        return timeDifference;
    }
    #endregion

    #region TimeSpan Bools
    public bool IsThisTimeInterval(float _fromTime, float _toTime)
    {
        return currentTime.TimeOfDay > TimeSpan.FromHours(_fromTime) && currentTime.TimeOfDay < TimeSpan.FromHours(_toTime);
    }
    public bool IsEndOfWorkingDay() //endWorkingDayHour = 21; &&  && elevenTime = 23
    {
        return currentTime.TimeOfDay > endDayTime && currentTime.TimeOfDay < elevenEveningTime;
    }
    public bool IsEarlyMorning() //sunriseTime = 5; && blueHourTime = 7;
    {
        return currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < blueHourTime ;
    }

    public bool IsLateMorning()// blueHourTime = 7 && dayTime = 12;
    {
        return currentTime.TimeOfDay > blueHourTime && currentTime.TimeOfDay < dayTime;
    }

    public bool IsDay() // dayTime = 12 && goldenHourTime = 16;
    {
        return currentTime.TimeOfDay > dayTime && currentTime.TimeOfDay < goldenHourTime;
    }

    public bool IsEarlyEvening() // goldenHourTime = 16 &&  sunsetTime= 20;
    {
        return currentTime.TimeOfDay > goldenHourTime && currentTime.TimeOfDay < sunsetTime;
    }

    public bool IsLateEvening() // sunsetTime= 20; && elevenTime = 23
    {
        return currentTime.TimeOfDay > sunsetTime && currentTime.TimeOfDay < elevenEveningTime;
    }

    public bool IsNight()  // nightTime = 00 && sunriseTime = 5;
    {
        return currentTime.TimeOfDay > nightTime && currentTime.TimeOfDay < sunriseTime;
    }


    #endregion

    #region HeatWave

    float SetIntensityMax(int _temperature)
    {
        if (_temperature > 20 && _temperature <= 30)
        {
            return 1.35f; 
        }

        else if (_temperature > 30)
        {
            return 1.50f;
        }
        else
            return 1;
    }
    private void CreateHeatWave()
    {
        if (currentTime.TimeOfDay > TimeSpan.FromHours(10) && currentTime.TimeOfDay < TimeSpan.FromHours(12))
        {
            TimeSpan morningHeat = CalculateTimeDifference(TimeSpan.FromHours(10), TimeSpan.FromHours(12));
            TimeSpan timeSinceMorning = CalculateTimeDifference(TimeSpan.FromHours(10), currentTime.TimeOfDay);

            double percentage = timeSinceMorning.TotalMinutes / morningHeat.TotalMinutes;

            temperatureManager.IncreaseTemperature((float)percentage); //IncreaseTemperature sets internally maax temp of the day

            if (!isMaxTempSet)
            {
                isMaxTempSet = true;
                maxIntensity = SetIntensityMax(temperatureManager.GetMaxTemperatureToday());
               // Debug.Log("maxIntensity toady: "+ maxIntensity);
            }

            sunLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, (float)percentage);       
        }

        else if (currentTime.TimeOfDay > TimeSpan.FromHours(15) && currentTime.TimeOfDay < TimeSpan.FromHours(18))
        {
            TimeSpan dayCoolDown = CalculateTimeDifference(TimeSpan.FromHours(15), TimeSpan.FromHours(18));
            TimeSpan timeSinceDay = CalculateTimeDifference(TimeSpan.FromHours(15), currentTime.TimeOfDay);

            double percentage = timeSinceDay.TotalMinutes / dayCoolDown.TotalMinutes;
            sunLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, (float)percentage);
            temperatureManager.DecreaseTemperature((float)percentage);
            isMaxTempSet = false;
        }
    }

    #endregion

    #region Noise // Deactivated

    //void ToggleBirdsSoundLevel()
    //{           
    //    if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < TimeSpan.FromHours(9))
    //    {
    //        if (!isNewVolumeMax)
    //        {
    //            isNewVolumeMax = true;
    //            maxBirdsVolume = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.volumeLevelAmbient);
    //        }

    //        TimeSpan morning = CalculateTimeDifference(sunriseTime, TimeSpan.FromHours(9));
    //        TimeSpan timeSinceMorning = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
    //        double percentage = timeSinceMorning.TotalMinutes / morning.TotalMinutes;
    //        audioManager.backgroundAmbientBirdsNoise.volume = Mathf.Lerp(maxBirdsVolume, 0.1f, (float)percentage);
    //    }

    //    else if (currentTime.TimeOfDay > endDayTime && currentTime.TimeOfDay < TimeSpan.FromHours(22))
    //    {
    //        if (isNewVolumeMax)
    //        {
    //            isNewVolumeMax = false;
    //            maxBirdsVolume = PlayerPrefs.GetFloat("VolumeAmbient", VolumeDataBetweenLevels.volumeLevelAmbient);
    //        }
    //        TimeSpan endWorkDay = CalculateTimeDifference(endDayTime, TimeSpan.FromHours(22));
    //        TimeSpan timeSinceEndWorkDay = CalculateTimeDifference(endDayTime, currentTime.TimeOfDay);
    //        double percentage = timeSinceEndWorkDay.TotalMinutes / endWorkDay.TotalMinutes;
    //        audioManager.backgroundAmbientBirdsNoise.volume = Mathf.Lerp(0.1f, maxBirdsVolume, (float)percentage);
    //    }
    //}

    //void ResetVolumeMax()
    //{ 
    
    //}
    //private void CreateCrowdNoise()
    //{
    //    //check if dayTime between sunrise and dayTime
    //    if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < dayTime)
    //    {
    //        TimeSpan sunriseToDayDuration = CalculateTimeDifference(sunriseTime, dayTime);
    //        TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
    //        //now we calculate what percentage of the day has passed:
    //        double percentage = timeSinceSunrise.TotalMinutes / sunriseToDayDuration.TotalMinutes;

    //        audioManager.backgroundCrowdNoise.volume = Mathf.Lerp(0, 1, (float)percentage);
    //    }

    //    //check if dayTime between dayTime and SunSet
    //    else if (currentTime.TimeOfDay > dayTime && currentTime.TimeOfDay < sunsetTime)
    //    {
    //        TimeSpan dayToSunsetDuration = CalculateTimeDifference(dayTime, sunsetTime);
    //        TimeSpan timeSinceDay = CalculateTimeDifference(dayTime, currentTime.TimeOfDay);
    //        //now we calculate what percentage of the day has passed:
    //        double percentage = timeSinceDay.TotalMinutes / dayToSunsetDuration.TotalMinutes;

    //        audioManager.backgroundCrowdNoise.volume = Mathf.Lerp(1, 0, (float)percentage);
    //    }
    //    else //the nighttime
    //    {
    //        audioManager.backgroundCrowdNoise.volume = 0;
    //    }

    //}
    #endregion

    #region RotateSun
    private void RotateSun()
    {
        float sunLightRotation;
        //check if dayTime between sunrise and SunSet
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
            //now we calculate what percentage of the day has passed:
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            //we use this percentage to work out rotation: 
            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else //the nighttime
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }
        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }
    #endregion
}
