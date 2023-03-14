using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public static GameManager Instance;

    
    private void Awake()
    {
        isGameOver = false;
        Instance = this;
    }

    void Update()
    {
        
    }
}
