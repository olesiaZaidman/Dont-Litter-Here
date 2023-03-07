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
    protected Vector3 spawnOffsetPos;

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
        spawnOffsetPos = SetRandomspawnOffsetPos();
        List<Pool> list = GetPoolPrefabList();
        index = Random.Range(0, list.Count);
        Pool pool = list[index];
        ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(pool, pos+spawnOffsetPos);
        CreateTimeIntervalBetweenSpawning();
    }

    private Vector3 SetRandomspawnOffsetPos()
    {
        float xPositive = Random.Range(0.4f,1f);
        float xNegative = Random.Range(-0.5f, -1f);
        float y = -0.1f;
        float zPositive = Random.Range(0.8f, 1.3f);  
        float zNegative = Random.Range(-1.1f, -1.5f);
        
        int random = Random.Range(0,4);

        if (random == 0)
        {
            return new Vector3(xPositive, y, zPositive);
        }

        else if (random == 1)
        {
            return new Vector3(xNegative, y, zPositive);
        }

        else if (random == 2)
        {
            return new Vector3(xPositive, y, zNegative);
        }
        else 
        {
            return new Vector3(xNegative, y, zNegative);
        }
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
