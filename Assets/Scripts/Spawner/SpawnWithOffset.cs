using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class SpawnWithOffset : BaseSpawner, IBaseSpawner
{
    protected Vector3 spawnOffsetPos;
    protected float yCoordinate = 0f; //-0.1
    public override void Spawn()
    {
        Vector3 pos = transform.position;
        spawnOffsetPos = SetRandomspawnOffsetPos();
        Vector3 itemPos = pos + spawnOffsetPos;
        itemPos = new Vector3(itemPos.x, yCoordinate, itemPos.z);

        List<Pool> list = GetPoolPrefabList();
        index = Random.Range(0, list.Count);
        Pool pool = list[index];

        ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionary(pool, itemPos);
        CreateTimeIntervalBetweenSpawning();
    }

    private Vector3 SetRandomspawnOffsetPos()
    {
        float xPositive = Random.Range(0.4f, 1f);
        float xNegative = Random.Range(-0.5f, -1f);
      //  float y = 0.1f;
        float zPositive = Random.Range(0.8f, 1.3f);
        float zNegative = Random.Range(-1.1f, -1.5f);

        int random = Random.Range(0, 4);

        if (random == 0)
        {
            return new Vector3(xPositive, yCoordinate, zPositive);
        }

        else if (random == 1)
        {
            return new Vector3(xNegative, yCoordinate, zPositive);
        }

        else if (random == 2)
        {
            return new Vector3(xPositive, yCoordinate, zNegative);
        }
        else
        {
            return new Vector3(xNegative, yCoordinate, zNegative);
        }
    }

    #region SpawnInterval
    public virtual float SetSpawnIntervalMin(float _value)
    {
        spawnIntervalMin = Mathf.Clamp(_value, 0, 60);
        return spawnIntervalMin;
    }

    public virtual float SetSpawnIntervalMax(float _value)
    {
        spawnIntervalMax = Mathf.Clamp(_value, 0, 60);
        return spawnIntervalMax;
    }

    #endregion
}
