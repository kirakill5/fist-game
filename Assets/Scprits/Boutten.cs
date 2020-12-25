using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boutten : MonoBehaviour
{
    [SerializeField] public bool bouttenON;
    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            bouttenON = true;
        }

    }
}
