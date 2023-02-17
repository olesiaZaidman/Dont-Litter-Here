using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class GarbageSpawner : BaseSpawner
{
    protected override float StartDelayMin { get { return 3f; } }
    protected override float StartDelayMax { get { return 10f; } }
    protected override float SpawnIntervalMin { get { return 2f; } }
    protected override float SpawnIntervalMax { get { return 10f; } }
    public GarbageSpawner() : base()
    {
        // _startDelay = 3.0f;
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageBaseList;
    }
}
