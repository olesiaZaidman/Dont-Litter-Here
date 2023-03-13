using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScanner : MonoBehaviour
{
    public static bool isScanning { get; private set; }
    public static bool isWorking { get; private set; }

    [SerializeField] GameObject goldScanner;
    TimeController timeController;

    [SerializeField] bool isRippleEffect = false;

    [SerializeField] ParticleSystem rippleFx;

    [SerializeField] GameObject loot;
    float distanceToLoot = 1.5f;

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        goldScanner.SetActive(false);
        // isTargetFound = false;
    }

    void Update()
    {
        DetermineWorkingOsScanningState();
        TurnGoldScannerOn();

        loot = FindClosestTarget();
        if (loot != null)
        {
            isRippleEffect = IsInTargetInRange(loot, distanceToLoot);

            if (isRippleEffect)
            {
                rippleFx.Play();
            }  
        }
    }

    public GameObject FindClosestTarget()
    {
        GameObject[] instances;
        instances = GameObject.FindGameObjectsWithTag("Loot");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject gameObject in instances)
        {
            Vector3 diff = gameObject.transform.position - position;

            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = gameObject;
                distance = curDistance;
            }
        }
        return closest;
    }

    bool IsInTargetInRange(GameObject _target, float _distance)
    {
        Vector3 position = transform.position;
        Vector3 _distanceToTarget = _target.transform.position - position;
        return _distanceToTarget.magnitude < _distance;
    }

    void DetermineWorkingOsScanningState()
    {
        if (timeController.IsEarlyMorning())
        {
            isScanning = false;
            isWorking = true;
        }

        if (timeController.IsEndOfWorkingDay())
        {
            isScanning = true;
            isWorking = false;
        }
    }

    void TurnGoldScannerOn()
    {
        if (isWorking)
        {
            goldScanner.SetActive(false);
        }

        if (isScanning)
        {
            if (PlayerController.IsCleaningState)
            {
                goldScanner.SetActive(false);
            }
            else
                goldScanner.SetActive(true);

        }
    }
}
