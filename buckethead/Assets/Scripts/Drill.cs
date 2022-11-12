using UnityEngine;
using UnityEngine.Events;

public class Drill : MonoBehaviour
{
  [SerializeField]
  public bool isDrill = true;
  public float range = 0.4f;
  public LayerMask lm;
  private void OnCollisionStay2D(Collision2D other)
  {
    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
    {
      DestroyTowards(Vector2.left);
    }

    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
    {
      DestroyTowards(Vector2.right);
    }

    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
    {
      DestroyTowards(Vector2.down);
    }

    if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
    {
      DestroyTowards(Vector2.up);
    }
  }

  public void DestroyTowards(Vector2 dir)
  {
    var rayCastHit = Physics2D.Raycast(transform.position, dir, range, lm);
    if (rayCastHit)
    {
      if(isDrill){
        Debug.DrawRay(transform.position, dir, Color.blue);
        Destroy(rayCastHit.transform.gameObject);
      }
    }
  }


}
