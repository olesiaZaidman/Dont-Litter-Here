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
    // [SerializeField] protected float _startDelayMin; // = 2.0f
    protected virtual float StartDelayMax { get { return 10f; } }
    //protected virtual float SpawnIntervalMin { get { return 1f; } } //{ get; set; }    //{ return 1f; } 
    //protected virtual float SpawnIntervalMax { get { return 4f; } } //{ return 4f; } 

    protected float spawnIntervalMin = 1f;
    protected float spawnIntervalMax = 4f;


    void Start()
    {
        StartSettings();
        //SpawnIntervalMin = 1f;
        //SpawnIntervalMax = 4f;
    }
    #region Start Functions  //Includ InvokeRepeating
    public virtual void StartSettings()
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();
        StartSpawningWithIntervals(); // //= InvokeRepeating
    }

    public void CreateRandomStartTime()
    {
        _startDelay = Random.Range(StartDelayMin, StartDelayMax);
    }

    public virtual void CreateTimeIntervalBetweenSpawning()
    {
        // _spawnInterval = Random.Range(SpawnIntervalMin, SpawnIntervalMax);
        _spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    public virtual void StartSpawningWithIntervals()
    {
        InvokeRepeating("Spawn", _startDelay, _spawnInterval);
    }

    #endregion 

    #region Supposed for Update Functions //CancelInvoke
    //IN START:
    //public virtual void StartSpawningWithIntervals()
    //{
    //    InvokeRepeating("Spawn", _startDelay, _spawnInterval);
    //}

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

    #region SpawnInterval
    public virtual float SetSpawnIntervalMin(float _value)
    {
        spawnIntervalMin = Mathf.Clamp(_value, 0, 60);
        return spawnIntervalMin;
    }

    public virtual float SetSpawnIntervalMax(float _value)
    {
        spawnIntervalMax = Mathf.Clamp(_value, 0, 60);
        return spawnIntervalMax;
    }

    #endregion

}
