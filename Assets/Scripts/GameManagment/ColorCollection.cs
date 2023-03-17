using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorCollection : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] Color yellowColor; //FFD900 yellow
    [SerializeField] Color whiteColor; //FFFFFF white
    [Header("UI Panel")]
    [SerializeField] Color transparentGrey; //3A3636 transparentGrey

    [Header("UI Buttons")]
    [SerializeField] Color transparentWhite; //FFFFFF transparentGrey
    [SerializeField] Color transparentGreyHighlight;     //CABDBD
    [SerializeField] Color transparentGreyPressed;  //938E8E
    [SerializeField] Color transparentGreyDisabled;  //C8C8C8

    [Header("BeachRating")]
    [SerializeField] Color blueRating; 
    [SerializeField] Color orangeRating;
    [SerializeField] Color redRating;
    [SerializeField] Color redShadow;
    [SerializeField] Color whiteShadow;
    [SerializeField] Color orangeFatigue;
    [SerializeField] Color redFatigue;

    [Header("Light")]
    [SerializeField] Color violetDusk; //7033F1 violet
    [SerializeField] Color dayLightYellow; //FFF4D6 dayLight
    [SerializeField] Color blueNight;
    [SerializeField] Color redSunset; //FF5B58 redSunset
    void Awake()
    {
        yellowColor = new Color(1f, 0.8509804f, 0f, 1f); //FFD900 yellow
        whiteColor = Color.white;
        transparentGrey = new Color(0.2264151f, 0.2123176f, 0.2123176f, 0.2980392f); //FFD900 yellow

        transparentWhite = new Color(1f, 1f, 1f, 0.05098039f); //FFFFFF transparentWhite
        transparentGreyHighlight = new Color(0.7924528f, 0.7431114f, 0.7431114f, 1f);     //CABDBD
        transparentGreyPressed = new Color(0.5754717f, 0.5559274f, 0.5559274f, 1f);          //938E8E
        transparentGreyDisabled = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5019608f);  //C8C8C8

        violetDusk = new Color(0.4410916f, 0.1993591f, 0.9433962f, 1f); //7033F1 violet
        dayLightYellow = new Color(1f, 0.9568627f, 0.8392157f, 1f);  //FFF4D6 dayLight
        blueNight = Color.blue;
        redSunset = new Color(1f, 0.3568628f, 0.345098f, 1f);// FF5B58 redSunset


        blueRating = new Color(0.2207547f, 0.412168f, 1f, 1f); //3869FF
        orangeRating = new Color(1f, 0.7411765f, 0.3921569f, 1f); //FFBD64
        redRating = new Color(1f, 0.4352941f, 0.3921569f, 1f); //FF6F64

        redShadow = new Color(1f, 0.4352941f, 0.3921569f, 0.6941177f); //FF6F64
        whiteShadow = new Color(0.8352941f, 0.8941177f, 0.9921569f, 0.4823529f); //D5E4FD

        orangeFatigue = new Color(1f, 0.7418483f, 0.03207541f, 1f); //FFBD08
        redFatigue = new Color(1f, 0.2544284f, 0f, 1f); //FF4100

    }

    public void ChangeTextColour(TextMeshProUGUI _text, Color _color)
    {
        _text.color = _color;
    }

    #region UI Tex  & Panel
    public Color GetYellow()
    {
        return yellowColor;
    }
    public Color GetWhite()
    {
        return whiteColor;
    }

    public Color GetTansparentGrey()
    {
        return transparentGrey;
    }
    #endregion

    #region UI Buttons 
    public Color GetTansparentWhite()
    {
        return transparentWhite;
    }
    #endregion

    #region Light


    public Color GetVioletDusk()
    {
        return violetDusk;
    }

    public Color GetDayLightYellow()
    {
        return dayLightYellow;
    }

    public Color GetBlueNight()
    {
        return blueNight;
    }

    public Color GetRedSunset()
    {
        return redSunset;
    }
    #endregion


}
