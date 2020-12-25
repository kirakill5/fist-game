using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocoreTrig : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }   
    }

}
