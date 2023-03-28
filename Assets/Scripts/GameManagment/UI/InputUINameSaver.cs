using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InputUINameSaver : MonoBehaviour
{
    [Header("Input")]
    public TextMeshProUGUI inputField;

    public string GetInputPlayerName()
    {
        string playerName = inputField.text;
        return playerName;
    }
}
