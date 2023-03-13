using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;
public class OnceSpawnerWithRotationPositionDayOrNight : OnceSpawnerWithRotationPosition, IOnceSpawnerWithRotationPositionDayOrNight
{
    [SerializeField] protected bool isNight;
    [SerializeField] protected bool isDay;
    [SerializeField] protected bool isSpawned;
    TimeController timeController;

    [SerializeField] protected int numberOfLootItems = 3;

    void Awake()
    {
        timeController = FindObjectOfType<TimeController>();
        isSpawned = false;
    }
 

    void Update()
    {
        DetermineTimeOfDay();

        if (isDay && isSpawned)
        {
            isSpawned = false;
            numberOfLootItems = Random.Range(2, 10);
            Debug.Log("numberOfLootItems: "+ numberOfLootItems);
        }

        if (isNight && !isSpawned)
        {
            isSpawned = true;
            SpawnSomeNumberOfItems(numberOfLootItems);
        }
       
    }

    public virtual void SpawnSomeNumberOfItems(int _numberOfLoot)
    {
        Quaternion prefabRotation = GetRotation(xRotation, yRotation, zRotation);
        
        List<Pool> list = GetPoolPrefabList();

        for (int i = 0; i < _numberOfLoot; i++) 
        {
            Vector3 pos = GetRandomSpawnPosition();
            index = Random.Range(0, list.Count);
            Pool pool = list[index];
            ObjectPoolDictionary.Instance.SpawnObjFromPoolDictionaryWithRotation(pool, pos, prefabRotation);
        }

        Debug.Log("Loot is Spawned");

    }

    public void DetermineTimeOfDay()
    {
        if (timeController.IsEarlyMorning())
        {
            isNight = false;
            isDay = true;
        }

        if (timeController.IsEndOfWorkingDay())
        {
            isNight = true;
            isDay = false;
            // //+ DestroyIfMorning() on each gamePRefab
        }
    }
}
