using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class DogsPackGarbageSpawner : PoopSpawner
{
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageDogsList;
    }

}
