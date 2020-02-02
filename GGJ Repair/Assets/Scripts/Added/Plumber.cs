using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plumber : MonoBehaviour
{
    public float MaxTime;
    public float CurrentTime;
    public float MaxRage;
    public float CurrentRage;
    public GameObject plumber;
    public GameObject gameOverScreen;

    private float timeUntilScratch = 15;

    void Start()
    {
        CurrentTime = MaxTime;
        CurrentRage = 0;
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        timeUntilScratch -= Time.deltaTime;
        if (timeUntilScratch < 0)
        {
            timeUntilScratch = 15;
            plumber.GetComponent<Animator>().SetTrigger("scratch");
        }

        if (CurrentRage <= MaxRage)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
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
        gameOverScreen.SetActive(true);
    }

    public void Ragequit()
    {
        Debug.Log("Ragequit");
        gameOverScreen.SetActive(true);
    }

    public void AddRage(int addedRage)
    {
        CurrentRage += addedRage;
    }

    public void AddTime(float timeboni)
    {
        if (CurrentTime + timeboni <= MaxTime && CurrentTime + timeboni >= 0)
        {
            CurrentTime += timeboni;
        }
        else
        {
            if (CurrentTime + timeboni >= MaxTime)
            {
                CurrentTime = MaxTime;
            }
            else
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
