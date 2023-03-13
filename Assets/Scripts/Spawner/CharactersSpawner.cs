using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class CharactersSpawner : SpawnerWithRotationPosition
{
    protected override float StartDelayMin { get { return 1f; } }
    protected override float StartDelayMax { get { return 10f; } }

    TimeController timeController;

    bool isTimeForSpawning = true;

    #region Constructor
    public CharactersSpawner() : base()
    {
        spawnIntervalMin = 1f;
        spawnIntervalMax = 60f;
    }
    #endregion
    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
    }

    private void Update()
    {
        StopOrRestartSpawningIfNeeded();
     //   ChangeSpawningTimeBasedOnTimeController();
    }

    //void OnEnable()
    //{
    //    timeController = FindObjectOfType<TimeController>();
    //    ChangeSpawningTimeBasedOnTimeController();
    //}

//    public override void CreateTimeIntervalBetweenSpawning()
//    //_spawnInterval = lR.GetLitterRate(); ????
//    {
//        int _spawnIntervalMax = SetSpawnIntervalMax();
//        int _spawnIntervalMin = SetSpawnIntervalMin();
//        _spawnInterval = Random.Range(_spawnIntervalMin, _spawnIntervalMax);
//        Mathf.Clamp(_spawnInterval, _spawnIntervalMin, _spawnIntervalMax);
//        Debug.Log("_spawnIntervalMax: " + _spawnIntervalMax);
//        Debug.Log("_spawnIntervalMin: " + _spawnIntervalMin); //_spawnIntervalMin
//    }

//    int SetSpawnIntervalMin()
//    {
//        if (timeController.IsDay())
//        {
//            Debug.Log("IsDay(): ");
//            return 1;
//        }
////mid
//        else if (timeController.IsEarlyEvening())
//        {
//            Debug.Log("IsLateMorning()  or IsEarlyEvening(): ");
//            return 10;
//        }

//        //rare
//        else //if(timeController.IsEarlyMorning())
//        {

//            Debug.Log("IsEarlyMorning(): ");
//            return 30;
//        }
//    }

//    int SetSpawnIntervalMax()
//    {
//        //int _spawnIntervalMax;
//        if (timeController.IsDay())
//        {
//            Debug.Log("IsDay(): ");
//            return 3;
//        }

//        //mid
//        else if (timeController.IsEarlyEvening())
//        {
//            Debug.Log("IsLateMorning()  or IsEarlyEvening(): ");
//            return 30;
//        }

//        //rare
//        else //if(timeController.IsEarlyMorning())
//        {

//            Debug.Log("IsEarlyMorning(): ");
//            return 70;
//        }
//    }

    #region Pool
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolCharactersList;
    }
    #endregion

    //#region Start Functions //called at Start in Base Spawner

    //#endregion

    #region Update Functions //InvokeRepeating & CancelInvoke  sit in BaseSpawner


    private void StopOrRestartSpawningIfNeeded()
    {
        if (timeController.IsEndOfWorkingDay())
        {
            CancelSpawning();  //sits in BaseSpawner  //+ DestroyIfEndOfDay() on each gamePRefab
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

       //else if (timeController.IsDay())
       // {
       //     CancelSpawning();  //sits in BaseSpawner  //+ DestroyIfEndOfDay() on each gamePRefab
       //     isTimeForSpawning = true;

       //     if (isTimeForSpawning)
       //     {
       //         isTimeForSpawning = false;
       //         StartSpawningWithIntervals();  //sits in BaseSpawner
       //     }
       // }

       // else if (timeController.IsEarlyEvening())
       // {
       //     CancelSpawning();  //sits in BaseSpawner  //+ DestroyIfEndOfDay() on each gamePRefab
       //     isTimeForSpawning = true;

       //     if (isTimeForSpawning)
       //     {
       //         isTimeForSpawning = false;
       //         StartSpawningWithIntervals();  //sits in BaseSpawner
       //     }
       // }


        //if (timeController.IsLateMorning())
        //{
        //    CancelSpawning();  //sits in BaseSpawner  //+ DestroyIfEndOfDay() on each gamePRefab
        //    isTimeForSpawning = true;

        //    if (isTimeForSpawning)
        //    {
        //        isTimeForSpawning = false;
        //        StartSpawningWithIntervals();  //sits in BaseSpawner
        //    }
        //}
        //if (timeController.IsLateEvening())
        //{
        //    CancelSpawning();  //sits in BaseSpawner  //+ DestroyIfEndOfDay() on each gamePRefab
        //    isTimeForSpawning = true;

        //    if (isTimeForSpawning)
        //    {
        //        isTimeForSpawning = false;
        //        StartSpawningWithIntervals();  //sits in BaseSpawner
        //    }
        //}
  //  }

    //public override void CreateRandomStartTime()
    //{
    //    // Debug.Log(gameObject.name + " CreateRandomStartTime. _startDelay: "+ _startDelay);

    //    if (timeController.IsDay())
    //    {

    //        _startDelay = Random.Range(1, 5);
    //        Mathf.Clamp(_startDelay, 1, 5);
    //        Debug.Log("IsDay() - Set to often. _startDelay: " + _startDelay);
    //    }

    //    //mid
    //    if (timeController.IsLateMorning() || timeController.IsEarlyEvening())
    //    {

    //        _startDelay = Random.Range(1, 3);
    //        Mathf.Clamp(_startDelay, 1, 3); //10, 20);
    //        Debug.Log("IsLateMorning()  or IsEarlyEvening() -Set to often. _startDelay: " + _startDelay);
    //    }


    //    //rare
    //    if (timeController.IsEarlyMorning() || timeController.IsLateEvening())
    //    {

    //        _startDelay = Random.Range(30, 70);
    //        Mathf.Clamp(_startDelay, 30, 70);
    //        Debug.Log("IsEarlyMorning()  or  IsLateEvening()- Set to rare. _startDelay: " + _startDelay);
    //    }


    //}



    //public override void CreateTimeIntervalBetweenSpawning()
    //{
    //    //often:
    //    if (timeController.IsDay())
    //    {

    //        _spawnInterval = Random.Range(1, 5);
    //        Mathf.Clamp(_spawnInterval, 1, 5);
    //        Debug.Log("IsDay() - Set to often. _spawnInterval: " + _spawnInterval);
    //    }

    //    //mid
    //    if (timeController.IsLateMorning() || timeController.IsEarlyEvening())
    //    {

    //        _spawnInterval = Random.Range(1, 3);
    //        Mathf.Clamp(_spawnInterval, 1, 3); //10, 20);
    //        Debug.Log("IsLateMorning()  or IsEarlyEvening() -Set to often. _spawnInterval: " + _spawnInterval);
    //    }


    //    //rare
    //    if (timeController.IsEarlyMorning() || timeController.IsLateEvening())
    //    {

    //        _spawnInterval = Random.Range(30, 70);
    //        Mathf.Clamp(_spawnInterval, 30, 70);
    //        Debug.Log("IsEarlyMorning()  or  IsLateEvening()- Set to rare. _spawnInterval: " + _spawnInterval);
    //    }


    //}

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
