using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
     void Spawn();

      Quaternion GetRotation(float xRotation, float yRotation, float zRotation);
      Vector3 GetRandomSpawnPosition();
}


