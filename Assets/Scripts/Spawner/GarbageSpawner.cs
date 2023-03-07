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
    [SerializeField] bool isTimeForSpawning; //= true
    [SerializeField] bool isSitting; // = false
    [SerializeField] bool isWalking;
    [SerializeField] bool isRestart = false;
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

        if (moveController != null)
        {
            isSitting = moveController.GetIsSitting();
            isWalking = moveController.GetIsWalking();
        }

    }

    void Update()
    {
        StopOrRestartSpawningIfNeeded();
        // ChangeSpawningTimeBasedOnTimeController();

        if (moveController != null)
        { //Debug.Log(gameObject.name + "  has moveController");
            isSitting = moveController.GetIsSitting();
            isWalking = moveController.GetIsWalking();

            ChangeSpawningTimeBasedOnActionState();

        }
    }

    #region FROM BASE
    public override void CreateTimeIntervalBetweenSpawning()
    {
        base.CreateTimeIntervalBetweenSpawning();
        //Debug.Log(gameObject.name + " CreateTimeIntervalBetweenSpawning");
    }

    public override void StartSpawningWithIntervals()
    {
        base.StartSpawningWithIntervals();
       // Debug.Log(gameObject.name + " SpawnInvokeRepeating");
    }

    public override void CancelSpawning()
    {
        base.CancelSpawning();
       // Debug.Log(gameObject.name + " CancelSpawning");
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

        if(isSitting && !isWalking)
        {
            if (!isTimeForSpawning && !isRestart)
            {
              //  Debug.Log(gameObject.name + " isActionStateChanged");
                isTimeForSpawning = true;
                CancelSpawning();
              //  Debug.Log("CancelSpawning & isRestart: " + isRestart);
                if (isTimeForSpawning)
                {
                    isTimeForSpawning = false;
                    StartSpawningWithIntervals();
                    isRestart = true;
                 //   Debug.Log("StartSpawning & isRestart: " + isRestart);
                }
            }
        }

        if (!isSitting && isWalking)
        {
            isRestart = false;
        }
    }
    private void ChangeSpawningTimeBasedOnActionState()
    {
        //often:
        if (moveController.GetIsSitting())
        {           
         //   Debug.Log(gameObject.name + " IsSitting.Set to often");
            SetSpawnIntervalMin(1);  //sits in BaseSpawner
            SetSpawnIntervalMax(3); //sits in BaseSpawner
            CreateTimeIntervalBetweenSpawning();
        }

        //mid
        if (moveController.GetIsWalking())
        {
           
           // Debug.Log(gameObject.name + " IsWalking. Set to mid");
            SetSpawnIntervalMin(10);
            SetSpawnIntervalMax(18);
            CreateTimeIntervalBetweenSpawning();
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
}
