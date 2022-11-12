using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public bool isBucket;
    public bool isFull;
    private void OnCollisionStay2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerMovement>();
        if (player && (other.contacts[0].normal.x < 0) && isBucket)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {   
                if(!isFull)
                {
                    isFull = true;       // set bucket to full  
                    Destroy(gameObject); // remove the water from the ground
                }

            }
        }

    }
}
