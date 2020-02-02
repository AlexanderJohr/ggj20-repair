using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappySound : MonoBehaviour
{
    private ObjectTrigger radio;
    [Range(0,6)]public int HappyRadioIndex;

    void Start()
    {
        radio = GameObject.FindGameObjectWithTag("Radio").GetComponent<ObjectTrigger>();
    }

    void Update()
    {
        if (radio.RadioIndex == HappyRadioIndex && radio.gameObject.GetComponent<AudioSource>().clip != null) {
            if (!GetComponent<AudioSource>().enabled) GetComponent<AudioSource>().enabled = true;
            GetComponent<AudioSource>().PlayDelayed(3f);
            GameObject.FindGameObjectWithTag("Plumber").GetComponent<Plumber>().AddRage(-10);
        }
    }
}
