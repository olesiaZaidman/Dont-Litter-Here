using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsPackGarbageSpawner : GarbageSpawner
{
    //DogsPackGarbageSpawner
    public override void Spawn() // Spawn(List<string> tagList)
    {
        Vector3 pos = transform.position;
        index = Random.Range(0, ObjectPooler.Instance.garbageKidsTagList.Count);
        string tag = ObjectPooler.Instance.garbageKidsTagList[index];

        ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(tag, pos);
        CreateTimeIntervalBetweenSpawning();
    }
}
