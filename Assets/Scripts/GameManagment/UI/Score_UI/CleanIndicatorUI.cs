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

    void Start()
    {
        SetIconSprite(goodRating);
        SetImageFillAmountAndColor(normalizedMaxValue); //from parent: = 1
    }

    void SetIconSprite(Sprite _sprite)
    {
        imageRatingIcon.sprite = _sprite;
    }
    public override void UpdateFill(float _normValue)
    {
        ChangeShadowColorIfNeeded(Cleanliness.Instance.GetCleanRatingPoints() <= 0);
        SetImageFillAmountAndColor(_normValue);
        ChangeIconSpriteIfNeeded(_normValue <=  0.5f);
    }


    void ChangeIconSpriteIfNeeded(bool _isTrue)
    {
        if (_isTrue)
        {
           // Debug.Log("badRating");
            SetIconSprite(badRating);
        }
        else
            SetIconSprite(goodRating);
    }

    public override void ColorShadow(Color _color)
    {
        base.ColorShadow(_color);
        // imageShadow_l.color = _color;
        imageShadow_d.color = _color;
    }
}
