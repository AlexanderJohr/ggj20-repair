using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public GameObject ClickableObject;
    public Camera Cam;
    public int Layermask = 11;
    public GameObject ThrowIndicator;
    public GameObject Paperball;

    public float power = 0;
    public float Startpower = 10;

    public bool Throwmode = false;

    [Header("Sound")]
    public AudioClip ShortShot;
    public AudioClip LongShot;

    private void Start()
    {
        power = Startpower;
    }

    private void Update()
    {
        if (Throwmode)
        {
            if (!ThrowIndicator.activeSelf) ThrowIndicator.SetActive(true);
            if (Input.GetMouseButtonDown(1))
            {
                Throwmode = false;
            }

            if (Input.GetMouseButton(0))
            {
                power += 0.4f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if(power < 5)
                {
                    GetComponent<AudioSource>().clip = ShortShot;
                    GetComponent<AudioSource>().Play();
                }
                else
                {
                    GetComponent<AudioSource>().clip = LongShot;
                    GetComponent<AudioSource>().Play();
                }

                GameObject go = Instantiate(Paperball, Paperball.transform.position, Quaternion.identity);
                go.SetActive(true);
                go.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
                power = Startpower;
                //go.GetComponent<Rigidbody>().AddForce(transform.forward*100);
            }
        }
        else
        {
            if (ThrowIndicator.activeSelf) ThrowIndicator.SetActive(false);

            RaycastHit RayToObject = new RaycastHit();

            Debug.DrawLine(transform.position, transform.forward * 50, Color.red);
            Physics.Raycast(transform.position, transform.forward, out RayToObject, 500f, 11, QueryTriggerInteraction.Collide);

            if (Physics.Raycast(transform.position, transform.forward, out RayToObject, 500f, 11, QueryTriggerInteraction.Collide))
            {
                if(RayToObject.collider.gameObject.GetComponent<ObjectTrigger>() != null) RayToObject.collider.gameObject.GetComponent<ObjectTrigger>().YouAreBeingWatched();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Throwmode = true;
            }
        }
        
        

    }
}
