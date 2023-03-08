using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;
public class BirdsSpawner : SpawnerWithRotationPosition
{
    public BirdsSpawner() : base()
    {
         yCoordinate = 4.3f;
        spawnIntervalMin = 10f;
        spawnIntervalMax = 30f;
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolBirdsList;
    }
}
