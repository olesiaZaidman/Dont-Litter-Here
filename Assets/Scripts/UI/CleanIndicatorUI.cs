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
        SetStartValues();
        SetIconSprite(goodRating);
        SetImageFillAmountAndColor(normalizedMaxValue);

        maxFillValue = ScoreManager.Instance.MaxCleaningnessLevelPoints; //ForDebug in the Inspector
        fillValue = ScoreManager.Instance.GetCleanRatingPoints(); //ForDebug in the Inspector
    }

     void Update()
    {
        if(UIManager.isGameOver)
        { return; }
            fillValue = ScoreManager.Instance.GetCleanRatingPoints();//ForDebug in the Inspector
        ScoreManager.Instance.UpdateCleanRatingPoints();
        if (ScoreManager.Instance.GetCleanRatingPoints() <= 0)
        {
            ZeroFill();
        }
        UpdateFill();


    }

    public void SetStartValues()
    {
        normalizedMaxValue = CalculateNormalizedValue((float)ScoreManager.Instance.MaxCleaningnessLevelPoints, (float)ScoreManager.Instance.MaxCleaningnessLevelPoints); //=1
        normalizedValue = CalculateNormalizedValue((float)ScoreManager.Instance.GetCleanRatingPoints(), (float)ScoreManager.Instance.MaxCleaningnessLevelPoints); //=1
    }

    void SetIconSprite(Sprite _sprite)
    {
        imageRatingIcon.sprite = _sprite;
    }


    public override void UpdateFill()
    {
        normalizedValue = CalculateNormalizedValue((float)scoreManager.GetCleanRatingPoints(), (float)scoreManager.MaxCleaningnessLevelPoints);
        SetImageFillAmountAndColor(normalizedValue);

        if (normalizedValue < (normalizedMaxValue*0.5f))
        {
            SetIconSprite(badRating);
        }
        else
            SetIconSprite(goodRating);
    }

    public override void DecreaseFill() //Spawn() in Spawn() 
    {
        ScoreManager.Instance.UpdateCleanRatingPoints();

        if (ScoreManager.Instance.GetCleanRatingPoints() <= 0)
        {
            ZeroFill();
        }

        UpdateFill();
    }

    public override void IncreaseFill()
    {
           ScoreManager.Instance.UpdateCleanRatingPoints();
           UpdateFill();
    }

        //    //DestroyGarbageOnCleaningAnimationState() in PlayerGarbageDestroyer:
        //    //float cleanPoint = 2f;

        //    //if (fillValue >= 0)
        //    //{
        //    //    if (fillValue < maxFillValue)
        //    //    {
        //    //        fillValue += cleanPoint;

        //    //        if (fillValue > maxFillValue)
        //    //        { fillValue = maxFillValue; }
        //    //    }
        //    //    else //(fillValue > maxFillValue)
        //    //    {
        //    //        fillValue = maxFillValue;
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    ZeroFill();
        //    //}

        //}

    public override void ZeroFill()
    {
    //    base.ZeroFill();
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
