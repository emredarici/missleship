using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform playerfollow;
    private Vector3 offset;
    void Awake()
    {
        offset = playerfollow.position - transform.position;
    }
    void FixedUpdate()
    {
        var position = -offset + playerfollow.position;
        var currentPosition = Vector3.Slerp(transform.position, position, 10f);
        currentPosition.z = transform.position.z;

        transform.position = currentPosition;
    }

}
