using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class GarbageSpawner : SpawnWithOffset
{
    //Events for state machine - time of the day or action state
    //OBSERVER PATTERN with Events {TELL DONT ASK}

    //BUG:
    //When we restar-SitingWalking litter waits to restart and appears when the character walks away?
    //Invoke Repeating works badly here
  
    protected override float StartDelayMin { get { return 3f; ; } }
    protected override float StartDelayMax { get { return 15f; } }

    TimeController timeController;
   // MoveForwardWithAnimationController moveController;//   MoveForwardWithSunBathing moveControllerSun;
    LitterRate lR;

  //  [SerializeField] bool isTimeForSpawning; //= true
    [SerializeField] bool isWalking;
    [SerializeField] bool isRestartSpawning = false;
    #region Constructor
    public GarbageSpawner() : base()
    {
        spawnIntervalMin = 5f;
        spawnIntervalMax = 40f;
    }
    #endregion

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        lR = GetComponent<LitterRate>();
    }

    void Update()
    {
        if (timeController.IsEndOfWorkingDay())
        {           
            CancelSpawning();  //sits in BaseSpawner
          //  isTimeForSpawning = true;
        }
        //if (timeController.IsEarlyMorning())
        //{
        //    if (isTimeForSpawning)
        //    {
        //        isTimeForSpawning = false;
        //        StartSpawningWithIntervals();  //sits in BaseSpawner
        //    }
        //}

     //   ChangeSpawningTimeBasedOnTimeController();
    }

    #region FROM BASE
    //public override void CancelSpawning()
    //{
    //    CancelInvoke("Spawn");
    //    Debug.Log(gameObject.name+" IsEndOfWorkingDay should Cancel from Garbage");
    //}
 
    //public override void CreateTimeIntervalBetweenSpawning()
    //{     
    //    _spawnInterval = lR.GetLitterRate(); //  base.CreateTimeIntervalBetweenSpawning();
    //}

    //public override void StartSpawningWithIntervals()
    //{
    //    StartCoroutine(SpawningRoutine(_spawnInterval));
    //}
    //public IEnumerator SpawningRoutine(float _delay)
    //{
    //    if (isRestartSpawning)
    //    {
    //        isRestartSpawning = false;
    //        Spawn();
    //        Debug.Log(gameObject.name + "Just Spawned");
    //        Debug.Log("_spawnInterval: " + _spawnInterval);
    //    }
    //    yield return new WaitForSeconds(_delay);
    //    isRestartSpawning = true;
    //}

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

    //public override void StartSettings() //called at Start in Base Spawner
    //{
    //    base.StartSettings();
    //    Debug.Log(gameObject.name+" StartSettings from Garbage");
    //    //CreateRandomStartTime();
    //    //CreateTimeIntervalBetweenSpawning();
    //}
    #endregion

    #region Update Functions //InvokeRepeating & CancelInvoke  sit in BaseSpawner

    //private void StopOrRestartSpawningIfNeeded()
    //{
    //    if (timeController.IsEndOfWorkingDay())
    //    {
    //        StopCoroutine(SpawningRoutine(_spawnInterval));  //sits in BaseSpawner
    //        isTimeForSpawning = true;
    //    }
    //    if (timeController.IsEarlyMorning())
    //    {
    //        if (isTimeForSpawning)
    //        {
    //            isTimeForSpawning = false;
    //            StartSpawningWithIntervals();  //sits in BaseSpawner
    //        }
    //    }

    //    //if(!isWalking)
    //    //{
    //    //    //if (!isTimeForSpawning && !isRestart)
    //    //    //{               
    //    //    //    isTimeForSpawning = true;
    //    //    //    CancelSpawning();
    //    //    //    if (isTimeForSpawning)
    //    //    //    {
    //    //    //        isTimeForSpawning = false;
    //    //    //        StartSpawningWithIntervals();
    //    //    //        isRestart = true;
    //    //    //    }
    //    //    //}
    //    //}

    //    //if (isWalking)
    //    //{
    //    //    isRestart = false;
    //    //}
    //}

    private void ChangeSpawningTimeBasedOnTimeController()
    {
        //often:
        if (timeController.IsDay())
        {
              Debug.Log("Set to often");
            SetSpawnIntervalMin(1);  //sits in BaseSpawner
            SetSpawnIntervalMax(7); //sits in BaseSpawner
        }

        //mid
        if (timeController.IsLateMorning() || timeController.IsEarlyEvening())
        {
             Debug.Log("Set to mid");
            SetSpawnIntervalMin(10);
            SetSpawnIntervalMax(18);
        }


        //rare
        if (timeController.IsEarlyMorning() || timeController.IsLateEvening())
        {
               Debug.Log("Set to rare");
            SetSpawnIntervalMin(20);
            SetSpawnIntervalMax(40);
        }
    }

    #endregion
}
