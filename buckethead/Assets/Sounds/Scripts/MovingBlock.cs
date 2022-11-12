using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingBlock movingBlock = GetComponent<MovingBlock>();
        float longitude = movingBlock.gameObject.transform.position.x;
        longitude += 5;

    }
}
