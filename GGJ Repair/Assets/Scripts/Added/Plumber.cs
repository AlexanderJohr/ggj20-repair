﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plumber : MonoBehaviour
{
    public float MaxTime;
    public float CurrentTime;
    public float MaxRage;
    public float CurrentRage;


    void Start()
    {
        CurrentTime = MaxTime;
        CurrentRage = 0;
    }

    void Update()
    {
        if(CurrentRage <= MaxRage)
        {
            if (CurrentTime > 0)
            {
                CurrentTime-= Time.deltaTime;
                CurrentRage -= Time.deltaTime;

            }
            else if (CurrentTime <= 0)
            {
                RepairFinished();
            }
        }
        else
        {
            Ragequit();
        }

        if (Input.GetButtonDown("Jump")) AddRage(20);
    }

    public void RepairFinished()
    {
        Debug.Log("Repair Finished");
    }

    public void Ragequit()
    {
        Debug.Log("Ragequit");
    }

    public void AddRage(int addedRage)
    {
        if (CurrentRage + addedRage <= MaxRage && CurrentRage + addedRage >= 0)
        {
            CurrentRage += addedRage;
        }
        else
        {
            if(CurrentRage + addedRage > MaxRage)
            {
                CurrentRage = MaxRage;
            }
            else
            {
                CurrentRage = 0;
            }
        }
    }

    public void AddTime(float timeboni)
    {
        if(CurrentTime + timeboni <= MaxTime && CurrentTime + timeboni >= 0)
        {
            CurrentTime += timeboni;
        }
        else
        {
            if (CurrentTime + timeboni >= MaxTime)
            {
                CurrentTime = MaxTime;
            } else
            {
                CurrentTime = 0;
            }
        }
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if(other.gameObject.tag == "Paperball")
        {
            Debug.Log("Paperball");

            AddRage(20);
            AddTime(3);
        }
    }*/
}
