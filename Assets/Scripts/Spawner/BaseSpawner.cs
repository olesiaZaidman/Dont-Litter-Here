using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class BaseSpawner : MonoBehaviour, IBaseSpawner
{
    protected int index;
    ScoreManager scoreManager;
  //  UIManager uiManager;
    CleanIndicatorUI cleanIndicator;

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
       scoreManager = FindObjectOfType<ScoreManager>();//ScoreManager.Instance;
    //    uiManager = FindObjectOfType<UIManager>();
        cleanIndicator = FindObjectOfType<CleanIndicatorUI>();
    }

    public void StartSpawningWithIntervals()
    {
        InvokeRepeating("Spawn", _startDelay, _spawnInterval);
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
      //  cleanIndicator.DecreaseFill();

      //  scoreManager.IncreaseCleanRatingPoints(1);
      //  uiManager.SetScoreTextUI();
        CreateTimeIntervalBetweenSpawning();
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
