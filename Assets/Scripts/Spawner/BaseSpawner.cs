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
    protected virtual float SpawnIntervalMin { get { return 1f; } } //{ get; set; }    //{ return 1f; } 
    protected virtual float SpawnIntervalMax { get { return 4f; } } //{ return 4f; } 

    void Start()
    {
        StartSettings();
        //SpawnIntervalMin = 1f;
        //SpawnIntervalMax = 4f;
    }


    public void CreateRandomStartTime()
    {
        _startDelay = Random.Range(StartDelayMin, StartDelayMax);
    }

    public virtual void CreateTimeIntervalBetweenSpawning()
    {
        _spawnInterval = Random.Range(SpawnIntervalMin, SpawnIntervalMax);
    }

 
    public virtual void StartSettings()
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();
        StartSpawningWithIntervals();
    }

    public virtual void StartSpawningWithIntervals()
    {
        InvokeRepeating("Spawn", _startDelay, _spawnInterval);
    }

    public virtual void CancelSpawning()
    {
        CancelInvoke("Spawn");
    }

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

    //public virtual float SetSpawnIntervalMin(float _value)
    //{
    //    spawnIntervalMin = Mathf.Clamp(_value, 0, 60);
    //    return spawnIntervalMin;
    //}

    //public virtual SetSpawnIntervalMax(float _value)
    //{
    //    spawnIntervalMax = Mathf.Clamp(_value, 0, 60);
    //    return spawnIntervalMax;
    //}

    //protected virtual float StartDelay
    //{
    //    get { return _startDelay; }
    //    private set
    //    {
    //        if (value <= 0)
    //        {
    //            Debug.Log("Out of range!");
    //            return;
    //        }
    //        _startDelay = Random.Range(StartDelayMin, StartDelayMax);
    //        //_startDelay = value;
    //    }
    //}
}
