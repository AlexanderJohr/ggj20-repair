using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plumber : MonoBehaviour
{
    public float MaxTime;
    public float CurrentTime;
    public float MaxRage;
    public float CurrentRage;

    private int multiplyTime = 10;

    void Start()
    {
        MaxTime *= multiplyTime;
        CurrentTime = MaxTime;
        CurrentRage = 0;
    }

    void Update()
    {
        if(CurrentRage < MaxRage)
        {
            if (CurrentTime > 0)
            {
                CurrentTime--;
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

    public void AddTime(int timeboni)
    {
        CurrentTime += timeboni*multiplyTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Paperball")
        {
            AddRage(20);
        }
    }
}
