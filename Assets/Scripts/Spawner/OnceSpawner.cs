using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;
public class OnceSpawner : MonoBehaviour, IOnceSpawner
{
    protected int index;

    #region Spawn & Pool
    public virtual List<Pool> GetPoolPrefabList()
    {
        return null; // new List<Pool>();
    }

    public virtual void Spawn()
    {
        Vector3 pos = transform.position;
        List<Pool> list = GetPoolPrefabList();
        index = Random.Range(0, list.Count);
        Pool pool = list[index];
        ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(pool, pos);
    }

    #endregion

}
