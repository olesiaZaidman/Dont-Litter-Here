using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class CharactersSpawner : SpawnerWithRotationPosition
{
    protected override float StartDelayMin { get { return 1f; } }
    protected override float StartDelayMax { get { return 10f; } }
    protected override float SpawnIntervalMin { get { return 2f; } }
    protected override float SpawnIntervalMax { get { return 15; } }

    public CharactersSpawner() : base()
    {
       // yCoordinate = transform.position;
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolCharactersList;

        //List<Pool> combinedList = new List<Pool>();
        //combinedList.AddRange(Instance.poolCharactersList);
        //combinedList.AddRange(Instance.poolBirdsList);
        //return combinedList;
    }


}
