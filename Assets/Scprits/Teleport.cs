using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float distance;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Plauer")
        {
            //random Y position
            //choose position --> new obstacle
            Vector3 spawnPosition = new Vector3(transform.position.x + distance,transform.position.y + 0 , 0);
            // Move Obstacle to SpawnPosition 
            col.gameObject.transform.position = spawnPosition;
        }
    }
}
