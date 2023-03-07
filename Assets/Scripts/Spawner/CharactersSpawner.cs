using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class CharactersSpawner : SpawnerWithRotationPosition
{
    protected override float StartDelayMin { get { return 1f; } }
    protected override float StartDelayMax { get { return 10f; } }

    //protected float spawnIntervalMin = 5f;
    //protected float spawnIntervalMax = 30f;

    TimeController timeController;

    bool isTimeForSpawning = true;

    #region Constructor
    public CharactersSpawner() : base()
    {
        spawnIntervalMin = 5f;
        spawnIntervalMax = 30f;
    }
    #endregion
    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
    }

    private void Update()
    {
        StopOrRestartSpawningIfNeeded();
        ChangeSpawningTimeBasedOnTimeController();
    }

    #region Pool
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolCharactersList;
    }
    #endregion

    #region Start Functions //called at Start in Base Spawner
    public override void StartSettings() //called at Start in Base Spawner
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();
    }

    #endregion

    #region Update Functions //InvokeRepeating & CancelInvoke  sit in BaseSpawner

    private void StopOrRestartSpawningIfNeeded()
    {
        if (timeController.IsEndOfWorkingDay())
        {
            CancelSpawning();  //sits in BaseSpawner
            isTimeForSpawning = true;
        }
        if (timeController.IsEarlyMorning())
        {
            if (isTimeForSpawning)
            {
                isTimeForSpawning = false;
                StartSpawningWithIntervals();  //sits in BaseSpawner
            }
        }
    }

    private void ChangeSpawningTimeBasedOnTimeController()
    {
        //often:
        if (timeController.IsDay())
        {
          //    Debug.Log("Set to often");
            SetSpawnIntervalMin(1);  //sits in BaseSpawner
            SetSpawnIntervalMax(7); //sits in BaseSpawner
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

    //ALL THIS IN BASE SPAWNER:
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

    #endregion

    #region SpawnInterval //sits in BaseSpawner
    //private float SetSpawnIntervalMin(float _value)
    //{
    //    spawnIntervalMin = Mathf.Clamp(_value, 0, 60);
    //    return spawnIntervalMin;
    //}

    //private float SetSpawnIntervalMax(float _value)
    //{
    //    spawnIntervalMax = Mathf.Clamp(_value, 0, 60);
    //    return spawnIntervalMax;
    //}

    #endregion







}
