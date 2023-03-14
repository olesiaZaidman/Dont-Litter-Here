using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class BaseSpawner : MonoBehaviour, IBaseSpawner
{

    protected int index;

    //  Interval & Delay:
    [Header("StartTimeDelay")]
    [SerializeField] protected float _startDelay; // = 2.0f
    [Header("SpawnInterval")]
    [SerializeField] protected float _spawnInterval;

    protected virtual float StartDelayMin { get { return 0.5f; } }
    protected virtual float StartDelayMax { get { return 10f; } }


    protected float spawnIntervalMin = 1f;
    protected float spawnIntervalMax = 10f;

    void OnEnable()
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();
        StartSpawningWithIntervals();
    }

    void OnDisable()
    {
        CancelSpawning();
    }

    #region Start Functions  //Includ InvokeRepeating
 

    public virtual void CreateRandomStartTime()
    {
        _startDelay = Random.Range(StartDelayMin, StartDelayMax);
    }

    public virtual void CreateTimeIntervalBetweenSpawning()      
        //_spawnInterval = lR.GetLitterRate(); ????
    {
        _spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Mathf.Clamp(_spawnInterval, spawnIntervalMin, spawnIntervalMax);
    }


    public virtual void StartSpawningWithIntervals()
    {
        InvokeRepeating("Spawn", _startDelay, _spawnInterval);
    }

    #endregion 

    #region Supposed for Update Functions //CancelInvoke

    public virtual void CancelSpawning()
    {
        CancelInvoke("Spawn");
    }

    #endregion

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
        CreateTimeIntervalBetweenSpawning();
    }
  
    #endregion

}
