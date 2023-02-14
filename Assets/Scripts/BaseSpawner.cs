using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour, IBaseSpawner
{
    public GameObject[] prefab;
    public int index;

    //  Interval & Delay:
   public float startDelay = 2.0f;
   public float spawnInterval;
   public float spawnIntervalMin = 2f;
   public float spawnIntervalMax = 4f;

    void Start()
    {
        CreateTimeIntervalBetweenSpawning();
        StartSpawningWithIntervals();
    }

    public void StartSpawningWithIntervals()
    {
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    public void CreateTimeIntervalBetweenSpawning()
    {
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    public virtual void Spawn()
    {
        Vector3 pos = transform.position;
        index = Random.Range(0, prefab.Length);
        Instantiate(prefab[index], pos, prefab[index].transform.rotation);
        CreateTimeIntervalBetweenSpawning();
    }
}
