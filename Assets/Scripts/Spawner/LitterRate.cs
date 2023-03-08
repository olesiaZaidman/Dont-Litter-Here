using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterRate : MonoBehaviour
{
    IWalkSit walkSitInterface;
    ISunBath sunBathInterface;
    protected int litterRate;
    void Awake()
    {
        walkSitInterface = GetComponent<IWalkSit>();
        sunBathInterface = GetComponent<ISunBath>();
    }

    public virtual int GetLitterRate()
    //   _spawnInterval in Basespawner = litterRate
    {
        if (walkSitInterface != null)
        {
            if (walkSitInterface.GetIsSitting())
            {
                litterRate = Random.Range(1, 5);
                Debug.Log(gameObject.name + " litterRate - GetIsSitting: " + litterRate);
              //  return litterRate;
            }
            return litterRate;
        }
        if (sunBathInterface != null)
        {
            if (sunBathInterface.GetIsSunBathing())
            {
                litterRate = Random.Range(1, 5);
                Debug.Log(gameObject.name + " litterRate -GetIsSunBathing: " + litterRate);
              //  return litterRate;
            }
            return litterRate;
        }

        else
        {
            litterRate = Random.Range(10, 20);
            Debug.Log(gameObject.name + " litterRate: Default Walking" + litterRate);
            return litterRate;
        }
    }

}
