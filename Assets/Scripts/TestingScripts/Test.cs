using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemData _data;

    public ItemData data { get { return _data; } }
}

public class Weapon : Item
{
    [SerializeField] WeaponData _daata;

    public WeaponData daata { get { return _daata; } }
}

public class ItemData : ScriptableObject { }
public class WeaponData : ItemData { }
