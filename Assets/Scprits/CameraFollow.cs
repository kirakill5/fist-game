using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 range;
    void Awake()
    {
        //Calculate the range between the Camera's position and the Dird's position
        range = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        //Make the Camera follow the Bird's movement on the X axis
        //And keep the y position constant
        transform.position = new Vector3(range.x + playerTransform.position.x, transform.position.y, range.z + playerTransform.position.z);
    }
}
