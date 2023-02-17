using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> poolGarbageList;
    public List<Pool> poolCharactersList;

    public List<string> charactersTagList;
    public List<string> garbageTagList;

    #region Singelton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
        garbageTagList = CreateListOfPoolTags(poolGarbageList);
        charactersTagList = CreateListOfPoolTags(poolCharactersList);
    }
    #endregion

    List<string> CreateListOfPoolTags(List<Pool> _poolList)
    {
        List<string> tagList = new List<string>();

        foreach (Pool pool in _poolList)
        {
            IPooledObject pooledObj = pool.prefab.GetComponent<IPooledObject>();

            if (pooledObj != null)
            {
                pooledObj.SetObjTag();
                tagList.Add(pooledObj.GetObjTag());
            }         
        }
        return tagList;
    }
}

