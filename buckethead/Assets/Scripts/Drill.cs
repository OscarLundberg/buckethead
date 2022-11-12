using UnityEngine;
using UnityEngine.Events;

public class Drill : MonoBehaviour
{
    [SerializeField]
    public bool isDrill = true;
    private void OnCollisionStay2D(Collision2D other)
    {  
        var isBlock = other.transform.tag == "ground";
        if ((isBlock && (other.transform.position.x < transform.position.x)) && isDrill)
        {
            Debug.Log("Drilling");
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
            {   
                Destroy(other.gameObject);
            }
        }
        if (isBlock && (other.transform.position.x > transform.position.x) && isDrill)
        {
            Debug.Log("Drilling");
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
            {   
                Destroy(other.gameObject);
            }
        }
        if (isBlock && (other.transform.position.y < transform.position.y) && isDrill)
        {
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
            {   
                Destroy(other.gameObject);
            }
        }
        if (isBlock  && (other.transform.position.y > transform.position.y) && isDrill)
        {
            if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {   
                Destroy(other.gameObject);
            }
        }
    }

        
}
