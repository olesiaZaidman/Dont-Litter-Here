using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class KidsPackGarbageSpawner : GarbageSpawner
{
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageBaseList;
    }

 
}
