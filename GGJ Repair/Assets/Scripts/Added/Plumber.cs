using System.Collections;
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
        if(CurrentRage < MaxRage)
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
        CurrentRage += addedRage;
    }

    public void AddTime(float timeboni)
    {
        CurrentTime += timeboni;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if(other.gameObject.tag == "Paperball")
        {
            Debug.Log("Paperball");

            AddRage(20);
            AddTime(3);
        }
    }
}
