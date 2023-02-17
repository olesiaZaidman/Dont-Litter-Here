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
            gameObject.SetActive(false);          // Destroy(gameObject);
        }

        if (transform.position.x > GamePlayBoundaries.XRightBound)
        {
            gameObject.SetActive(false);          // Destroy(gameObject);
        }
        if (transform.position.z < GamePlayBoundaries.ZBottomBound)
        {
            gameObject.SetActive(false);          // Destroy(gameObject);
        }

        if  (transform.position.x < GamePlayBoundaries.XLeftBound)
        {
            gameObject.SetActive(false);          // Destroy(gameObject);
        }
    }
}
