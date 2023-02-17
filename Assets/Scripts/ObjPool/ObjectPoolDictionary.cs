using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class ObjectPoolDictionary : MonoBehaviour
{
    ObjectPooler objectPooler;
    public Dictionary<string, Queue<GameObject>> objPoolDictionary;

    #region Singelton
    public static ObjectPoolDictionary Instance;

    private void Awake()
    {
        Instance = this;
        objectPooler = ObjectPooler.Instance;
    }
    #endregion

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        objPoolDictionary = new Dictionary<string, Queue<GameObject>>();

    AddPoolListToDictionary(objectPooler.poolGarbageBaseList);
    AddPoolListToDictionary(objectPooler.poolGarbageAdultList);
    AddPoolListToDictionary(objectPooler.poolCharactersList);
    AddPoolListToDictionary(objectPooler.poolGarbageDogsList);
    AddPoolListToDictionary(objectPooler.poolDogsList);
    AddPoolListToDictionary(objectPooler.poolBirdsList);

    }

    void AddPoolListToDictionary(List<Pool> _poolList)
    {
        foreach (Pool pool in _poolList)
        {
            Queue<GameObject> objectPoolQueue = CreateNewQueue(pool);
            objPoolDictionary.Add(pool.Tag, objectPoolQueue);
        }
    }

    Queue<GameObject> CreateNewQueue(Pool _pool)
    {
        Queue<GameObject> objectPoolQueue = new Queue<GameObject>();
        CreatePoolOfDeactivatedObjects(_pool, objectPoolQueue);
        return objectPoolQueue;
    }

    void CreatePoolOfDeactivatedObjects(Pool _pool, Queue<GameObject> _objectPoolQueue)
    {
        for (int i = 0; i < _pool.size; i++)
        {
            GameObject obj = CreateNewObject(_pool);
            obj.SetActive(false);
            _objectPoolQueue.Enqueue(obj);
        }
    }

    private GameObject CreateNewObject(Pool _pool)
    {
        GameObject newObj = Instantiate(_pool.prefab);
        newObj.name = _pool.prefab.name;
        return newObj;
    }

    #region Spawn
    public GameObject SpawnObjFromPoolDictionaryWithRotation(Pool _pool, Vector3 _position, Quaternion _rotation)
    {
        //if (!objPoolDictionary.ContainsKey(_tag))
        //{
        //    Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
        //    return null;
        //}
        GameObject objToSpawn = GetObjectFromPoolDictionary(_pool); //_pool.Tag
        SpawnActiveObjectFromPoolDictionary(objToSpawn, _position, _rotation);
        return objToSpawn;
    }

    public GameObject SpawnObjFromPoolDictionary(Pool _pool, Vector3 _position)
    {
    //    if (!objPoolDictionary.ContainsKey(_tag))
    //    {
    //        Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
    //        return null;
    //    }
        GameObject objToSpawn = GetObjectFromPoolDictionary(_pool);
        SpawnActiveObjectFromPoolDictionary(objToSpawn, _position, GetPrefabRotation(objToSpawn));
        return objToSpawn;
    }


    public Quaternion GetPrefabRotation(GameObject _objToSpawn)
    { 
    return _objToSpawn.transform.rotation; 
}

    public GameObject GetObjectFromPoolDictionary(Pool _pool)
    {
        //if (!objPoolDictionary.ContainsKey(_tag))
        //{
        //    Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
        //    return null;
        //}
        if (objPoolDictionary[_pool.Tag].Count > 0)
        {
            GameObject objToSpawn = objPoolDictionary[_pool.Tag].Dequeue();
            return objToSpawn;
        }
        else // if the dictionary is empty
        {
            GameObject objToSpawn = CreateNewObject(_pool);
           return objToSpawn;
        }
    }

    public void SpawnActiveObjectFromPoolDictionary(GameObject _objToSpawn, Vector3 _position, Quaternion _rotation)
    {
        _objToSpawn.SetActive(true);
        _objToSpawn.transform.position = _position;
        _objToSpawn.transform.rotation = _rotation;
    }

    #endregion

    #region Return To Dictionary
    public void ReturnDeactivatedObjectToPoolDictionary(GameObject _spawnedObject)
    //we call it on Object Disable when  gameObject.SetActive(false);   
    {
        Debug.Log("The Key: " + _spawnedObject.name);
        if (!objPoolDictionary.ContainsKey(_spawnedObject.name))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _spawnedObject.name);
            return;
        }
        objPoolDictionary[_spawnedObject.name].Enqueue(_spawnedObject);
        _spawnedObject.SetActive(false);
    }
    #endregion
}
