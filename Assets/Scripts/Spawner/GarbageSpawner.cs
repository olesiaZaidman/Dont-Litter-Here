using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class GarbageSpawner : BaseSpawner
{
    protected override float StartDelayMin { get { return 3f; ; } }

   // protected override float StartDelay { get { return Random.Range(3, 10); ; } }
    protected override float StartDelayMax { get { return 15f; } }
    //protected override float SpawnIntervalMin { get { return 5f; } }
    //protected override float SpawnIntervalMax { get { return 30f; } }
    protected float spawnIntervalMin = 5f;
    protected float spawnIntervalMax = 30f;

   // MoveForwardWithAnimationController moveController;

    public GarbageSpawner() : base()
    {
        // _startDelay = 3.0f;
    }

    private void Start()
    {
       // moveController = GetComponent<MoveForwardWithAnimationController>();
    }
    private void Update()
    {
        IncreaseOrDecreseSpawningTime();
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageBaseList;
    }

    public override void Spawn()
    {
        base.Spawn();
      //  Cleanliness.Instance.RecalculateCleanRatingPoints();       // Cleanliness.Instance.DecreaseCleanRatingPoints(Cleanliness.Points);
    }

    private void IncreaseOrDecreseSpawningTime()
    {
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
    }


    public override void CreateTimeIntervalBetweenSpawning()
    {

        _spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
      //  Debug.Log("New Interval. Min: " + spawnIntervalMin + " Max: " + spawnIntervalMax);
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
}
