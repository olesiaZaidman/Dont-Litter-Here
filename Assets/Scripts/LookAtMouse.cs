using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{   
    [SerializeField] Camera mainCamera;

    void Update()
    {
        if (!PlayerController.IsCleaningState||!PlayerController.IsTiredState)
        { RotateAfterMouseCoursor(); }
    }

    void RotateAfterMouseCoursor()
    {        
        Vector3 playerPos = mainCamera.WorldToViewportPoint(transform.position);  
        Vector3 mousePos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        Vector3 facingDirection = playerPos - mousePos;

        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        float rotationOffset = 90;
        // angle = AngleBetweenTwoPoints(playerPos, mousePos);
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - rotationOffset, 0f));       
    }

    //float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    //{
    //    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg; 
    //}
}
