using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class GarbageSpawner : BaseSpawner
{
    protected override float StartDelayMin { get { return 3f; ; } }

   // protected override float StartDelay { get { return Random.Range(3, 10); ; } }
    protected override float StartDelayMax { get { return 15f; } }
    protected override float SpawnIntervalMin { get { return 5f; } }
    protected override float SpawnIntervalMax { get { return 30f; } }
    public GarbageSpawner() : base()
    {
        // _startDelay = 3.0f;
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
}
