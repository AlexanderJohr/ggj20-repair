using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappySound : MonoBehaviour
{
    private ObjectTrigger radio;
    [Range(0, 6)] public int HappyRadioIndex;

    public int LastHappyRadioIndex;

    public int HappyValue = 60;


    void Start()
    {
        radio = GameObject.FindGameObjectWithTag("Radio").GetComponent<ObjectTrigger>();

        LastHappyRadioIndex = 0;
    }

    void Update()
    {


        if (HappyValue > 0 && radio.RadioIndex == HappyRadioIndex && radio.gameObject.GetComponent<AudioSource>().clip != null)
        {
            if (LastHappyRadioIndex != radio.RadioIndex)
            {
                LastHappyRadioIndex = radio.RadioIndex;
                if (!GetComponent<AudioSource>().enabled) GetComponent<AudioSource>().enabled = true;
                GetComponent<AudioSource>().PlayDelayed(3f);

                GameObject.FindGameObjectWithTag("Plumber").GetComponent<Plumber>().AddRage(-HappyValue);
                HappyValue /= 2;
            }
        }
    }


}
