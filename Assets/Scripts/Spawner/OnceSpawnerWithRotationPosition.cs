using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;
public class OnceSpawnerWithRotationPosition : OnceSpawner, IOnceSpawnerWithRotationPosition
{
    //SpawnWithOffset
    [Header("Rotation")]
    [SerializeField] protected float xRotation = 0;
    [SerializeField] protected float yRotation = 0;
    [SerializeField] protected float zRotation = 0;

    [Header("InstancePositonVectorCoordinates")]
    [SerializeField] protected float xMaxRange = 11;
    [SerializeField] protected float xMinRange = -11f;
    [SerializeField] protected float yCoordinate = 0f;
    [SerializeField] protected float zMaxRange = 4;
    [SerializeField] protected float zMinRange = -14;


    public override void Spawn()
    {
        Quaternion prefabRotation = GetRotation(xRotation, yRotation, zRotation);
        Vector3 pos = GetRandomSpawnPosition();

        List<Pool> list = GetPoolPrefabList();
        index = Random.Range(0, list.Count);
        Pool pool = list[index];

        ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionaryWithRotation(pool, pos, prefabRotation);
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
