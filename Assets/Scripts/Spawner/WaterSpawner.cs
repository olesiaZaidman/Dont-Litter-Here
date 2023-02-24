using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class WaterSpawner : CharactersSpawner
{
    protected override float StartDelayMin { get { return 3f; ; } }
    protected override float StartDelayMax { get { return 15f; } }
    protected override float SpawnIntervalMin { get { return 10f; } }
    protected override float SpawnIntervalMax { get { return 30f; } }

    public WaterSpawner() : base()
    {
        xMaxRange = GamePlayBoundaries.XRightBound;
        xMinRange = GamePlayBoundaries.XLeftBound;
        zMaxRange = GamePlayBoundaries.ZTopBound;
        zMinRange = GamePlayBoundaries.ZBottomBound;
    }

    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolWaterList;
    }
}
