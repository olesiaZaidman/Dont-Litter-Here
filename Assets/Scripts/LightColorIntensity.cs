using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorIntensity : MonoBehaviour
{
    Light lt;

    [Header("Default")]
    [SerializeField] Vector3 defaultPos; //(0,3,0)
    [SerializeField] Vector3 defaultRotation; //(50,-30,0)
    [SerializeField] Color defaultColor; //FFF4D6


    [Header("Morning")]
    [SerializeField] Vector3 morningPos;
    [SerializeField] Vector3 morningRotation;
    [SerializeField] Color morningColor; //6A4FFA

    [Header("Evening")]
    [SerializeField] Color eveningColor; //FFA9A0

    [Header("Intensity")]
    [SerializeField] float defaultIntensity = 1f;
    [SerializeField] float hotDayIntensity = 1.6f;
    [SerializeField] float crazyHotDayIntensity = 2.3f;

    Color color0;
    Color color1 = Color.blue;
    float duration = 10.0f;
    float t = 0f;
    //FFA9A0
    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = morningColor;
        color0 = defaultColor;
    }


    void Update()
    {
        //   DarkenLight(2.0f);
        //BrightenLight(2.0f);
        // set light color
        // InterpolateLightBetweenColorsBackForth();
        InterpolateLightBetweenColorsOnce(Color.blue, defaultColor);
       // InterpolateLightIntensityOnce();
    }
   


    void InterpolateLightIntensityBackForth()
    {
        // lt.intensity = Mathf.PingPong(Time.time, 3);
        float duration = 3f;
        float t = Mathf.PingPong(Time.time, duration);
        lt.intensity = t;
        //PingPong returns a value that will increment and decrement between the value 0 and length.
        //   PingPong requires the value t to be a self-incrementing value, for example Time.time, and Time.unscaledTime.
    }

    void InterpolateLightIntensityOnce()
    {
        float duration = 2f;
        lt.intensity = t;
        if (t < duration)
        {
            // increment it at the desired rate every update:
            t += Time.deltaTime / duration;
        }
    }


    void InterpolateLightBetweenColorsBackForth(Color _startColor, Color _endColor)
    {
        // Interpolate light color between two colors back and forth
       float t = Mathf.PingPong(Time.time, duration) / duration;
        //PingPong returns a value that will increment and decrement between the value 0 and length.
        //   PingPong requires the value t to be a self-incrementing value, for example Time.time, and Time.unscaledTime.

        lt.color = Color.Lerp(_startColor, _startColor, t);
        //t is clamped between 0 and 1. When t is 0 returns a. When t is 1 returns b.
    }

    void InterpolateLightBetweenColorsOnce(Color _startColor, Color _endColor)
    {
        // Interpolate light color between two colors ONCE
        lt.color = Color.Lerp(_startColor, _startColor, t);
        //t is clamped between 0 and 1. When t is 0 returns a. When t is 1 returns b.
        if (t < 1)
        {
            // increment it at the desired rate every update:
            t += Time.deltaTime / duration;
        }
    }



    void DarkenLight(float _time)
    {
        // Darken the light completely over a period of 2 seconds.
        lt.color -= (Color.white / _time) * Time.deltaTime;
    }

    void BrightenLight(float _time)
    {
        // Brighten the light completely over a period of 2 seconds.
        lt.color += (defaultColor / _time) * Time.deltaTime;
    }

    void SetPositionWithDayTime(int _dayState)
    {
        switch (_dayState)
        {
            case 1: /// morning
                Debug.Log("morning");
                break;

            case 2: //day
                Debug.Log("day");
                break;

            case 3: //evening
                Debug.Log("evening");
                break; //default state

            case 4: //night
                Debug.Log("night");
                break;

            default://default state
                break;
        }
    }
}
