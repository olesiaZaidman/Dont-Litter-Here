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
    UIManager ui;
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

    DateTime dt11AM;
    DateTime timeNow;
    void Awake()
    {
        ui = FindObjectOfType<UIManager>();
        audioManager = FindObjectOfType<AudioManager>();
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


  
    public bool IsEndOfWorkingDay() //endWorkingDayHour = 21; &&  && elevenTime = 23
    {
        return currentTime.TimeOfDay > endDayTime && currentTime.TimeOfDay < elevenEveningTime;
    }

    void Update()
    {
        UpdateTime();
        RotateSun();
        CreateCrowdNoise();   
    }

    private void UpdateTime()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if (ui != null)
        { ui.SetTimeTextUI(currentTime); }
    }

    #region TimeSpan Bools
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
    private void CreateCrowdNoise()
    {

        //check if dayTime between sunrise and dayTime
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < dayTime)
        {
            TimeSpan sunriseToDayDuration = CalculateTimeDifference(sunriseTime, dayTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
            //now we calculate what percentage of the day has passed:
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToDayDuration.TotalMinutes;

            audioManager.backgroundCrowdNoise.volume = Mathf.Lerp(0, 1, (float)percentage);
        }

        //check if dayTime between dayTime and SunSet
        else if (currentTime.TimeOfDay > dayTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan dayToSunsetDuration = CalculateTimeDifference(dayTime, sunsetTime);
            TimeSpan timeSinceDay = CalculateTimeDifference(dayTime, currentTime.TimeOfDay);
            //now we calculate what percentage of the day has passed:
            double percentage = timeSinceDay.TotalMinutes / dayToSunsetDuration.TotalMinutes;

            audioManager.backgroundCrowdNoise.volume = Mathf.Lerp(1, 0, (float)percentage);
        }
        else //the nighttime
        {
            audioManager.backgroundCrowdNoise.volume = 0;
        }

    }

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


}
