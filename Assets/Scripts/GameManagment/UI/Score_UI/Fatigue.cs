using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatigue : MonoBehaviour
{
    //TODO:
    //we need to consume water to cool down
    //if we reached Max of Fatigue - we need to sit and wait until we fully reconder
    //in the shadow we recover faster!

    TemperatureManager temperatureManager;
    public static Fatigue Instance; // GetFatiguePoints()
    public float MaxEnergyLevelPoints { get { return 100; } }

    FatigueIndicatorUI fatigueUI;

    int temperatureModifier = 1;
    float timeForGraduallFatigueIncreaseIfHot = 150f;

   // [SerializeField] GameObject heatVignette;

    void SetTemperModifier()
    {
        if (temperatureManager.GetTemperature() > 20 && temperatureManager.GetTemperature() <= 30)
        {
           // heatVignette.SetActive(true);
            temperatureModifier = 2;
        }

        else if (temperatureManager.GetTemperature() > 30)
        {
            temperatureModifier = 3;
          //  heatVignette.SetActive(true);
        }
        else
        {
           // heatVignette.SetActive(false);
            temperatureModifier = 1;
        }
         
    }
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
        temperatureManager = FindObjectOfType<TemperatureManager>();
        fatigueUI = FindObjectOfType<FatigueIndicatorUI>();
        FatiguePoints.Initialize(OnUpdateFatigue);
      //  heatVignette.SetActive(false);
    }
    void Update()
    {
        SetTemperModifier();
        if (PlayerController.IsTiredState)
        {
            GraduallyDecreaseFill(PlayerController.TimeSittingTiredAnimation);
        }

        if (temperatureModifier > 1)
        { Fatigue.Instance.GraduallyIncreaseFill(timeForGraduallFatigueIncreaseIfHot); }
    }

    //void ChangeFatigueOnButtonPressed() //Tested in Update
    //{
    //    //if (Input.GetKey(KeyCode.Z))
    //    //{
    //    //    GraduallyDecreaseFill(time);
    //    //}

    //    //if (Input.GetKey(KeyCode.LeftShift))
    //    //{
    //    //    GraduallyIncreaseFill(time);
    //    //}

    //    //if (Input.GetKey(KeyCode.I))
    //    //{
    //    //    IncreaseFatiguePoints(points* temperatureModifier);
    //    //}

    //    //if (Input.GetKey(KeyCode.P))
    //    //{
    //    //    DecreaseFatiguePoints(points);
    //    //}
    //}

    public class FatiguePoints
    {
        static float fatiguePoints = 0;
        public delegate void OnUpdateDelegate(float _fatiguePoints);

        static OnUpdateDelegate onUpdateDelegateInstance;

        public static void Initialize(OnUpdateDelegate _onUpdate)
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
            onUpdateDelegateInstance(_fatiguePoints);
            //each time we set the value the whole logic flows: fatigueValue >delegate> to functiomc> Notrmalize & Update fill
            return fatiguePoints;
        }
    }


    #region Fatigue

    public float ZeroDownFatigue()
    { return FatiguePoints.Set(0); }

    public float GetFatiguePoints()
    { return FatiguePoints.Get(); }

    public float IncreaseFatiguePoints(float num)
    {
        return FatiguePoints.Set(Mathf.Clamp(FatiguePoints.Get() + num, 0, MaxEnergyLevelPoints));
    }

    public float DecreaseFatiguePoints(float num)
    {

        return FatiguePoints.Set(Mathf.Clamp(FatiguePoints.Get() - num, 0, MaxEnergyLevelPoints));
    }

    public void GraduallyDecreaseFill(float _time) //works in Update
    {
        if (FatiguePoints.Get() > 0)
        {
            float acceleration = (MaxEnergyLevelPoints - 0) / _time;
            FatiguePoints.Set(FatiguePoints.Get() - acceleration * Time.deltaTime);   //  fatiguePoints -= acceleration * Time.deltaTime;
        }
        else
            ZeroDownFatigue();
    }

    public void GraduallyIncreaseFill(float _time) //works in Update
    {
        if (FatiguePoints.Get() < MaxEnergyLevelPoints)
        {
            float acceleration = (MaxEnergyLevelPoints - 0) / _time;
            FatiguePoints.Set(FatiguePoints.Get() + temperatureModifier* acceleration * Time.deltaTime);   //  fatiguePoints -= acceleration * Time.deltaTime;
        }
        else
            FatiguePoints.Set(MaxEnergyLevelPoints);
    }

    #endregion
}
