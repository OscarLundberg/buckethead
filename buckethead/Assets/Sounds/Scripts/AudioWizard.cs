using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWizard : MonoBehaviour
{
    public AudioSource wizardAmbience;
    public List<AudioSource> wizardCough;

    public float timer;
    public float timeBetweenCoughs = 5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenCoughs)
        {
            wizardCough[Random.Range(0, wizardCough.Count - 1)].Play();
            timer = 0;
        }
    }
}
