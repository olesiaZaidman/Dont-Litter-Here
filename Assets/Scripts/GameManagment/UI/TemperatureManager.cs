using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    UIManager ui;
   // TimeController timeController;

    int temperature;
    float minTemp;
    float maxTemp;
    public static bool isNormalTemp = false;
    public static bool isHighTemp = false;
    bool isTempRangeSet = false;
   // bool isStartTempSet = false;
    void Awake()
    {
        ui = FindObjectOfType<UIManager>();
     //   timeController = FindObjectOfType<TimeController>();
    }
    void Start()
    {
        SetRandomStartTemperatureToday();
        ui.SetTemperTextUI(temperature);
    }
    void Update()
    {
        //if (timeController != null)
        //{
        //    if (timeController.IsEarlyMorning())
        //    {
        //        if (!isStartTempSet)
        //        {
        //            isStartTempSet = true;
        //            temperature = SetRandomStartTemperatureToday();
        //        }
        //    }
        //    if (timeController.IsEndOfWorkingDay())
        //    {
        //        isStartTempSet = false;

        //    }
        //}
    }
    public int GetTemperature()
    {
        return temperature;
    }

    public int SetRandomStartTemperatureToday()
    {
        return temperature = Random.Range(15, 20);
    }

    public int GetMaxTemperatureToday()
    {
        return (int)maxTemp;
    }

    public int IncreaseTemperature(float deltaTime)
    {
        if (!isTempRangeSet)
        {
            isTempRangeSet = true;
            minTemp = Random.Range(15, 20);
            maxTemp = Random.Range(21, 40);
          //  Debug.Log("max Temperature toady: " + maxTemp);
        }

        //Debug.Log("Increasing Temp");
        float t = Mathf.Lerp(minTemp, maxTemp, deltaTime);
        temperature = (int)t;
        ui.SetTemperTextUI(temperature);
        return temperature;
    }

    public int DecreaseTemperature(float deltaTime)
    {
        if (isTempRangeSet)
        {
            isTempRangeSet = false;
            minTemp = Random.Range(15, 20);
        }
        float t = Mathf.Lerp(maxTemp, minTemp, deltaTime);
        temperature = (int)t;
        ui.SetTemperTextUI(temperature);
        return temperature;
    }
}
