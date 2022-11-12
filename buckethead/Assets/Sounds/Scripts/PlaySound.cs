using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource coin;
    public List<AudioSource> digSounds;
    public AudioSource changeChar;
    public AudioSource drillIdle;
    public AudioSource drillActive;
    public AudioSource movingBucket;
    public AudioSource wizardAmbience;
    public List<AudioSource> wizardCough;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Playing coin pickup sound at different pitches.
    public void Coin()
    {
        if (!coin.isPlaying)
        {
            Debug.Log("Coin is picked up (audio)");
            coin.pitch = Random.Range(0.95F, 1.05f);
            coin.Play();
        }
    }

    // Playing digging sound, accidentally a minecraft apple. Not sampled.
    public void Dig()
    {
        Debug.Log("Character is digging (audio)");
        digSounds[Random.Range(0, digSounds.Count - 1)].Play();
    }

    // Playing transform sound.
    public void ChangeChar()
    {
        if (!changeChar.isPlaying)
        {
            Debug.Log("Character has transformed (audio)");
            changeChar.Play();
        }
    }

    // Playing idle drilling sound.
    public void DrillIdle()
    {
        Debug.Log("Character is a drill, idle (audio)");
    }

    // Playing active drilling sound.
    public void DrillActive()
    {
        Debug.Log("Character is drilling (audio)");
    }

    // Playing moving bucket sound.
    public void MovingBucket()
    {
        Debug.Log("Character is moving as a bucket (audio)");
    }

    // Playing wizard ambience sound.
    public void WizardAmbience()
    {

    }

    // Playing wizard coughing sound.
    public void WizardCough()
    {
        
    }
}
