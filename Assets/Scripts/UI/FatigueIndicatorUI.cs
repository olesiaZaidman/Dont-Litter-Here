using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatigueIndicatorUI : IndicatorUI
{
    //Tiredness of player that affect cleaning speed
    //the higher the temperature the faster Fatigue increases
    //15-20 slow
    //20-30 avarage
    //30+ fast
    //we need to consume water to cool down
    //if we reached Max of Fatigue - we need to sit and wait until we fully reconder
    //in the shadow we recover faster!

    ScoreManager scoreManager;
    float startMinValue = 0f;
    [SerializeField] float temperatureModifier;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        temperatureModifier = 1f;
        SetStartValues((float)scoreManager.MaxEnergyLevelPoints);
        SetImageFillAmountAndColor(startMinValue);
    }

    public override void SetStartValues(float _maxValue)
    {
        maxFillValue = _maxValue;
        fillValue = startMinValue;
        normalizedMaxValue = CalculateNormalizedValue(maxFillValue, maxFillValue); //=1
        normalizedValue = CalculateNormalizedValue(fillValue, maxFillValue); //=0
    }

    public override void UpdateFill()
    {
        normalizedValue = CalculateNormalizedValue(fillValue, maxFillValue);
        SetImageFillAmountAndColor(normalizedValue);
    }

    public override void IncreaseFill() //In Update?
    {
        //15-20 slow
        //20-30 avarage
        //30+ fast

        float points = 1f;

        if (fillValue <= 0) //startMinValue
        {
            fillValue += points *temperatureModifier;
            //the higher the temperature the faster it increases
            if (fillValue >= maxFillValue)
            {
                ReachFatigueMax();
            }

            if (fillValue < 0) //startMinValue
            {
                ZeroFill();
            }
        }
        UpdateFill();
    }
    public override void DecreaseFill()
    {
        float dirtPoint = 1f;

        if (fillValue >= 0)
        {
            fillValue -= dirtPoint;
        }
        else
        {
            ZeroFill();
        }

        UpdateFill();
    }


    void ReachFatigueMax()
    {
        fillValue = maxFillValue;
        Debug.Log("I am tired");
        //bool isTired == true > animation sit and timer od resting
        //  UIManager.isTired = true;
        ColorShadow(red);
    }

}

