using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour, IBaseSpawner
{
   // public GameObject[] prefab;
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
    protected virtual float SpawnIntervalMin { get { return 1f; } }    
    protected virtual float SpawnIntervalMax { get { return 4f; } }


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
        InvokeRepeating("Spawn", _startDelay, _spawnInterval);
    }

    public virtual void Spawn() // Spawn(List<string> tagList)
    {
        Vector3 pos = transform.position;
        index = Random.Range(0, ObjectPooler.Instance.garbageTagList.Count);
        string tag = ObjectPooler.Instance.garbageTagList[index];

        ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(tag, pos);
        CreateTimeIntervalBetweenSpawning();

        //USED TO BE:
        //  index = Random.Range(0, prefab.Length);
        //   Instantiate(prefab[index], pos, prefab[index].transform.rotation);
    }



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
