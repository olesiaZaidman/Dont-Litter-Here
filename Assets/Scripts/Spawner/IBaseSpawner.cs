using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public interface IBaseSpawner
{
 //   int StartDelayMin { get; set; }
    void Spawn();
    void CreateTimeIntervalBetweenSpawning();
    void CreateRandomStartTime();
    List<Pool> GetPoolPrefabList();
}

public interface ISpawnerWithRotationPosition : IBaseSpawner
{
    Quaternion GetRotation(float xRotation, float yRotation, float zRotation);
    Vector3 GetRandomSpawnPosition();
}

