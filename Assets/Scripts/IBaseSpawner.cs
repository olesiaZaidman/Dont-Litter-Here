using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseSpawner
{
      void Spawn();
      void CreateTimeIntervalBetweenSpawning();
}

public interface ISpawnerWithRotationPosition : IBaseSpawner
{
    Quaternion GetRotation(float xRotation, float yRotation, float zRotation);
    Vector3 GetRandomSpawnPosition();
}

