using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakabol : MonoBehaviour
{
    public Boutten check;
    private void Update()
    {
        if (check.bouttenON == true)
        {
            Destroy(gameObject);
        }
    }
  
  

}
