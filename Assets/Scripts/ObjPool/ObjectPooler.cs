using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag { get { return prefab.name; } }
        public GameObject prefab;
        public int size;
    }

    [Header("Pools Garbage")]
    public List<Pool> poolGarbageBaseList;
    public List<Pool> poolGarbageAdultList;
    public List<Pool> poolGarbageDogsList;

    [Header("Pools Characters")]
    public List<Pool> poolCharactersList;
    public List<Pool> poolDogsList;
    public List<Pool> poolBirdsList;

    [Header("Props")]
    public List<Pool> poolWaterList;
    public List<Pool> poolLootList;
    #region Singelton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;

        //aaa = new List<List<Pool>> { poolGarbageBaseList, poolGarbageAdultList };
    }
    #endregion

    public List<Pool> JoinLists(List<Pool> a, List<Pool> b)
    {
        List<Pool> combinedList = new List<Pool>();
        combinedList.AddRange(a);
        combinedList.AddRange(b);
        return combinedList;
        // return a.Concat(b);
    }
}

