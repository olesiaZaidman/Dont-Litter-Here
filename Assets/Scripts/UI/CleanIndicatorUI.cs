using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanIndicatorUI : IndicatorUI
{
    [Header("UI Extra elements")]
    [SerializeField] Image imageShadow_d;

    [Header("Rating State")]
    [SerializeField] Image imageRatingIcon;
    [SerializeField] Sprite goodRating;
    [SerializeField] Sprite badRating;

    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        SetStartValues((float)scoreManager.MaxCleaningnessLevelPoints);
        SetIconSprite(goodRating);
        SetImageFillAmountAndColor(normalizedMaxValue);
    }

   public override void SetStartValues(float _maxValue)
    {
        maxFillValue = _maxValue; 
        fillValue = maxFillValue;
        normalizedMaxValue = CalculateNormalizedValue(maxFillValue, maxFillValue); //=1
        normalizedValue = CalculateNormalizedValue(fillValue, maxFillValue); //=1
    }

    void SetIconSprite(Sprite _sprite)
    {
        imageRatingIcon.sprite = _sprite;
    }


    public override void UpdateFill()
    {
        normalizedValue = CalculateNormalizedValue(fillValue, maxFillValue);
        SetImageFillAmountAndColor(normalizedValue);

        if (normalizedValue < (normalizedMaxValue*0.5f))
        {
            SetIconSprite(badRating);
        }
        else
            SetIconSprite(goodRating);
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

    public override void IncreaseFill()
    {
        float cleanPoint = 20f;

        if (fillValue >= 0)
        {
            if (fillValue < maxFillValue)
            {
                fillValue += cleanPoint;

                if (fillValue > maxFillValue)
                { fillValue = maxFillValue; }
            }
            else //(fillValue > maxFillValue)
            {
                fillValue = maxFillValue;
            }
        }
        else
        {
            ZeroFill();
        }
        UpdateFill();
    }

    public override void ZeroFill()
    {
        base.ZeroFill();
        UIManager.isGameOver = true;
        ColorShadow(red);
    }

    public override void ColorShadow(Color _color)
    {
         base.ColorShadow(_color);
       // imageShadow_l.color = _color;
        imageShadow_d.color = _color;
    }
}
