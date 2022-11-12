using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{   
    public Bucket bucket;
    public Drill drill;
    public void OnTriggerEnter2D(Collider2D collider)
    {   
        Debug.Log("Sim sala bim");
        if (drill.isDrill)
        {
            Debug.Log("You are now a Bucket");
            drill.isDrill = false;
            bucket.isBucket = true;
            bucket.isFull = false; 
        }
        else
        {
            Debug.Log("You are now a Drill");
            drill.isDrill = true;
            bucket.isBucket = false;
            bucket.isFull = false; 
        }
    }
}
