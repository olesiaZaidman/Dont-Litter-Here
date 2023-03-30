using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InputUINameSaver : MonoBehaviour
{

    [Header("Input")]
   // private TMP_InputField inputField;
  [SerializeField] TextMeshProUGUI inputField;
    //private void Start()
    //{
    //    inputField = GetComponent<TMP_InputField>();
    //    inputField.text = "";
    //}

    public string GetInputPlayerName()
    {
        string playerName = inputField.text;
        return playerName;
    }

    //public void OnSelect(PointerEventData eventData)
    //{
    //    inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "";
    //}
}
