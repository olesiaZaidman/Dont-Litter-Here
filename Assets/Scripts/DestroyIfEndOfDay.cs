using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfEndOfDay : MonoBehaviour
{
    TimeController timeController;
    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
    }
    void Update()
    {
        DestroyIfEndOfWorkingDay();
    }

    public void DestroyIfEndOfWorkingDay()
    {
        if (timeController.IsEndOfWorkingDay())
        {
            gameObject.SetActive(false);
        }
    }
}
