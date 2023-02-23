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
    [SerializeField] int temperatureModifier;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        temperatureModifier = 1;
        SetStartValues(); //(float)scoreManager.MaxEnergyLevelPoints
        SetImageFillAmountAndColor(startMinValue);
    }

    private void Update()
    {
        fillValue = ScoreManager.Instance.GetFatiguePoints(); //ForDebug in the Inspector
        maxFillValue = ScoreManager.Instance.MaxEnergyLevelPoints;  //ForDebug in the Inspector
        if (Input.GetKey(KeyCode.I))
        {
            IncreaseFill();
        }

        if (Input.GetKey(KeyCode.P))
        {
            DecreaseFill();
        }
    }

    public void SetStartValues()
    {
        normalizedMaxValue = CalculateNormalizedValue((float)ScoreManager.Instance.MaxEnergyLevelPoints, (float)ScoreManager.Instance.MaxEnergyLevelPoints); //=1
        normalizedValue = CalculateNormalizedValue((float)ScoreManager.Instance.GetFatiguePoints(), (float)ScoreManager.Instance.MaxEnergyLevelPoints); //=0
     //  Debug.Log("SetStartValues: normalizedValue" + normalizedValue);
    }

    public override void UpdateFill()
    {
        normalizedValue = CalculateNormalizedValue((float)ScoreManager.Instance.GetFatiguePoints(), (float)ScoreManager.Instance.MaxEnergyLevelPoints);
        //  Debug.Log("UpdateFill: normalizedValue" + normalizedValue);
        SetImageFillAmountAndColor(normalizedValue);
    }

    public void GraduallyDecreaseFill(float time)
    {
        //Decreease with timer
        UpdateFill();
    }

    public override void IncreaseFill() //In Update?
    {
        //15-20 slow
        //20-30 avarage
        //30+ fast

        int points = 1;

      //  if (ScoreManager.Instance.GetFatiguePoints() < ScoreManager.Instance.MaxEnergyLevelPoints) //startMinValue
     //   {
            ScoreManager.Instance.IncreaseFatiguePoints(points * temperatureModifier);
            //the higher the temperature the faster it increases
       // }
        if (ScoreManager.Instance.GetFatiguePoints() >= ScoreManager.Instance.MaxEnergyLevelPoints)
        {
            ReachFatigueMax();
        }

        UpdateFill();
    }
    public override void DecreaseFill()
    {
        int points = 1;

       // if (ScoreManager.Instance.GetFatiguePoints() >= 0)
     //   {
            ScoreManager.Instance.DecreaseFatiguePoints(points);
      //  }
        UpdateFill();
    }


    void ReachFatigueMax()
    {
        Debug.Log("I am tired");
        //bool isTired == true > animation sit and timer od resting
        //  UIManager.isTired = true;

        ColorShadow(red);
    }

}

