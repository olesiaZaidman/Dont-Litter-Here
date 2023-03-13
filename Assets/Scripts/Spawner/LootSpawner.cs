using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;
public class LootSpawner : OnceSpawnerWithRotationPositionDayOrNight
{

    public LootSpawner() : base()
    {
        xMaxRange = GamePlayBoundaries.XRightBound;
        xMinRange = GamePlayBoundaries.XLeftBound;
        zMaxRange = GamePlayBoundaries.ZTopBound;
        zMinRange = GamePlayBoundaries.ZBottomBound;
    }


    #region Pool
    public override List<Pool> GetPoolPrefabList()
    {
        return Instance.poolLootList;
    }
    #endregion
    //poolLootList
}
