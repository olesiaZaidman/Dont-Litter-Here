using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{   
    private float timeMultiplier = 1000;    //it controls how fast time passes in the game
    private float startHour = 5;
    private DateTime currentTime;  //using System; namespace
    private DateTime currentDate = new DateTime(2023, 5, 1); //(int year, int month, int day);
    //starts on monday

    UIManager ui;
    [SerializeField] Light sunLight;

    private float endWorkingDayHour = 21;

    private float sunriseHour = 5;
    private float blueHour = 7;
    private float dayHour = 12;
    private float goldenHour = 16;
    private float sunsetHour = 20;
    private float nightHour = 23;

    private TimeSpan sunriseTime;
    private TimeSpan blueHourTime;
    private TimeSpan dayTime;
    private TimeSpan goldenHourTime;
    private TimeSpan sunsetTime;
    private TimeSpan nightTime;
    private TimeSpan endDayTime;

    public static bool isMorning = false;
    public static bool isDay = false;
    public static bool isEvening = false;
    public static bool isNight = false;

    void Awake()
    {
        ui = FindObjectOfType<UIManager>();
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
        nightTime = TimeSpan.FromHours(nightHour);
    }

    public bool IsEndOfWorkingDay()
    {
        return currentTime.TimeOfDay > endDayTime && currentTime.TimeOfDay < nightTime;
    }

    void Update()
    {
        UpdateTime();
        RotateSun();
    }

    private void UpdateTime()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if (ui != null)
        { ui.SetTimeTextUI(currentTime); }
    }

    public bool IsMorning()
    {
        return currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < blueHourTime ;
    }

    public bool IsDay()
    {
        return currentTime.TimeOfDay > dayTime && currentTime.TimeOfDay < goldenHourTime;
    }

    public bool IsEvening()
    {
        return currentTime.TimeOfDay > goldenHourTime && currentTime.TimeOfDay < sunsetTime;
    }

    public bool IsNight()
    {
        return currentTime.TimeOfDay > nightTime && currentTime.TimeOfDay < sunriseTime;
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

    //public DateTime BuildDate(int day, int hour)
    //{
    //    var now = DateTime.Now;

    //    var initialDate = now.AddDays(((int)now.DayOfWeek + 1) * -1);

    //    return new DateTime(initialDate.Year, initialDate.Month, initialDate.AddDays(day).Day, hour, 0, 0);
    //}

}
