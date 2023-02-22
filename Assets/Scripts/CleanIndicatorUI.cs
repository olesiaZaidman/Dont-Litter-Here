using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanIndicatorUI : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] Image imageFill;
    [SerializeField] Image imageShadow_l;
    [SerializeField] Image imageShadow_d;

    [Header("Rating State")]
    [SerializeField] Image imageRatingIcon;
    [SerializeField] Sprite goodRating;
    [SerializeField] Sprite badRating;

    [Header("Colors")]
    //64E5FF blue
    [SerializeField] Gradient gradient;
    [SerializeField] Color red;
    ScoreManager scoreManager;

    [SerializeField] float maxFillValue;
    float normalizedMaxValue;
    [SerializeField] float fillValue;
    float normalizedValue;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        SetStartValues((float)scoreManager.MaxCleaningnessLevelPoints);
        SetIconSprite(goodRating);
        SetImageFillAmountAndColor(normalizedMaxValue);
    }

    void SetStartValues(float _maxValue)
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

    void SetImageFillAmountAndColor(float _value)
    {
        imageFill.fillAmount = _value;
        imageFill.color = gradient.Evaluate(_value);
    }

    float CalculateNormalizedValue(float _fillValue, float _maxValue)
    {
        float _normalizedValue = _fillValue / _maxValue;
        return _normalizedValue;
    }
 

    public void UpdateFill()
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

    public void DecreaseFill()
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

    public void IncreaseFill()
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

    public void ZeroFill()
    {
        fillValue = 0;
        UIManager.isGameOver = true;
        imageShadow_l.color = red;
        imageShadow_d.color = red;
    }
}
