using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Kill");
            UIManager.instance.EndGame();
        }
    }
}
