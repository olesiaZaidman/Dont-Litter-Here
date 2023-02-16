using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
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
    public Dictionary<string, Queue<GameObject>> objPoolDictionary;

    #region Singelton
    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    void Start()
    {
        objPoolDictionary = new Dictionary<string, Queue<GameObject>>();
        AddPoolListToDictionary(poolGarbageList, objPoolDictionary);
        AddPoolListToDictionary(poolCharactersList, objPoolDictionary);

        //CreateNewDictionaryWithQueuesOfPoolList();
    }

    //USED TO BE:
    //void CreateNewDictionaryWithQueuesOfPoolList()
    //{
    //    objPoolDictionary = new Dictionary<string, Queue<GameObject>>();

    //    foreach (Pool pool in poolGarbageList)
    //    {
    //        Queue<GameObject> objectPoolQueue = new Queue<GameObject>();

    //        for (int i = 0; i < pool.size; i++)
    //        {
    //            GameObject obj = CreateNewObject(pool);
    //            obj.SetActive(false);
    //            objectPoolQueue.Enqueue(obj);
    //        }
    //        objPoolDictionary.Add(pool.tag, objectPoolQueue);
    //    }
  //  }

    void AddPoolListToDictionary(List<Pool> _poolList, Dictionary<string, Queue<GameObject>> _objPoolDictionar)
    {
        foreach (Pool pool in _poolList)
        {
            Queue<GameObject> objectPoolQueue = CreateNewQueueForPool(pool);
            _objPoolDictionar.Add(pool.tag, objectPoolQueue);
        }
    }

    Queue<GameObject> CreateNewQueueForPool(Pool _pool)
    {
        Queue<GameObject> objectPoolQueue = new Queue<GameObject>();
        EnqueueDeactivatedObjectsFromPool(_pool, objectPoolQueue);
        return objectPoolQueue;
    }

    void EnqueueDeactivatedObjectsFromPool(Pool _pool, Queue<GameObject> _objectPoolQueue)
    {
        for (int i = 0; i < _pool.size; i++)
        {
            GameObject obj = CreateNewObject(_pool);

            IPooledObject pooledObj = obj.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                _pool.tag = pooledObj.GetObjTag();
              //  _pool.tag = pooledObj.ObjTag; //we take it fromn the prefab itself
            }

            obj.SetActive(false);
            _objectPoolQueue.Enqueue(obj);
        }
    }

    private GameObject CreateNewObject(Pool _pool)
    {
        GameObject newObj = Instantiate(_pool.prefab);
        // obj.name = pool.prefab.name;
        // we are naming same as the incoming prefab - its important for key-search we can use it this way
        return newObj;
    }

    public GameObject SpawnObjFromPoolWithRotation(string _tag, Vector3 _position, Quaternion _rotation)
    {
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return null;
        }
        GameObject objToSpawn = GetObjectFromPool(_tag);
        SpawnActiveObjectFromPool(objToSpawn, _position, _rotation);
      //  ReturnObjectToPool(objToSpawn, _tag); //When should we return?

        return objToSpawn;
    }

    public GameObject SpawnObjFromPool(string _tag, Vector3 _position)
    {
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return null;
        }
        GameObject objToSpawn = GetObjectFromPool(_tag);
        SpawnActiveObjectFromPool(objToSpawn, _position, GetPrefabRotation(objToSpawn));
        //OR JUST
        //SpawnFromPoolPositionInWorld(objToSpawn, _position);
        //and remove rotation from SpawnFromPoolPositionInWorld

    //    ReturnObjectToPool(objToSpawn, _tag); //When should we return it back? now the object return onDisable

        return objToSpawn;
    }

    public Quaternion GetPrefabRotation(GameObject _objToSpawn)
    { return _objToSpawn.transform.rotation; }

    public GameObject GetObjectFromPool(string _tag)
    {
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return null;
        }
        else if (objPoolDictionary[_tag].Count == 0)
        { }
        GameObject objToSpawn = objPoolDictionary[_tag].Dequeue();
        return objToSpawn;
    }

    public void SpawnActiveObjectFromPool(GameObject _objToSpawn, Vector3 _position, Quaternion _rotation)
    {
        _objToSpawn.SetActive(true);
        _objToSpawn.transform.position = _position;
        _objToSpawn.transform.rotation = _rotation;
    }

    public void ReturnDeactivatedObjectToPool(GameObject _objToSpawn, string _tag) 
        //we call it on Object Disable
    {
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return;
        }
        objPoolDictionary[_tag].Enqueue(_objToSpawn);
        _objToSpawn.SetActive(false);
    }

    //public void SpawnFromPool(string _tag, Vector3 _position, Quaternion _rotation)
    //{
    //    if (!objPoolDictionary.ContainsKey(_tag))
    //    {
    //        Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
    //        return;
    //    }

    //    GameObject objToSpawn = GetObjectFromPool(_tag);
    //    SpawnFromPoolPositionInWorld(objToSpawn, _position, _rotation);
    //    ReturnObjectToPool(objToSpawn, _tag); //When should we return?
    //}

    //public GameObject TakeFromPoolSpawnReturnToPool(string _tag, Vector3 _position, Quaternion _rotation)
    //{
    //    GameObject objToSpawn = objPoolDictionary[_tag].Dequeue();
    //    objToSpawn.SetActive(true);
    //    objToSpawn.transform.position = _position;
    //    objToSpawn.transform.rotation = _rotation;
    //    objPoolDictionary[_tag].Enqueue(objToSpawn);
    //    return objToSpawn;
    //}
}
