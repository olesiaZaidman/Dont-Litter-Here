using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour, ISpawner
{
    public GameObject[] prefab;
    int index;

    //  Interval & Delay:
    [SerializeField] float startDelay = 2.0f;
    float spawnInterval;
    [SerializeField] float spawnIntervalMin = 2f;
    [SerializeField] float spawnIntervalMax = 4f;

    void Start()
    {
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    public void Spawn()
    {
        Vector3 pos = transform.position;
        index = Random.Range(0, prefab.Length);
        Instantiate(prefab[index], pos, prefab[index].transform.rotation);
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    public Quaternion GetRotation(float _xRotation, float _yRotation, float _zRotation)
    {
        return transform.rotation;
    }


    public Vector3 GetRandomSpawnPosition()
    {
        return transform.position;
    }
}
