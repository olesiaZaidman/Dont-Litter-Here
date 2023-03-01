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

    //public override void Spawn()
    //{
    //    base.Spawn();
    //    Debug.Log("Current Rating: " + Cleanliness.Instance.GetCleanRatingPoints());
    //    Cleanliness.Instance.DecreaseCleanRatingPointsPoints(Cleanliness.Points);
    //    Debug.Log("Decreased. Current Rating: " + Cleanliness.Instance.GetCleanRatingPoints());
    //    Debug.Log("Kids spawned");
    //}
}
