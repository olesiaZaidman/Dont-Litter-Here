using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundariesChecker //: MonoBehaviour
{
   // private Transform m_position;
    private Vector3 m_position;
    public GameBoundariesChecker(Vector3 position)
    {
        this.m_position = position;
    }

    //public bool IsWithinTopBound()
    //{ 
    //    return transform.position.z > GamePlayBoundaries.ZTopBound; 
    //}
    //public bool IsWithinBottomBound()
    //{
    //    return transform.position.z < GamePlayBoundaries.ZBottomBound;
    //}
    //public bool IsWithinRightBound()
    //{
    //    return transform.position.x > GamePlayBoundaries.XRightBound;
    //}
    //public bool IsWithinLeftBound()
    //{
    //    return transform.position.x < GamePlayBoundaries.XLeftBound;
    //}
    public bool IsWithinBound(float position, float bound)
    {
        return position > bound;
    }

    public bool IsWithinTopZBound(Vector3 position, float bound)
    {
        return position.z > bound;
    }
    public bool IsWithinBottomZBound(Vector3 position, float bound)
    {
        // return position.position.z < GamePlayBoundaries.ZBottomBound;
        return position.z < bound;
    }
    public bool IsWithinRightXBound(Vector3 position, float bound)
    {
        return position.x > bound;
    }
    public bool IsWithinLeftXBound(Vector3 position, float bound)
    {
        return position.x < bound;
    }

    public bool IsWithinTopZPresetBound(Vector3 position)
    {
        return position.z > GamePlayBoundaries.ZTopBound;
    }
    public bool IsWithinBottomZPresetBound(Vector3 position)
    {
        // return position.position.z < GamePlayBoundaries.ZBottomBound;
        return position.z < GamePlayBoundaries.ZBottomBound;
    }
    public bool IsWithinRightPresetXBound(Vector3 position)
    {
        return position.x > GamePlayBoundaries.XRightBound;
    }
    public bool IsWithinLeftPresetXBound(Vector3 position)
    {
        return position.x < GamePlayBoundaries.XLeftBound;
    }
}
