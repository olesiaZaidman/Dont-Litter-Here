using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSpawner : SpawnerWithRotationPosition
{
    protected override float StartDelayMin { get { return 1f; } }
    protected override float StartDelayMax { get { return 10f; } }
    protected override float SpawnIntervalMin { get { return 2f; } }
    protected override float SpawnIntervalMax { get { return 15; } }

    public CharactersSpawner() : base()
    {
        //_startDelay = 2f;  
    }
}
