using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class DogsPackGarbageSpawner : GarbageSpawner
{

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolGarbageDogsList;
    }


    //public override void Spawn()
    //{
    //    base.Spawn();
    //    Debug.Log("Current Rating: " + Cleanliness.Instance.GetCleanRatingPoints());
    //    Cleanliness.Instance.DecreaseCleanRatingPointsPoints(Cleanliness.Points);
    //    Debug.Log("Decreased. Current Rating: " + Cleanliness.Instance.GetCleanRatingPoints());
    //    Debug.Log("Dog spawned");
    //}

    //public override void Spawn() 
    //{
    //    Vector3 pos = transform.position;
    //    index = Random.Range(0, Instance.poolGarbageDogsList.Count);
    //    Pool pool = Instance.poolGarbageDogsList[index];

    //    ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(pool, pos);
    //    CreateTimeIntervalBetweenSpawning();
    //}
}
