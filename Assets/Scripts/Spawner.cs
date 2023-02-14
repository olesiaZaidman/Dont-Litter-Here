using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ISpawner
{
    public GameObject[] prefab;
    int index;
    [SerializeField] float xRotation = 0;
    [SerializeField] float yRotation = 90;
    [SerializeField] float zRotation = 0;

    [Header("InstancePositonVectorCoordinates")]
    [SerializeField] float xMaxRange = 16;
    [SerializeField] float xMinRange = -16f;
    [SerializeField] float yCoordinate = 22f;
    [SerializeField] float zMaxRange = 20;
    [SerializeField] float zMinRange = 0;


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

    
    void Update()
    {
        
    }

    public void Spawn()
    {
        Quaternion prefabRotation = GetRotation(xRotation, yRotation, zRotation);
        Vector3 pos = GetRandomSpawnPosition();
        index = Random.Range(0, prefab.Length);
        Instantiate(prefab[index], pos, prefabRotation);
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    public Quaternion GetRotation(float _xRotation, float _yRotation, float _zRotation)
    {
        Quaternion _prefabRotation = Quaternion.Euler(_xRotation, _yRotation, _zRotation);
        return _prefabRotation;
    }


    public Vector3 GetRandomSpawnPosition()
    {
        Vector3 _position = new Vector3(Random.Range(xMinRange, xMaxRange), yCoordinate, Random.Range(zMinRange, zMaxRange));
        return _position;
    }
}
