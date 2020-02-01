using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider Rage;
    public Slider Time;
    public Plumber Plumber;

    private float currentUItime;
    private float currentUIRage;

    private float actualTime;
    private float actualRage;

    public float increasePerFrame;

    void Start()
    {
        currentUIRage = 0;
        currentUItime = 1;
        Rage.value = currentUIRage;
    }

    void Update()
    {
        actualRage = Plumber.CurrentRage / Plumber.MaxRage;
        actualTime = Plumber.CurrentTime / Plumber.MaxTime;

        //if(Mathf.Abs(Rage.value - actualRage) > 0.05f)
        //{
        if(Rage.value != actualRage) {
            Rage.value = Mathf.Lerp(Rage.value, actualRage, 0.01f);
        }

        if(Time.value != actualTime)
        {
            Time.value = Mathf.Lerp(Time.value, actualTime, 0.1f);
        }

        /*if (Mathf.Abs(Time.value - actualTime) > 0.001f)
        {
            if (Time.value > actualTime)
            {
                //Time.value -= increasePerFrame;
                Time.value = actualTime;
            }
            else if (Time.value < actualTime)
            {
                //Time.value += increasePerFrame;
                Time.value = actualTime;
            }
        }*/
    }
}
