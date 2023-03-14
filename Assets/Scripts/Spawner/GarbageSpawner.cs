using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class GarbageSpawner : SpawnWithOffset
{
    //Events for state machine - time of the day or action state
    //OBSERVER PATTERN with Events {TELL DONT ASK}
  
    protected override float StartDelayMin { get { return 1f; ; } }
    protected override float StartDelayMax { get { return 15f; } }

    TimeController timeController;
  //  LitterRate lR;

    [SerializeField] bool isWalking;
   // [SerializeField] bool isRestartSpawning = false;
    #region Constructor
    public GarbageSpawner() : base()
    {
        spawnIntervalMin = 3f;
        spawnIntervalMax = 40f;
    }
    #endregion

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
      //  Debug.Log("GarbageSpawner sits on people- Spawner Awake");
        //  lR = GetComponent<LitterRate>();
    }

    void Update()
    {
        if (timeController.IsEndOfWorkingDay())
        {           
            CancelSpawning();  /*sits in BaseSpawner*/
        }
    }

    #region Pool //& Spawn
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageBaseList;
    }

    #endregion
}
