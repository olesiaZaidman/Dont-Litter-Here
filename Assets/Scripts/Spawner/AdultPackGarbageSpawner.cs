using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class AdultPackGarbageSpawner : GarbageSpawner
{
    #region Pool
    public override List<Pool> GetPoolPrefabList()
    {
      //  return Instance.JoinLists(Instance.poolGarbageAdultList, Instance.poolGarbageBaseList);
        List<Pool> combinedList = new List<Pool>();
        combinedList.AddRange(Instance.poolGarbageAdultList);
        combinedList.AddRange(Instance.poolGarbageBaseList);
        return combinedList;
    }

    #endregion


    //public override void Spawn() 
    //{   //    base.Spawn();
    //    Vector3 pos = transform.position;
    //    index = Random.Range(0, Instance.poolGarbageDogsList.Count);
    //    Pool pool = Instance.poolGarbageDogsList[index];

    //    ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(pool, pos);
    //    CreateTimeIntervalBetweenSpawning();
    //}

}
