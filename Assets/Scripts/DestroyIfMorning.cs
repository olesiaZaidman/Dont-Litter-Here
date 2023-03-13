using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfMorning : MonoBehaviour
{
    TimeController timeController;
    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
    }
    void Update()
    {
        DestroyIfMorningTime();
    }

    public void DestroyIfMorningTime()
    {
        if (timeController.IsEarlyMorning())
        {
            gameObject.SetActive(false);
        }
    }
}
