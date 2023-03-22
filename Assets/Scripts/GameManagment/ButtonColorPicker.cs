using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonColorPicker : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    //  TShirtColor playerTShirt;
    ColorHandler colorHandler;
    void Awake()
    {
        colorHandler = FindObjectOfType<ColorHandler>();

        for (int i = 0; i < buttons.Length; i++)
        {
            Color color = colorHandler.GetColor(i);
            color.a = 0.7333333f; //transperancy
            buttons[i].image.color = color;
        }
    }
    #region Color_Buttons
    public void OnClickButtonColor0()
    {
        SetSelectedMaterial(0);
    }

    public void OnClickButtonColor1()
    {
        SetSelectedMaterial(1);
    }

    public void OnClickButtonColor2()
    {
        SetSelectedMaterial(2);
    }

    public void OnClickButtonColor3()
    {
        SetSelectedMaterial(3);
    }


    public void OnClickButtonColor4()
    {
        SetSelectedMaterial(4);
    }

    public void OnClickButtonColor5()
    {
        SetSelectedMaterial(5);
    }

 

    public void OnClickButtonColor6()
    {
        SetSelectedMaterial(6);
    }

    public void OnClickButtonColor7()
    {
        SetSelectedMaterial(7);
    }

    public void OnClickButtonColor8()
    {
        SetSelectedMaterial(8);
    }

    public void OnClickButtonColor9()
    {
        SetSelectedMaterial(9);
    }
    #endregion

    void SetSelectedMaterial(int i)
    {
        colorHandler.SetSelectedColor(colorHandler.GetColor(i));
    }


    public Color GetDefultMaterial()
    {
        return colorHandler.GetColor(0);
    }


}
