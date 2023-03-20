using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    [SerializeField] Material[] availableColorsMat;
    [SerializeField] Color[] colors; //alternative approach 
    TShirtColor playerTShirt;
    ButtonColorPicker colorPicker;

    Color selectedColor;

    public Color GetColor(int i)
    { 
        return availableColorsMat[i].color; 
    }
    void Awake()
    {
        playerTShirt = FindObjectOfType<TShirtColor>();
        colorPicker = FindObjectOfType<ButtonColorPicker>();

        if (colorPicker != null)
        {
            SetSelectedColor(GetColor(0));
        }
    }

    void Start()
    {
        if (playerTShirt != null)
        {
            playerTShirt.ChangeColor(selectedColor);
        }
    }

    public void SetSelectedColor(Color _color)
    {
        selectedColor = _color;
        playerTShirt.ChangeColor(_color);
    }
    public Color GetSelectedMaterial()
    {
        return selectedColor;
    }

}
