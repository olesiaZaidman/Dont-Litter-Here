using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorIntensity : MonoBehaviour
{
    Light lt;

    [Header("Default")]
    [SerializeField] Vector3 defaultPos; //(0,3,0)
    [SerializeField] Vector3 defaultRotation; //(50,-30,0)
    [SerializeField] Color defaultYellowColor; //FFF4D6 


    [Header("Morning")]
    [SerializeField] Vector3 morningPos;
    [SerializeField] Vector3 morningRotation;
    [SerializeField] Color morningBlueColor; //6A4FFA

    [Header("Evening")]
    [SerializeField] Color eveningPinkColor; //FFA9A0
    //FF5B58

    [Header("Intensity")]
    [SerializeField] float defaultIntensity = 1f;
    [SerializeField] float hotDayIntensity = 1.6f;
    [SerializeField] float crazyHotDayIntensity = 2.3f;

   // Color color0;
 //   Color color1;
    float duration = 4.0f;
    float t = 0f;
    float xAngle = 0f;
    float yAngle = -30f;
    float minXAngle = 30f;
    float maxXAngle = 155f;

    public float speed = 0.1F;

    TimeController timeController;

    //FFA9A0
    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = morningBlueColor;
        lt.intensity = defaultIntensity;
        timeController = FindObjectOfType<TimeController>();
     //   color1 = Color.blue;
     //  color0 = defaultYellowColor;
    }

    void ChangeSunPosition(float _time)
    {
        if (xAngle < maxXAngle)
        {
            float acceleration = (maxXAngle - minXAngle) / _time;
            xAngle += acceleration * Time.deltaTime;
            //transform.rotation = 
        }
        else
            xAngle = maxXAngle;
    }


    void Update()
    {
        //if (Input.GetKey(KeyCode.P))
        //{
        //    xAngle = transform.rotation.eulerAngles.x;
        //    xAngle += 180;
        //}

        // A rotation 30 degrees around the y-axis

        //  Quaternion start  = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
        // Vector3 rotationVectorSt = new Vector3(30, 0, 0);
        //  Quaternion start  = Quaternion.Euler(rotationVectorSt);
        //   Quaternion mid = Quaternion.Euler(90, transform.eulerAngles.y, transform.eulerAngles.z);

        //    Quaternion mid2 = Quaternion.Euler(90, transform.eulerAngles.y, transform.eulerAngles.z);
        //270 = -90
        //   Quaternion end = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);


        //     transform.rotation = Quaternion.Slerp(mid2, end, Time.time * speed);


        //     Vector3 rotationVectorEnd = new Vector3(155, 0, 0);
        //  Quaternion end = Quaternion.Euler(rotationVectorEnd);



        //    transform.rotation = Quaternion.Slerp(mid, end, Time.time * speed);
        //transform.rotation = Quaternion.Euler(rotationVectorEnd * Time.time * speed);
        //if (transform.eulerAngles.x > 155)
        //{ return; }
        // Quaternion.Lerp




        //   DarkenLight(2.0f);
        //BrightenLight(2.0f);
        // set light color
        // InterpolateLightBetweenColorsBackForth(Color.blue, defaultColor);
        //  InterpolateLightIntensityOnce();

        if (timeController.IsMorning())
        {
            Debug.Log("IsMorning(): "+ timeController.IsMorning());
            InterpolateLightBetweenColorsOnce(Color.blue, defaultYellowColor);
        }

        if (timeController.IsDay() || timeController.IsNight())
        {
            t = 0;
        }

        if (timeController.IsEvening())
        {
            Debug.Log("IsEvening(): " + timeController.IsEvening());
            InterpolateLightBetweenColorsOnce(defaultYellowColor, eveningPinkColor);
        }

        //if (TemperatureManager.isNight)
        //{
        //    DarkenLight(5.0f);
        //}
        //if (TemperatureManager.isNormalTemp)
        //{
        //    InterpolateLightIntensityOnceDown();
        //}

        //if (TemperatureManager.isHighTemp)
        //{
        //    InterpolateLightIntensityOnceUp();
        //}

        // ChangeSunPosition(10);
        // transform.Rotate(new Vector3(xAngle, yAngle, 0)); //* speed * Time.deltaTime

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    InterpolateLightBetweenColorsOnce(morningBlueColor, defaultYellowColor);
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    InterpolateLightBetweenColorsOnce(defaultYellowColor, eveningPinkColor);
        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    t = 0;
        //}

        //if (Input.GetKey(KeyCode.E))
        //{
        //    InterpolateLightIntensityOnceDown();
        //}

        //if (Input.GetKey(KeyCode.R))
        //{
        //    InterpolateLightIntensityOnceUp();
        //}

    }



    public void InterpolateLightIntensityBackForth()
    {
        // lt.intensity = Mathf.PingPong(Time.time, 3);
        float duration = 3f;
        float t = Mathf.PingPong(Time.time, duration);
        lt.intensity = t;
    }

    public void InterpolateLightIntensityOnceUp()
    {
        float duration = 2f;
        lt.intensity = t;
        if (t < duration)
        {
            // increment it at the desired rate every update:
            t += Time.deltaTime / duration;
        }
    }

    public void InterpolateLightIntensityOnceDown()
    {
        float duration = 2f;
        lt.intensity = t;
        if (t < duration)
        {
            // increment it at the desired rate every update:
            t -= Time.deltaTime / duration;
        }
    }

    //void SpeedUp()
    //{
    //    if (gradualPoints < maxSpeed)
    //    {
    //        float acceleration = (maxSpeed - minSpeed) / time;
    //        gradualPoints += acceleration * Time.deltaTime;
    //    }
    //    else
    //        gradualPoints = maxSpeed;
    //}

    void InterpolateLightBetweenColorsBackForth(Color _startColor, Color _endColor)
    {
        // Interpolate light color between two colors back and forth
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(_startColor, _endColor, t);
    }

    public void InterpolateLightBetweenColorsOnce(Color _startColor, Color _endColor)
    {
        // Interpolate light color between two colors ONCE

        lt.color = Color.Lerp(_startColor, _endColor, t);
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
        lt.color += (defaultYellowColor / _time) * Time.deltaTime;
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