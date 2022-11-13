using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public List<AudioSource> digSounds;
    public AudioSource changeChar;
    public AudioSource drillIdle;
    public AudioSource drillActive;
    public AudioSource movingBucket;
    public List<AudioSource> pickUpWater;
    public AudioSource jumpBucketEmpty;
    public AudioSource jumpBucketFilled;
    public AudioSource jumpDrill;

    public Drill drill;
    public Bucket bucket;

    // Playing digging sound.
    public void Dig()
    {
        digSounds[Random.Range(0, digSounds.Count - 1)].Play();
    }

    // Playing transform sound.
    public void ChangeChar()
    {
        if (!changeChar.isPlaying)
        {
            changeChar.Play();
        }
    }

    // Playing idle drilling sound.
    public void DrillIdlePlay()
    {
        if (!drillIdle.isPlaying)
        {
            drillIdle.Play();
        }
    }

    // Stopping idle drilling sound.
    public void DrillIdleStop()
    {
        drillIdle.Stop();
    }

    // Playing active drilling sound.
    public void IsMoving()
    {
        if (drill.isDrill)
        {
            drillActive.Play();
        }
    }

    // Playing moving bucket sound.
    public void MovingBucket()
    {
        Debug.Log("Character is moving as a bucket (audio)");
        movingBucket.Play();
    }

    // Playing splashy water sounds.
    public void PickUpWater()
    {
        pickUpWater[Random.Range(0, pickUpWater.Count - 1)].Play();
    }

    // Playing jumping sounds.
    public void Jump()
    {

        if (drill.isDrill)
        {
            jumpDrill.Play();
        }
        else if (bucket.isBucket && !bucket.isFull)
        {
            jumpBucketEmpty.Play();
        }
        else
        {
            jumpBucketFilled.Play();
        }
    }
}
