using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public GameObject player;


    private void FixedUpdate()
    {

        Vector3 targetPosition = playerTransform.position + offset;

        if (!player.GetComponent<Animator>().GetBool("isRunning"))
        {
            targetPosition.z = playerTransform.position.z - 10;

        } else
        {
                targetPosition.x = playerTransform.position.x + offset.x;
                targetPosition.y = playerTransform.position.y + offset.y;
                targetPosition.z = playerTransform.position.z + offset.z;
        }


        transform.DOMove(targetPosition, 0.30f);


    }
}
