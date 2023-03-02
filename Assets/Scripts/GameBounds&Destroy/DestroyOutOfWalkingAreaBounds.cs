using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfWalkingAreaBounds : DestroyOutOfBounds
{

    public override void DestroyIfOutOfGamePlayBounds()
    {
        if ((transform.position.z > GamePlayBoundaries.XRighZToptWalkingAreaBound) ||
            (transform.position.x > GamePlayBoundaries.XRighZToptWalkingAreaBound))
        {
            gameObject.SetActive(false);          // Destroy(gameObject);
        }
        if ((transform.position.z < GamePlayBoundaries.XLeftZBottomWalkingAreaBound) ||
           (transform.position.x < GamePlayBoundaries.XLeftZBottomWalkingAreaBound))
        {
            gameObject.SetActive(false);          // Destroy(gameObject);
        }
    }
  
}
