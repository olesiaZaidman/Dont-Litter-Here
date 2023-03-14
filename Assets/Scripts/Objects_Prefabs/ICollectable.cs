using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    int Points { get; set; }
    void GetCollected();
    int GetPoints();
}

