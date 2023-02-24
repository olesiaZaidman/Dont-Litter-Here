using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseValueOverTime : MonoBehaviour
{
    //How to increase number/value over time


    public float gradualPoints = 100;
    float maxSpeed = 100;
    float minSpeed = 0; //or1
    float time = 3f;
    void Update()
    {
        //if (Input.GetKey(KeyCode.Z))          
        //{
        //   // Acceleration();
        //    //  SpeedUpOne();
        //   SpeedDown(time);
        //}
    }
   public void SpeedDown(float _time)
    {
        if (gradualPoints > 0)
        {
            float acceleration = (maxSpeed - minSpeed) / _time;
            gradualPoints -= acceleration * Time.deltaTime;
        }
        else
            gradualPoints = 0;
    }

    public void SpeedDown(float value, float maxvalue, float minValue, float _time)
    {
        if (value > 0)
        {
            float acceleration = (maxvalue - minValue) / _time;
            value -= acceleration * Time.deltaTime;
        }
        else
            value = 0;
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
    //void Acceleration()
    //{
    //    if (Input.GetKey(KeyCode.Z))
    //    {
    //        if (gradualPoints < maxSpeed)
    //        {
    //            gradualPoints += speedAccelerationPerSecond * Time.deltaTime;
    //        }
    //        else
    //        {
    //            gradualPoints = maxSpeed;
    //        }
    //    }
    //    else
    //    {

    //        if (gradualPoints > 0)
    //        {
    //            gradualPoints -= speedAccelerationPerSecond * Time.deltaTime;
    //            //possibly speedDeaccelerationPerSecond depending on your needs
    //        }
    //        else
    //        {
    //            gradualPoints = 0;
    //        }
    //    }
    //}



}
