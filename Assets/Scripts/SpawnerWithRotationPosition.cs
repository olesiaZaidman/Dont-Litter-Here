using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWithRotationPosition : BaseSpawner, ISpawnerWithRotationPosition
{

    //How to make inheritance for serialized field (not public like now)?
    //change variables in children

    [SerializeField] float xRotation = 0;
    [SerializeField] float yRotation = 90;
    [SerializeField] float zRotation = 0;

    [Header("InstancePositonVectorCoordinates")]
    [SerializeField] float xMaxRange = 19;
    [SerializeField] float xMinRange = -16f;
    [SerializeField] float yCoordinate = 0f;
    [SerializeField] float zMaxRange = 4;
    [SerializeField] float zMinRange = -14;


    public override void Spawn()
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
