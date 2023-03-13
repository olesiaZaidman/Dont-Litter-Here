using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public interface IOnceSpawner
{
    void Spawn();
    List<Pool> GetPoolPrefabList();
}
public interface IBaseSpawner  //IOnceSpawner?
{
    //   int StartDelayMin { get; set; }
    void Spawn();
    List<Pool> GetPoolPrefabList();
    void CreateTimeIntervalBetweenSpawning();
    void CreateRandomStartTime();
}


public interface ISpawnerWithRotationPosition : IBaseSpawner
{
    Quaternion GetRotation(float xRotation, float yRotation, float zRotation);
    Vector3 GetRandomSpawnPosition();
}

public interface IOnceSpawnerWithRotationPosition : IOnceSpawner //ISpawnerWithRotationPosition?
{
    Quaternion GetRotation(float xRotation, float yRotation, float zRotation);
    Vector3 GetRandomSpawnPosition();
}

public interface IOnceSpawnerWithRotationPositionDayOrNight : IOnceSpawnerWithRotationPosition //ISpawnerWithRotationPosition?
{
    void DetermineTimeOfDay();
    void SpawnSomeNumberOfItems(int _numberOfitems);
}

