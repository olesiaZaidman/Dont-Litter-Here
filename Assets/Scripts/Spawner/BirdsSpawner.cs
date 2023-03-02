using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;
public class BirdsSpawner : SpawnerWithRotationPosition
//WaterSpawner
{
    public BirdsSpawner() : base()
    {
         yCoordinate = 4.3f;
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolBirdsList;
    }
}
