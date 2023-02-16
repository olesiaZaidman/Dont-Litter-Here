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

    #region Singelton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

}

//public class Pool 
//{
//    public string tag;
//    public GameObject prefab;
//    public int size;
//}
