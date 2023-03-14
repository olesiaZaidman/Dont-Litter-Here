using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorIntensity : MonoBehaviour
{
    Light lt;

    [Header("Default")]
    [SerializeField] Color defaultYellowColor; //FFF4D6 


    [Header("Morning")]
    [SerializeField] Color morningBlueColor; //6A4FFA

    [Header("Evening")]
    [SerializeField] Color eveningPinkColor; //FFA9A0
    //FF5B58

    [Header("Intensity")]
    float defaultIntensity = 1f;
    //[SerializeField] float hotDayIntensity = 1.6f;
    //[SerializeField] float crazyHotDayIntensity = 2.3f;

    float duration = 7.0f;
    float t = 0f;
    float t_intensity = 0f;

    TimeController timeController;

    //FFA9A0
    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = morningBlueColor;
        lt.intensity = defaultIntensity;
        timeController = FindObjectOfType<TimeController>();
    }
    #region Color of Light
    public void InterpolateLightBetweenColorsOnce(Color _startColor, Color _endColor, float _duration)
    {
        // Interpolate light color between two colors ONCE
        
        lt.color = Color.Lerp(_startColor, _endColor, t);
        if (t < 1)
        {
            // increment it at the desired rate every update:
            t += Time.deltaTime / _duration;
        }
    }
    #endregion

    #region Light Intensity
    public void InterpolateLightIntensityOnceUp(float _duration)
    {
        lt.intensity = t_intensity;
        if (t_intensity < _duration)
        {
            // increment it at the desired rate every update:
            t_intensity += Time.deltaTime / _duration;
        }
    }

    public void InterpolateLightIntensityOnceDown(float _duration)
    {
        lt.intensity = t_intensity;
        if (t_intensity < _duration)
        {
            // increment it at the desired rate every update:
            t_intensity -= Time.deltaTime / _duration;
        }
    }
    #endregion
    void Update()
    {
        if (timeController.IsEarlyMorning())  //sunriseTime = 5; && blueHourTime = 7;
        {         
            InterpolateLightBetweenColorsOnce(Color.blue, defaultYellowColor, duration);
        }

        //if (timeController.IsLateMorning())  // dayTime = 12 && goldenHourTime = 16;
        //{
        //    InterpolateLightIntensityOnceUp(2f);
        //}

        if (timeController.IsDay())  // dayTime = 12 && goldenHourTime = 16;
        {
            t = 0;
           //InterpolateLightIntensityOnceUp(2f);
           InterpolateLightBetweenColorsOnce(defaultYellowColor, defaultYellowColor, duration);
        }



        if (timeController.IsEarlyEvening()) // goldenHourTime = 16 &&  sunsetTime= 20;
        {
           //InterpolateLightIntensityOnceDown(2f);
            InterpolateLightBetweenColorsOnce(defaultYellowColor, eveningPinkColor, duration);
        }

        if (timeController.IsLateEvening()) // sunsetTime= 20; && nightTime = 23
        {
            InterpolateLightBetweenColorsOnce(eveningPinkColor, Color.blue, duration);
        }

        if (timeController.IsNight()) // nightTime = 00 && sunriseTime = 5;
        {          
          t = 0;
          InterpolateLightBetweenColorsOnce(Color.blue, Color.blue, duration);
           
        }
    }


    //public void InterpolateLightIntensityBackForth()
    //{
    //    // lt.intensity = Mathf.PingPong(Time.time, 3);
    //    float duration = 3f;
    //    float t = Mathf.PingPong(Time.time, duration);
    //    lt.intensity = t;
    //}

}
