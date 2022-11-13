using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wizard : MonoBehaviour
{   
    public Bucket bucket;
    public Drill drill;
    public Sprite bucketSprite;
    public Sprite drillSprite;
    public ParticleSystem pSys;
    public PlaySound ps;
    public static int tally;
    bool firstTime = true;
    public void OnTriggerEnter2D(Collider2D collider)
    {   
        if ( firstTime && collider.transform.tag == "Player") {
            Debug.Log("HAPPENED");
            UIManager.instance.StartGame();
            firstTime = false;
        }
        if (drill.isDrill)
        { 

            Debug.Log("You are now a Bucket");
            bucket.GetComponent<SpriteRenderer>();
            bucket.GetComponent<SpriteRenderer>().sprite = bucketSprite;
            drill.isDrill = false;
            bucket.isBucket = true;
            bucket.isFull = false;

            ps.DrillIdleStop();
        }
        else
        {
            Debug.Log("You are now a Drill");
            drill.isDrill = true;
            drill.GetComponent<SpriteRenderer>().sprite = drillSprite;
            bucket.isBucket = false;
            Wizard.tally += bucket.current;
            UIManager.instance.SetScore(Wizard.tally);
            bucket.current = 0;
            bucket.isFull = false;

            ps.DrillIdlePlay();
        }

        pSys.Play();
        ps.ChangeChar();
    }
}
