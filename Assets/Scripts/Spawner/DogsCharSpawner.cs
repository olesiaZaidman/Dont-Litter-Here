using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;
public class DogsCharSpawner : CharactersSpawner
{
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolDogsList;
    }
}
