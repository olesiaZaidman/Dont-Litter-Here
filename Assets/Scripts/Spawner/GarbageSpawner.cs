using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class GarbageSpawner : BaseSpawner
{
    protected override float StartDelayMin { get { return 3f; ; } }
    protected override float StartDelayMax { get { return 15f; } }
    TimeController timeController;
    MoveForwardWithAnimationController moveController;
    bool isTimeForSpawning = true;
    #region Constructor
    public GarbageSpawner() : base()
    {
        spawnIntervalMin = 5f;
        spawnIntervalMax = 30f;
    }
    #endregion

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        moveController = GetComponent<MoveForwardWithAnimationController>();
    }

    void Update()
    {
        StopOrRestartSpawningIfNeeded();
        // ChangeSpawningTimeBasedOnTimeController();

        if (moveController != null)
        { //Debug.Log(gameObject.name + "  has moveController");
            ChangeSpawningTimeBasedOnActionState();
        }
    }

    #region FROM BASE
    public override void CreateTimeIntervalBetweenSpawning()
    {
        base.CreateTimeIntervalBetweenSpawning();
        Debug.Log(gameObject.name + " CreateTimeIntervalBetweenSpawning");
    }

    public override void StartSpawningWithIntervals()
    {
        base.StartSpawningWithIntervals();
        Debug.Log(gameObject.name + " SpawnInvokeRepeating");
    }

    public override void CancelSpawning()
    {
        base.CancelSpawning();
        Debug.Log(gameObject.name + " CancelSpawning");
    }
    #endregion
    #region Pool //& Spawn
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageBaseList;
    }
    //public override void Spawn()
    //{
    //    base.Spawn();
    //  //  Cleanliness.Instance.RecalculateCleanRatingPoints();       // Cleanliness.Instance.DecreaseCleanRatingPoints(Cleanliness.Points);
    //}
    #endregion

    #region Start Functions //called at Start in Base Spawner

    public override void StartSettings() //called at Start in Base Spawner
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();

        // base.StartSettings();
        //base.StartSettings() is:
        // CreateRandomStartTime();
        //  CreateTimeIntervalBetweenSpawning();
        // StartSpawningWithIntervals(); //= InvokeRepeating
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
    private void ChangeSpawningTimeBasedOnActionState()
    {
        //often:
        if (moveController.GetIsSitting())
        {
             Debug.Log(gameObject.name + " IsSitting.Set to often");
            SetSpawnIntervalMin(1);  //sits in BaseSpawner
            SetSpawnIntervalMax(3); //sits in BaseSpawner
           
        }

        //mid
        if (moveController.GetIsWalking())
        {
             Debug.Log(gameObject.name + " IsWalking. Set to mid");
            SetSpawnIntervalMin(10);
            SetSpawnIntervalMax(18);
            
        }
        ////rare
        //if (timeController.IsEarlyMorning() || timeController.IsLateEvening())
        //{
        //    //    Debug.Log("Set to rare");
        //    SetSpawnIntervalMin(20);
        //    SetSpawnIntervalMax(40);
        //}
    }
    private void ChangeSpawningTimeBasedOnTimeController()
    {
        //often:
        if (timeController.IsDay())
        {
            //  Debug.Log("Set to often");
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
            //    Debug.Log("Set to rare");
            SetSpawnIntervalMin(20);
            SetSpawnIntervalMax(40);
        }
    }

    #endregion





    // private void IncreaseOrDecreseSpawningTime()
    //  {
    //  if (moveController != null)
    //  {
    //if (moveController.GetIsWalking())
    //{
    //    Debug.Log("mid");
    //    SetSpawnIntervalMin(10);
    //    SetSpawnIntervalMax(20);
    //}

    //if (moveController.GetIsSitting())
    //{
    //    Debug.Log("often");
    //    SetSpawnIntervalMin(1);
    //    SetSpawnIntervalMax(5);
    //}
    //   }
    ////often:
    //if (Input.GetKey(KeyCode.P))
    //{
    //    //  Debug.Log("Set to often");
    //    SetSpawnIntervalMin(1);
    //    SetSpawnIntervalMax(5);
    //}

    ////mid
    //if (Input.GetKey(KeyCode.O))
    //{
    //    // Debug.Log("Set to mid");
    //    SetSpawnIntervalMin(5);
    //    SetSpawnIntervalMax(15);
    //}


    ////rare
    //if (Input.GetKey(KeyCode.I))
    //{
    //    //  Debug.Log("Set to rare");
    //    SetSpawnIntervalMin(15);
    //    SetSpawnIntervalMax(30);
    //}
    // }


    //public override void CreateTimeIntervalBetweenSpawning()
    //{

    //    _spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    //  //  Debug.Log("New Interval. Min: " + spawnIntervalMin + " Max: " + spawnIntervalMax);
    //  //  Debug.Log("New Interval itself: " + _spawnInterval);
    //}

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
}
