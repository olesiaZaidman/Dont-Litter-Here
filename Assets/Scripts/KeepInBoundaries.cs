using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBoundaries : MonoBehaviour
{
    GameBoundariesChecker myBoundariesChecker;

    private void Awake()
    {
        myBoundariesChecker = new GameBoundariesChecker(transform.position);
    }
    void Update()
    {
        StayInGameSpaceBoundaries();
    }

    void StayInGameSpaceBoundaries()
    {
        if (transform.position.x > GamePlayBoundaries.XRightBound) //Keeps the player inbounds
        {
            transform.position = new Vector3(GamePlayBoundaries.XRightBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < GamePlayBoundaries.XLeftBound)//Keeps the player inbounds
        {
            transform.position = new Vector3(GamePlayBoundaries.XLeftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.z > GamePlayBoundaries.ZTopBound) //Keeps the player inbounds
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, GamePlayBoundaries.ZTopBound);
        }

        if (transform.position.z < GamePlayBoundaries.ZBottomBound)//Keeps the player inbounds
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, GamePlayBoundaries.ZBottomBound);
        }

    }
}
