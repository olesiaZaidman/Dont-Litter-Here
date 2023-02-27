using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatigue : MonoBehaviour
{
    //TODO:
    //1- Gradually Decrese Fatigue in GraduallyDecreaseFill() && 
    //ScoreManager.Instance.RestDown(time);
    //OR SpeedDown() in PlayerController


    //2-the higher the temperature the faster Fatigue increases
    //15-20 slow
    //20-30 avarage
    //30+ fast
    //we need to consume water to cool down
    //if we reached Max of Fatigue - we need to sit and wait until we fully reconder
    //in the shadow we recover faster!


    public static Fatigue Instance;
    public float MaxEnergyLevelPoints { get { return 100; } }

    FatigueIndicatorUI fatigueUI;

    [SerializeField] int temperatureModifier = 1;
    [SerializeField] int points = 1;
    [SerializeField] float time = 5;
    float NormalizeValue(float _fillValue)
    {
        float _normalizedValue = _fillValue / MaxEnergyLevelPoints;
        return _normalizedValue;
    }

    void OnUpdateFatigue(float newFatigue)
    {
        float normalized = NormalizeValue(newFatigue);
        fatigueUI.UpdateFill(normalized);
    }

    void Awake()
    {
        Instance = this;
        fatigueUI = FindObjectOfType<FatigueIndicatorUI>();
        FatiguePoints.Initialize(OnUpdateFatigue);
    }
    private void Update()
    {
        ChangeFatigueOnButtonPressed();
    }

    void ChangeFatigueOnButtonPressed()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            GraduallyDecreaseFill(time);
        }

        if (Input.GetKey(KeyCode.I))
        {
            IncreaseFillAccordingToTemperature(points, temperatureModifier);
        }

        if (Input.GetKey(KeyCode.P))
        {
            DecreaseFatiguePoints(points);
        }
    }

    public class FatiguePoints
    {
        static float fatiguePoints = 0;
        public delegate void OnUpdateDelegate(float _fatiguePoints); //step 1

        static OnUpdateDelegate onUpdateDelegateInstance;  //instance - step 2

        public static void Initialize(OnUpdateDelegate _onUpdate) //step 3: equal to the function OnUpdateFatigue(float newFatigue)
        {
            onUpdateDelegateInstance = _onUpdate;
        }

        public static float Get()
        {
            return fatiguePoints;
        }

        public static float Set(float _fatiguePoints)
        {
            fatiguePoints = _fatiguePoints;
            onUpdateDelegateInstance(_fatiguePoints); //step 4: give a value to delegate that passes it to the function OnUpdateFatigue(float newFatigue)
            //that normalizes it and passes it to UpdateFill
            //each time we set the value the whole logic flows: fatigueValue >delegate> to functiomc> Notrmalize & Update fill
            return fatiguePoints;
        }


        //USUAL DELEGATE STEPS:
        //delegate void OnUpdateFill(float _fatiguePoints); //step 1
        //OnUpdateFill myDelegateUpdateFill = fatigueUI.UpdateFill; //step 2 & 3
        //  myDelegateUpdateFill(normalizedValue);   //OR myDelegateUpdateFill.Invoke(normalizedValue); //step4
    }


    #region Fatigue

    public float ZeroDownFatigue()
    { return FatiguePoints.Set(0); }

    public float GetFatiguePoints()
    { return FatiguePoints.Get(); }

    public float IncreaseFatiguePoints(float num)
    {
        return FatiguePoints.Set(Mathf.Clamp(FatiguePoints.Get() + num, 0, MaxEnergyLevelPoints));
        // FatiguePoints.MaxEnergyLevelPoints

        //if (FatiguePoints.Get() >= FatiguePoints.MaxEnergyLevelPoints)
        //{
        //    return FatiguePoints.Set(FatiguePoints.MaxEnergyLevelPoints);
        //}

    }

    public float DecreaseFatiguePoints(float num)
    {
        return FatiguePoints.Set(Mathf.Clamp(FatiguePoints.Get() - num, 0, MaxEnergyLevelPoints));
        //if (fatiguePoints <= 0)
        //{
        //    fatiguePoints = 0;
        //    return fatiguePoints;
        //}

    }

    public void RestDown(float _time) //works in Update
    {
        if (FatiguePoints.Get() > 0)
        {
            float acceleration = (MaxEnergyLevelPoints - 0) / _time;
            FatiguePoints.Set(FatiguePoints.Get() - acceleration * Time.deltaTime);   //  fatiguePoints -= acceleration * Time.deltaTime;
        }
        else
            ZeroDownFatigue();
    }

    #endregion

    public void GraduallyDecreaseFill(float time)
    {
        //Decrease with timer
        Fatigue.Instance.RestDown(time);
    }

    public void IncreaseFillAccordingToTemperature(float _points, float _temperatureModifier)
    {
        //15-20 slow
        //20-30 avarage
        //30+ fast
        Fatigue.Instance.IncreaseFatiguePoints(_points * _temperatureModifier);
    }
    //public  void DecreaseFill()
    //{
    //    int points = 1;
    //    Fatigue.Instance.DecreaseFatiguePoints(points);
    //}

    public void DecreaseFillOnDrinkingWater(int points)
    {
        Fatigue.Instance.DecreaseFatiguePoints(points);
    }

}
