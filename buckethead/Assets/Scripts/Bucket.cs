using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public bool isBucket;
    public bool isFull;
    public int capacity = 20;
    public int current = 0;
    private void OnCollisionStay2D(Collision2D other)
    {
        var isWater = other.transform.tag == "water";
        if (isWater && isBucket)
        {
               
            if(current < capacity)
            {
                current++;
                if(current >= capacity)
                    isFull = true;       // set bucket to full  
                    
                Destroy(other.gameObject); // remove the water from the ground
            }

            
        }

    }
}
