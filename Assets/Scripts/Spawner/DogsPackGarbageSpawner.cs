using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsPackGarbageSpawner : GarbageSpawner
{
    public override void Spawn() // Spawn(List<string> tagList)
    {
        Vector3 pos = transform.position;
        index = Random.Range(0, ObjectPooler.Instance.garbageDogsTagList.Count);
        string tag = ObjectPooler.Instance.garbageDogsTagList[index];

        ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(tag, pos);
        CreateTimeIntervalBetweenSpawning();
    }
}
