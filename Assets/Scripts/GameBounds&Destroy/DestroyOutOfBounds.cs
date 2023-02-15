using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour, IDestroyable
//DestroyOutOfWalkingAreaBounds
{
    void Update()
    {
        DestroyIfOutOfGamePlayBounds();
    }
    public virtual void DestroyIfOutOfGamePlayBounds()
    {
        if (transform.position.z > GamePlayBoundaries.ZTopBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > GamePlayBoundaries.XRightBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < GamePlayBoundaries.ZBottomBound)
        {
            Destroy(gameObject);
        }

        if  (transform.position.x < GamePlayBoundaries.XLeftBound)
        {
            Destroy(gameObject);
        }
    }
}
