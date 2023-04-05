using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObject : MonoBehaviour
{
   [SerializeField] Toggle toggleButton;
    [SerializeField] GameObject objectToToggle;

    void Awake()
    {
        toggleButton.isOn = false;
    }
    private void Start()
    {
        objectToToggle.SetActive(toggleButton.isOn);
    }   
}
