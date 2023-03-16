using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPEffect : MonoBehaviour
{
    [SerializeField]  GameObject pinkTint;
    [SerializeField] GameObject blueTint;

    TimeController timeController;

    bool isSwitched = false;

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        isSwitched = false;
        blueTint.SetActive(false);
        pinkTint.SetActive(false);
    }
 
    void Update()
    {
        if (timeController.IsThisTimeInterval(18, 19) && !isSwitched)
        {
            isSwitched = true;
          //  pinkTint.SetActive(true);
          // Debug.Log("pinkTint ON");
        }

        else if (timeController.IsThisTimeInterval(20, 21) && isSwitched)
        {
            isSwitched = false;
          //  Debug.Log("pinkTint OFF");
        }

        else if ((timeController.IsThisTimeInterval(21, 22)|| timeController.IsThisTimeInterval(3, 4f)) &&!isSwitched)
        {
            isSwitched = true;
          //  pinkTint.SetActive(false);
            blueTint.SetActive(true);
          //  Debug.Log("pinkTint OFF");
          //  Debug.Log("blueTint ON");
        }

        else if (timeController.IsThisTimeInterval(5f, 7) && isSwitched)
        {
            isSwitched = false;
            blueTint.SetActive(false);
           // Debug.Log("blueTint OFF");
        }
    }
}
