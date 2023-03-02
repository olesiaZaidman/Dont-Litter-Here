using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class CharactersSpawner : SpawnerWithRotationPosition
{
    protected override float StartDelayMin { get { return 1f; } }
    protected override float StartDelayMax { get { return 10f; } }

    protected float spawnIntervalMin = 5f;
    protected float spawnIntervalMax = 30f;

    TimeController timeController;

    bool isTimeForSpawning = true;
    public CharactersSpawner() : base()
    {
        // yCoordinate = transform.position;
    }
    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolCharactersList;
    }

    public override void CreateTimeIntervalBetweenSpawning()
    {

        _spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
       // Debug.Log("New Interval. Min: "+ spawnIntervalMin + " Max: "+ spawnIntervalMax);
      //  Debug.Log("New Interval itself: " + _spawnInterval);
    }

    private float SetSpawnIntervalMin(float _value)
    {
        spawnIntervalMin = Mathf.Clamp(_value, 0, 60);
        return spawnIntervalMin;
    }

    private float SetSpawnIntervalMax(float _value)
    {
        spawnIntervalMax = Mathf.Clamp(_value, 0, 60);
        return spawnIntervalMax;
    }


    private void StopOrRestartSpawningIfNeeded()
    {
        if (timeController.IsEndOfWorkingDay())
        {
            CancelSpawning();
            isTimeForSpawning = true;
        }
        if (timeController.IsEarlyMorning())
        {
            if (isTimeForSpawning)
            {
                isTimeForSpawning = false;
                StartSpawningWithIntervals();
            }
        }
    }

    private void IncreaseOrDecreseSpawningTime()
    {

        //often:
        if (timeController.IsDay())
        {
          //  Debug.Log("Set to often");
            SetSpawnIntervalMin(1);
            SetSpawnIntervalMax(7);
        }

        //mid
        if (timeController.IsLateMorning() || timeController.IsEarlyEvening()) 
        {
           // Debug.Log("Set to mid");
            SetSpawnIntervalMin(10);
            SetSpawnIntervalMax(18);
        }


        //rare
        if (timeController.IsEarlyMorning() || timeController.IsLateEvening())
        {
          //  Debug.Log("Set to rare");
            SetSpawnIntervalMin(20);
            SetSpawnIntervalMax(40);
        }
    }

    private void Update()
    {
        StopOrRestartSpawningIfNeeded();
        IncreaseOrDecreseSpawningTime();
    }
    public override void StartSettings()
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();
    }

    //public override void StartSpawningWithIntervals()
    //{
    //    base.StartSpawningWithIntervals();
    //    Debug.Log("CharactersSpawner: StartSpawningWithIntervals");

    //}

    //public override void CancelSpawning()
    //{
    //    base.CancelSpawning();
    //    Debug.Log("CharactersSpawner: CancelSpawning");
    //}





}
