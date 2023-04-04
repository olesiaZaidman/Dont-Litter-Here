using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    UIGameStatsManager ui;

    int temperature;
    float minTemp;
    float maxTemp;
    public static bool isNormalTemp = false;
    public static bool isHighTemp = false;
    bool isTempRangeSet = false;
    void Awake()
    {
        ui = FindObjectOfType<UIGameStatsManager>();

    }
    void Start()
    {
        SetRandomStartTemperatureToday();
        ui.SetTemperatureTextUI(temperature);
    }
   
    public int GetTemperature()
    {
        return temperature;
    }

    public int SetRandomStartTemperatureToday()
    {
        return temperature = Random.Range(14, 20);
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
            minTemp = Random.Range(temperature, 20);
            maxTemp = Random.Range(21, 40);
            Debug.Log("max Temperature today: " + maxTemp);
        }

        //Debug.Log("Increasing Temp");
        float t = Mathf.Lerp(minTemp, maxTemp, deltaTime);
        temperature = (int)t;
        ui.SetTemperatureTextUI(temperature);
        return temperature;
    }

    public int DecreaseTemperature(float deltaTime)
    {
        if (isTempRangeSet)
        {
            isTempRangeSet = false;
            minTemp = Random.Range(14, 20);
        }
        float t = Mathf.Lerp(maxTemp, minTemp, deltaTime);
        temperature = (int)t;
        ui.SetTemperatureTextUI(temperature);
        return temperature;
    }
}
