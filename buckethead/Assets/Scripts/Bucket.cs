using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public bool isBucket;
    public bool isFull;
    public int capacity = 20;
    public int current = 0;
    public Sprite fullBucket;
    public PlaySound ps;

    private void OnCollisionStay2D(Collision2D other)
    {
        var isWater = other.transform.tag == "water";
        if (isWater && isBucket)
        {
               
            if(current < capacity)
            {
                current++;
                if(current >= capacity)
                {
                    isFull = true;       // set bucket to full  
                    GetComponent<SpriteRenderer>().sprite = fullBucket;
                }
                    
                Destroy(other.gameObject); // remove the water from the ground
                ps.PickUpWater();
            }

            
        }

    }
}
