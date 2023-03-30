
using UnityEngine;
using TMPro;

public class ClearInputPlaceholder : MonoBehaviour
{
    //TODO: Cursor caret will be visible if ti build and run the game

    private TMP_InputField inputField;

    void Awake()
    {
        inputField = GetComponent<TMP_InputField>();  // Get the InputField component on startup
    }

    void Start()
    {
        inputField.onSelect.AddListener(ClearPlaceholder);  // Add a listener to the InputField's OnSelect event
    }

    void Update()
    {
      //  inputField.caretWidth = 1;
    }

    public void ClearPlaceholder(string text)
    {
        if (inputField.placeholder != null)
        {
            inputField.placeholder.GetComponent<TMP_Text>().text = "";  // Set the placeholder text to an empty string          
        }
    }



    //private void Start()
    //{
    //    inputField = GetComponent<TMP_InputField>();
    //}

    //public void DisablePlaceholder()
    //{
    //    inputField.placeholder.gameObject.SetActive(false);
    //}
}
