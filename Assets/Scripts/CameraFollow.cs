using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;


    private void FixedUpdate()
    {

        Vector3 targetPosition = playerTransform.position + offset;


        targetPosition.x = playerTransform.position.x + offset.x;
        targetPosition.y = 1;
        targetPosition.z = playerTransform.position.z + offset.z;

    
        transform.DOMove(targetPosition, 0.25f);


    }
}
