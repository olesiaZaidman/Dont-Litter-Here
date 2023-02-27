using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorUI : MonoBehaviour, IUIIndicator
{
    [Header("UI elements")]
    [SerializeField] protected Image imageFill;
    [SerializeField] protected Image imageShadow_l;

    [Header("Colors")]
    [SerializeField] protected Gradient gradient;
    [SerializeField] protected Color redShadow;
    [SerializeField] protected Color whiteShadow;
    //  ScoreManager scoreManager;?

    //   [SerializeField] protected float maxFillValue;
    protected float normalizedMaxValue = 1;
     protected float normalizedMinValue = 0;
   // [SerializeField] protected float fillValue;
  //  protected float normalizedValue;

    void Start()
    {
        
    }
    public void ChangeShadowColorIfNeeded(bool _isTrue)
    {
        if (_isTrue)
        {
            ColorShadow(redShadow);
        }
        else
            ColorShadow(whiteShadow);
    }

    //public virtual void SetStartValues(float _maxValue)
    //{
    //    maxFillValue = _maxValue;
    //    normalizedMaxValue = CalculateNormalizedValue(maxFillValue, maxFillValue); //=1
    //}



    //public virtual float CalculateNormalizedValue(float _fillValue, float _maxValue)
    //{
    //    float _normalizedValue = _fillValue / _maxValue;
    //    return _normalizedValue;
    //}

    public virtual void SetImageFillAmountAndColor(float _value)
    {
        imageFill.fillAmount = _value;
        imageFill.color = gradient.Evaluate(_value);
    }


    public virtual void UpdateFill(float _normValue)
    {
       // normalizedValue = CalculateNormalizedValue(fillValue, maxFillValue);
        SetImageFillAmountAndColor(_normValue);

        //Mathf.Clamp(FatiguePoints.Get() - num, 0, MaxEnergyLevelPoints)
    }

    //public virtual void DecreaseFill()
    //{
    //    float dirtPoint = 1f;
    // //   fillValue -= dirtPoint;
    //    UpdateFill(1);
    //}

    //public virtual void IncreaseFill()
    //{
    //    float points = 20f;
    //  //  fillValue += points;
    //    UpdateFill(1);
    //}

    //public virtual void ZeroFill()
    //{
    //  //  fillValue = 0;
    //}

    public virtual void ColorShadow(Color _color)
    {
        imageShadow_l.color = _color;
    }
}

