using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatigueIndicatorUI : IndicatorUI
{
    void Start()
    {
        SetImageFillAmountAndColor(normalizedMinValue);  // from parent = 0
    }

    public override void UpdateFill(float _normValue) //
    {
      SetImageFillAmountAndColor(_normValue);
      ChangeShadowColorIfNeeded(Fatigue.Instance.GetFatiguePoints() >= Fatigue.Instance.MaxEnergyLevelPoints);
    }

    //   Patent Content IndicatorUI: 
    //public virtual void SetImageFillAmountAndColor(float _value)
    //{
    //    imageFill.fillAmount = _value;
    //    imageFill.color = gradient.Evaluate(_value);
    //}


}

