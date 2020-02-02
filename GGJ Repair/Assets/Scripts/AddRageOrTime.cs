using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRageOrTime : MonoBehaviour
{
    private Plumber plumb;
    public int RageToAdd;
    public int TimeToAdd;

    void Start()
    {
        plumb = GameObject.FindGameObjectWithTag("Plumber").GetComponent<Plumber>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Paperball")
        {
            plumb.AddRage(RageToAdd);
            plumb.AddTime(TimeToAdd);
        }
    }
}
