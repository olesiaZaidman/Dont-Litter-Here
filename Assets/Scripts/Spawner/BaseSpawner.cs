using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour, IBaseSpawner
{
    public GameObject[] prefab;
    //   [HideInInspector]
    protected int index;

    //  Interval & Delay:
    [Header("StartTimeDelay")]
    [SerializeField] protected float _startDelay; // = 2.0f
    [Header("SpawnInterval")]
    [SerializeField] protected float _spawnInterval;

    protected virtual float StartDelayMin { get { return 0.5f; } }
    // [SerializeField] protected float _startDelayMin; // = 2.0f
    protected virtual float StartDelayMax { get { return 10f; } }
    // [SerializeField] protected float _startDelayMax; // = 2.0f
    protected virtual float SpawnIntervalMin { get { return 1f; } }    
    //  [SerializeField] protected float _spawnIntervalMin; // = 2f
    protected virtual float SpawnIntervalMax { get { return 4f; } }
    //  [SerializeField] protected float _spawnIntervalMax; // = 4f

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
    //protected virtual float SpawnInterval
    //{
    //    get { return _spawnInterval; }
    //    private set
    //    {
    //        if (value <= 0)
    //        {
    //            Debug.Log("Out of range!");
    //            return;
    //        }
    //        _spawnInterval = Random.Range(SpawnIntervalMin, SpawnIntervalMax);
    //        //_spawnInterval = value;
    //    }
    //}
    public void CreateRandomStartTime()
    {
        _startDelay = Random.Range(StartDelayMin, StartDelayMax);
    }

    public void CreateTimeIntervalBetweenSpawning()
    {
        _spawnInterval = Random.Range(SpawnIntervalMin, SpawnIntervalMax);
    }

    void Start()
    {
        CreateRandomStartTime();
        CreateTimeIntervalBetweenSpawning();
        StartSpawningWithIntervals();
    }

    public void StartSpawningWithIntervals()
    {
       // InvokeRepeating("Spawn", StartDelay, SpawnInterval);
        InvokeRepeating("Spawn", _startDelay, _spawnInterval);
    }

    public virtual void Spawn()
    {
        Vector3 pos = transform.position;
        index = Random.Range(0, prefab.Length);
        Instantiate(prefab[index], pos, prefab[index].transform.rotation);
        CreateTimeIntervalBetweenSpawning();
    }
}
