using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanIndicator : MonoBehaviour
{
    [SerializeField] Image imageFill;
    [SerializeField] Image imageShadow_l;
    [SerializeField] Image imageShadow_d;
    [SerializeField] Color red;

    //64E5FF blue
    [SerializeField] Gradient gradient;
    ScoreManager scoreManager;

    [SerializeField] float fillValue;
    float maxFillValue;
    [SerializeField] float normalizedValue;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        maxFillValue = (float)scoreManager.MaxDirtLevelPoints;
        fillValue = maxFillValue;

        normalizedValue = fillValue / maxFillValue;

        imageFill.fillAmount = fillValue;
        imageFill.color = gradient.Evaluate(1f); //scoreManager.MaxDirtLevelPoints
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateFill()
    {       
        normalizedValue = fillValue / maxFillValue;
        imageFill.fillAmount = normalizedValue;
        imageFill.color = gradient.Evaluate(normalizedValue);
    }

    public void DecreaseFill()
    {
        float dirtPoint = 1f;
        if (fillValue >= 0)
        {
            fillValue -= dirtPoint;
            //  fillValue = (float)(scoreManager.MaxDirtLevelPoints - scoreManager.GetScorePoints());
        }
        else //if (fillValue <= 0)
        { ZeroFill(); }
        UpdateFill();
    }

    public void IncreaseFill()
    {
        float cleanPoint = 20f;
        if (fillValue >= 0 && fillValue <= maxFillValue)
        {
            fillValue += cleanPoint;
        }
        else if (fillValue > maxFillValue)
        { 
            fillValue = maxFillValue; 
        }
        //(float)scoreManager.DirtLevelPoints*4; }
        else //if (fillValue <= 0)
        { ZeroFill(); }
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
