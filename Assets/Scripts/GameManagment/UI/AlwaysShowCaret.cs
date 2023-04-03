using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AlwaysShowCaret : MonoBehaviour
{
    //TODO    Cursor caret will be visible if ti build and run the game
    //So we don't need this code

    //private TMP_InputField inputField;

    //private void Awake()
    //{
    //    inputField = GetComponent<TMP_InputField>();  // Get the InputField component on startup
    //}

    //private void Start()
    //{
    //    // Add a listener to the InputField's OnSelect event
    //    inputField.onSelect.AddListener(OnSelect);
    //    // Add a listener to the InputField's OnDeselect event
    //    inputField.onDeselect.AddListener(OnDeselect);
    //}

    //private void OnSelect(string value)
    //{
    //    // Set the caret blink rate to its default value to make the caret blink
    //    inputField.caretBlinkRate = 0.85f;
    //}

    //private void OnDeselect(string value)
    //{
    //    // Set the caret blink rate to a very low value to hide the caret
    //    inputField.caretBlinkRate = 1.0f;
    //}


    private TMP_InputField inputField;
    private bool isFocused;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();  // Get the InputField component on startup
    }

    private void Start()
    {
        // Add a listener to the InputField's OnFocus event
        inputField.onSelect.AddListener(OnFocus);
        // Add a listener to the InputField's OnValueChanged event
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnFocus(string value)
    {
        isFocused = true;
        // Set the caret width to 1 to make it always visible
        inputField.caretWidth = 1;
        inputField.caretBlinkRate = 1.0f;
    }

    private void OnValueChanged(string value)
    {
        if (isFocused)
        {
            // Set the caret width to 1 to make it always visible while typing
            inputField.caretWidth = 1;
            inputField.caretBlinkRate = 1.0f;
        }
        else
        {
            // Set the caret width to 0 to hide it when the field is deselected
            inputField.caretWidth = 0;
        }
    }

    private void OnDisable()
    {
        isFocused = false;
    }
}
