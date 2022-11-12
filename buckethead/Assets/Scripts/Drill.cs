using UnityEngine;
using UnityEngine.Events;

public class Drill : MonoBehaviour
{
    [SerializeField]
    public bool isDrill = true;
    private void OnCollisionStay2D(Collision2D other)
    {  
        Debug.Log(isDrill);
        var player = other.collider.GetComponent<PlayerMovement>();
        if ((player != null && (other.transform.position.x < player.transform.position.x)) && isDrill)
        {
            Debug.Log("Drilling");
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
            {   
                Destroy(gameObject);
            }
        }
        if (player != null && (other.transform.position.x > player.transform.position.x) && isDrill)
        {
            Debug.Log("Drilling");
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
            {   
                Destroy(gameObject);
            }
        }
        if (player != null && (other.transform.position.y < player.transform.position.y) && isDrill)
        {
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
            {   
                Destroy(gameObject);
            }
        }
        if (player != null && (other.transform.position.y > player.transform.position.y) && isDrill)
        {
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {   
                Destroy(gameObject);
            }
        }
    }

        
}
