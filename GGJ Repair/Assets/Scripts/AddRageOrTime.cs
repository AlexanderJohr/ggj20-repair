using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRageOrTime : MonoBehaviour
{
    private Plumber plumb;
    private Collider collider;
    public int RageToAdd;
    public int TimeToAdd;

    public AudioClip SoundToPlay;

    void Start()
    {
        plumb = GameObject.FindGameObjectWithTag("Plumber").GetComponent<Plumber>();
        collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collider.isTrigger && collision.gameObject.tag == "Paperball")
        {
            plumb.AddRage(RageToAdd);
            plumb.AddTime(TimeToAdd);
            PlaySound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collider.isTrigger && other.gameObject.tag == "Paperball")
        {
            plumb.AddRage(RageToAdd);
            plumb.AddTime(TimeToAdd);
            PlaySound();
        }
    }

    private void PlaySound()
    {
        GetComponent<AudioSource>().clip = SoundToPlay;
        GetComponent<AudioSource>().Play();
    }
}
