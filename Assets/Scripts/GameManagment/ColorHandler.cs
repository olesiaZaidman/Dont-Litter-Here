using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    //Since we can't Serialize COLOR - we will store it separetly;

    [SerializeField] Material[] availableColorsMat;
    [SerializeField] Color[] colors; //alternative approach 
    TShirtColor playerTShirt;
    Color selectedColor;

    public Color GetColor(int i)
    {
        return availableColorsMat[i].color;
    }
    void Awake()
    {
        playerTShirt = FindObjectOfType<TShirtColor>();
       // SetSelectedColor(GetColor(0));
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
        HighScoreManager.Instance.CurentPlayerColorSelected(selectedColor);
        /* CurentPlayerColorSelected sets this color from buttonclick 
         * to currentPlayerColor (currentPlayerColor = _color)*/

        //TO DO: should CurentPlayerColorSelected be triggered in OnClickSavePlayerDetails in UIStartMenu?
    }
    public Color GetSelectedMaterial()
    {
        return selectedColor;
    }

}
