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
    [SerializeField] protected Color red;
    //  ScoreManager scoreManager;?

    [SerializeField] protected float maxFillValue;
    protected float normalizedMaxValue;
    [SerializeField] protected float fillValue;
    protected float normalizedValue;

    void Start()
    {
        
    }

    public virtual void SetStartValues(float _maxValue)
    {
        maxFillValue = _maxValue;
        normalizedMaxValue = CalculateNormalizedValue(maxFillValue, maxFillValue); //=1
        // fillValue = maxFillValue;
        //  normalizedValue = CalculateNormalizedValue(fillValue, maxFillValue); //=1
    }

    public virtual float CalculateNormalizedValue(float _fillValue, float _maxValue)
    {
        float _normalizedValue = _fillValue / _maxValue;
        return _normalizedValue;
    }

    public virtual void SetImageFillAmountAndColor(float _value)
    {
        imageFill.fillAmount = _value;
        imageFill.color = gradient.Evaluate(_value);
    }


    public virtual void UpdateFill()
    {
        normalizedValue = CalculateNormalizedValue(fillValue, maxFillValue);
        SetImageFillAmountAndColor(normalizedValue);
    }

    public virtual void DecreaseFill()
    {
        float dirtPoint = 1f;
        fillValue -= dirtPoint;
        UpdateFill();
    }

    public virtual void IncreaseFill()
    {
        float points = 20f;
        fillValue += points;
        UpdateFill();
    }

    public virtual void ZeroFill()
    {
        fillValue = 0;
    }

    public virtual void ColorShadow(Color _color)
    {
        imageShadow_l.color = _color;
    }
}

