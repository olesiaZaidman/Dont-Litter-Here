using System.Collections.Generic;
using UnityEngine;
using System;
//using System.Reflection;
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

    #region Create Object Pool
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
    #endregion

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
        if (!objPoolDictionary.ContainsKey(_pool.Tag))
        {
            Debug.LogWarning("GetObjectFromPoolDictionary: objPoolDictionary doesn't contains this Key: " + _pool.Tag);
            return null;
        }
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
        //Debug.Log("The Key: " + _spawnedObject.name);
        if (!objPoolDictionary.ContainsKey(_spawnedObject.name))
        {
            Debug.LogWarning("ReturnDeactivatedObjectToPoolDictionary: objPoolDictionary doesn't contains this Key: " + _spawnedObject.name);
            return;
        }
        objPoolDictionary[_spawnedObject.name].Enqueue(_spawnedObject);
        _spawnedObject.SetActive(false);
    }
    #endregion

    #region Reflection
    //void ReflectionAttempt()
    //{   // gives access to extra class info like list of members and methods
    //    Type type = typeof(ObjectPooler);

    //    // Debug.Break();

    //    foreach (MemberInfo prop in type.GetMembers()) //.GetProperties()
    //    {
    //        var propType = prop.GetType();

    //        // check if list
    //        var isPropTypeArrayOfPools = propType.IsAssignableFrom(typeof(Pool));

    //        //var isPropTypePoolMember = prop.Name.StartsWith("pool");
    //        //if (isPropTypePoolMember)
    //        //{
    //        //    Debug.Break();
    //        //}
    //        //if (isPropTypeArrayOfPools && !isPropTypePoolMember)
    //        //{
    //        //    Debug.LogWarning("A suspesius pool array with a name that doesn't starts with 'pool'" + propType.ToString());
    //        //}

    //        //if (isPropTypeArrayOfPools && isPropTypePoolMember)
    //        if (isPropTypeArrayOfPools)
    //        {
    //            // type gives access to extra class info like list of members and methods
    //            // we get the property itself and get the value in a given instance
    //            // then we cast because GetValue returns a very general object
    //            List<Pool> list = (List<Pool>)(type.GetProperty(prop.Name).GetValue(objectPooler));

    //            AddPoolListToDictionary(list);
    //        }
    //    }
    //  }
    #endregion
}
