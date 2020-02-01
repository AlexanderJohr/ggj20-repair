using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{

    public GameObject ParticleSys;
    public bool isLookedAt = false;
    public bool ParticleIsRunning = false;

    public bool CanBeActivated = true;
    public int FullTimer = 50;
    public int currentTimer = 0;


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
                Debug.Log("boop");
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
