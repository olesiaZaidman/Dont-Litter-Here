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
        spawnIntervalMin = 10f;
        spawnIntervalMax = 60f;
    }
    #endregion
    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        //Debug.Log("Charcters Spawner Awake");
    }

    private void Update()
    {
        StopOrRestartSpawningIfNeeded();
    }


    //public override void CreateTimeIntervalBetweenSpawning()
    ////_spawnInterval = lR.GetLitterRate(); ????
    //{
    //    base.CreateTimeIntervalBetweenSpawning();
    //   // Debug.Log(gameObject.name + "_spawnInterval: " + _spawnInterval);
    //}

    public override void CreateTimeIntervalBetweenSpawning()
    {
        float modifier = 1;
        modifier += ScoreManager.Instance.GetDays();
        float _spawnIntervalMin = (float)spawnIntervalMin / modifier;
        float _spawnIntervalMax = (float)spawnIntervalMax / modifier;
        _spawnInterval = Random.Range(_spawnIntervalMin, (int)_spawnIntervalMax);
        Mathf.Clamp(_spawnInterval, _spawnIntervalMin, spawnIntervalMax);
    }



    #region Pool
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolCharactersList;
    }
    #endregion

    #region Update Functions //InvokeRepeating & CancelInvoke  sit in BaseSpawner


    private void StopOrRestartSpawningIfNeeded()
    {
        if (timeController.IsEndOfWorkingDay())
        {
            CancelSpawning(); /*sits in BaseSpawner 
                               * + DestroyIfEndOfDay() on each gamePRefab*/
            isTimeForSpawning = true;
        }

        if (timeController.IsEarlyMorning())
        {
            if (isTimeForSpawning)
            {
                isTimeForSpawning = false;
                StartSpawningWithIntervals();  /*sits in BaseSpawner*/
            }
        }
    }
    #endregion
}
