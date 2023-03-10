using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class PoopSpawner : BaseSpawner
{
    protected override float StartDelayMin { get { return 3f; ; } }
    protected override float StartDelayMax { get { return 15f; } }
    public PoopSpawner() : base()
    {
        spawnIntervalMin = 5f;
        spawnIntervalMax = 40f;
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageBaseList;
    }
}
