using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InputUINameSaver : MonoBehaviour
{

    [Header("Input")]
    [SerializeField] TextMeshProUGUI inputField;

    public string GetInputPlayerName()
    {
        Debug.Log("GetInputPlayerName");
        string playerName = inputField.text;
        return playerName;
    }
}
