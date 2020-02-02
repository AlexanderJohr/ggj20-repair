using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFor3D : MonoBehaviour
{
    public Image angerEmoji;
    public Image Rage;
    public Image Time;
    public Plumber Plumber;

    public Sprite angrySprite1;
    public Sprite angrySprite2;
    public Sprite happySprite;


    private float currentUItime;
    private float currentUIRage;

    private float actualTime;
    private float actualRage;

    public float increasePerFrame;

    void Start()
    {
        currentUIRage = 0;
        currentUItime = 1;
        Rage.fillAmount = currentUIRage;
    }

    enum AngrynessType
    {
        happy,
        angry,
        veryAngry
    }

    private AngrynessType angryness;

    private AngrynessType Angryness
    {
        get => angryness;
        set
        {
            if (angryness != value)
            {
                angryness = value;

                switch (angryness)
                {
                    case AngrynessType.happy:
                        angerEmoji.sprite = happySprite;
                        break;
                    case AngrynessType.angry:
                        angerEmoji.sprite = angrySprite1;
                        break;
                    case AngrynessType.veryAngry:
                        angerEmoji.sprite = angrySprite2;
                        break;
                    default:
                        break;
                }

            }

        }
    }

    void Update()
    {
        actualRage = Plumber.CurrentRage / Plumber.MaxRage;
        actualTime = 1 - (Plumber.CurrentTime / Plumber.MaxTime);

        //if(Mathf.Abs(Rage.value - actualRage) > 0.05f)
        //{
        Rage.fillAmount = Mathf.Lerp(Rage.fillAmount, actualRage, 0.01f);

        Time.fillAmount = Mathf.Lerp(Time.fillAmount, actualTime, 0.1f);

        if (actualRage < 0.5)
        {
            Angryness = AngrynessType.happy;
        }
        else if (actualRage >= 0.5 && actualRage < 0.75)
            Angryness = AngrynessType.angry;
        else
        {
            Angryness = AngrynessType.veryAngry;
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
