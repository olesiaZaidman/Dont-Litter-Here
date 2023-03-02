using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class CharactersSpawner : SpawnerWithRotationPosition
{
    protected override float StartDelayMin { get { return 1f; } }
    protected override float StartDelayMax { get { return 10f; } }
    protected override float SpawnIntervalMin { get { return 5f; } }
    protected override float SpawnIntervalMax { get { return 30; } }
   // TimeController timeController;
    public CharactersSpawner() : base()
    {
       // yCoordinate = transform.position;
    }
    //void Start()
    //{
    //    timeController = FindObjectOfType<TimeController>();
    //}

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolCharactersList;
    }

    //public override void Spawn()
    //{
    //    //if (timeController.IsNight())
    //    //{ return; }
    //    //base.Spawn();
        
    //}


}
