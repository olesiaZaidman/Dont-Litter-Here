using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offSet;
    void LateUpdate()
    {
        transform.position = objectToFollow.position + offSet;
    }
}
