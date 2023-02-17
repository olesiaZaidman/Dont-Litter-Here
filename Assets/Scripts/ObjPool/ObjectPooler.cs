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

    [Header("Pools")]
    public List<Pool> poolGarbageBaseList;
    public List<Pool> poolGarbageAdultList;
    public List<Pool> poolCharactersList;
    public List<Pool> poolGarbageDogsList;

    //[Header("Tags")]
    //public List<string> charactersTagList;
    //public List<string> garbageTagList;
    //public List<string> garbageKidsTagList;
    //public List<string> garbageDogsTagList;

    #region Singelton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
        //garbageTagList = CreateListOfPoolTags(poolGarbageList);
        //charactersTagList = CreateListOfPoolTags(poolCharactersList);
        //garbageKidsTagList = CreateListOfPoolTags(poolGarbageKidsList);
        //garbageDogsTagList = CreateListOfPoolTags(poolGarbageDogsList);
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

    //List<string> CreateListOfPoolTags(List<Pool> _poolList)
    //{
    //    List<string> tagList = new List<string>();

    //    foreach (Pool pool in _poolList)
    //    {
    //        IPooledObject pooledObj = pool.prefab.GetComponent<IPooledObject>();

    //        if (pooledObj != null)
    //        {
    //            pooledObj.SetObjTag();
    //            tagList.Add(pooledObj.GetObjTag());
    //        }         
    //    }
    //    return tagList;
    //}
}

