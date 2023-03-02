using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class CharactersSpawner : SpawnerWithRotationPosition
{
    protected override float StartDelayMin { get { return 1f; } }
    protected override float StartDelayMax { get { return 10f; } }
    protected override float SpawnIntervalMin { get { return 5f; } }
    protected override float SpawnIntervalMax { get { return 30; } }

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

    private void Update()
    {
        if (timeController.IsEndOfWorkingDay())
        {
            CancelSpawning();
            isTimeForSpawning = true;
        }
        if (timeController.IsMorning())
        {
            if (isTimeForSpawning)
            {
                isTimeForSpawning = false;
                StartSpawningWithIntervals();
            }
        }
    }
    public override void StartSettings()
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();
    }

    public override void StartSpawningWithIntervals()
    {
        base.StartSpawningWithIntervals();
        Debug.Log("CharactersSpawner: StartSpawningWithIntervals");

    }

    public override void CancelSpawning()
    {
        base.CancelSpawning();
        Debug.Log("CharactersSpawner: CancelSpawning");
    }





}
