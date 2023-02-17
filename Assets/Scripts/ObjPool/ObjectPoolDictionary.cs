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
        AddPoolListToDictionary(objectPooler.poolGarbageList); //        AddPoolListToDictionary(objectPooler.poolGarbageList, objPoolDictionary);
        AddPoolListToDictionary(objectPooler.poolCharactersList);
        AddPoolListToDictionary(objectPooler.poolGarbageDogsList); 
    }

    void AddPoolListToDictionary(List<Pool> _poolList)
    //(List<Pool> _poolList, Dictionary<string, Queue<GameObject>> _objPoolDictionar)
    {
        foreach (Pool pool in _poolList)
        {
            Queue<GameObject> objectPoolQueue = CreateNewQueue(pool);
            objPoolDictionary.Add(pool.prefab.name, objectPoolQueue);
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

            IPooledObject pooledObj = obj.GetComponent<IPooledObject>();
            if (pooledObj != null)
            {
                _pool.tag = pooledObj.GetObjTag();             
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

    #region Spawn
    public GameObject SpawnObjFromPoolDictionaryWithRotation(string _tag, Vector3 _position, Quaternion _rotation)
    {
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return null;
        }
        GameObject objToSpawn = GetObjectFromPoolDictionary(_tag);
        SpawnActiveObjectFromPoolDictionary(objToSpawn, _position, _rotation);
        return objToSpawn;
    }

    public GameObject SpawnObjFromPoolDictionary(string _tag, Vector3 _position)
    {
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return null;
        }
        GameObject objToSpawn = GetObjectFromPoolDictionary(_tag);
        SpawnActiveObjectFromPoolDictionary(objToSpawn, _position, GetPrefabRotation(objToSpawn));
        return objToSpawn;
    }


    public Quaternion GetPrefabRotation(GameObject _objToSpawn)
    { return _objToSpawn.transform.rotation; }

    public GameObject GetObjectFromPoolDictionary(string _tag)
    {
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return null;
        }
        //if (objPoolDictionary[_tag].Count > 0)
        //{
            GameObject objToSpawn = objPoolDictionary[_tag].Dequeue();
            return objToSpawn;
        //}
        //else // if the dictionary is empty
        //{
        //    GameObject objToSpawn = CreateNewObject();
        //    return objToSpawn;
        //}
    }

    public void SpawnActiveObjectFromPoolDictionary(GameObject _objToSpawn, Vector3 _position, Quaternion _rotation)
    {
        _objToSpawn.SetActive(true);
        _objToSpawn.transform.position = _position;
        _objToSpawn.transform.rotation = _rotation;
    }

    #endregion

    #region Return To Dictionary
    public void ReturnDeactivatedObjectToPoolDictionary(GameObject _objToSpawn, string _tag)
    //we call it on Object Disable when  gameObject.SetActive(false);   
    {
        Debug.Log("The Key: " + _tag);
        if (!objPoolDictionary.ContainsKey(_tag))
        {
            Debug.LogWarning("objPoolDictionary doesn't contains this Key: " + _tag);
            return;
        }
        objPoolDictionary[_tag].Enqueue(_objToSpawn);
        _objToSpawn.SetActive(false);
    }
    #endregion
}
