using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{   
    public Bucket bucket;
    public Drill drill;
    public Sprite bucketSprite;
    public Sprite drillSprite;

    public void OnTriggerEnter2D(Collider2D collider)
    {   
        
        if (drill.isDrill)
        {
            Debug.Log("You are now a Bucket");
            bucket.GetComponent<SpriteRenderer>();
            bucket.GetComponent<SpriteRenderer>().sprite = bucketSprite;
            drill.isDrill = false;
            bucket.isBucket = true;
            bucket.isFull = false; 
        }
        else
        {
            Debug.Log("You are now a Drill");
            drill.isDrill = true;
            drill.GetComponent<SpriteRenderer>().sprite = drillSprite;
            bucket.isBucket = false;
            bucket.isFull = false; 
        }
    }
}
