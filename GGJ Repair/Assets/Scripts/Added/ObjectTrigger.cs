using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    enum KindOfObj { Lightswitch, Sink, Marmalade, Coin, Radio };

    [SerializeField] private KindOfObj ThisObjectIs;

    public GameObject ParticleSys;
    public bool isLookedAt = false;
    public bool ParticleIsRunning = false;

    public bool CanBeActivated = true;
    public int FullTimer = 50;
    public int currentTimer = 0;

    public AudioClip ObjectSound;
    public AudioClip[] RadioSounds;
    public int RadioIndex = 0;


    private void Start()
    {
        FullTimer *= 10;
    }


    public void Update()
    {
        if (!CanBeActivated)
        {
            Timer();
        }
        

        if (isLookedAt)
        {
            if (!ParticleIsRunning & CanBeActivated)
            {
                ActivateEffect();
                ParticleIsRunning = true;
            }

            isLookedAt = false;

            if (Input.GetMouseButtonDown(0) & CanBeActivated)
            {
                CanBeActivated = false;
                DeactivateEffect();
                ObjectReaction();
            }
        }
        else
        {
            if (ParticleIsRunning)
            {
                DeactivateEffect();
                ParticleIsRunning = false;
            }
        }
    }

    public void ObjectReaction()
    {
        if(ThisObjectIs != KindOfObj.Radio)
        {
            GetComponent<AudioSource>().clip = ObjectSound;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            if(RadioIndex < RadioSounds.Length - 1)
            {
                RadioIndex++;
            }
            else
            {
                RadioIndex = 0;
            }

            AudioClip currAudio = RadioSounds[RadioIndex];
            //Radio
            GetComponent<AudioSource>().clip = currAudio;
            GetComponent<AudioSource>().Play();
        }

        if (ThisObjectIs == KindOfObj.Lightswitch)
        {
            //I'm the light and darkness
        }

        if (ThisObjectIs == KindOfObj.Coin)
        {
            //I'm a coin
        }

        if(ThisObjectIs == KindOfObj.Marmalade)
        {
            //I'm marmalade
        }

        if(ThisObjectIs == KindOfObj.Radio)
        {
            //I'm radio
        }

        if(ThisObjectIs == KindOfObj.Sink)
        {
            //I'm sink
        }


    }

    public void YouAreBeingWatched()
    {
        isLookedAt = true;
    }

    public void ActivateEffect()
    {
        ParticleSys.SetActive(true);
    }

    public void DeactivateEffect()
    {
        ParticleSys.SetActive(false);
    }

    private void Timer()
    {
        if (currentTimer >= FullTimer)
        {
            CanBeActivated = true;
            currentTimer = 0;
        }
        else
        {
            currentTimer++;
        }
    }
}
