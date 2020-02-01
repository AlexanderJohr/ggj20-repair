using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public GameObject Character;
    public float Speed;
    public float Sensitivity = 5.0f;
    public float Smoothing = 2.0f;
    public Vector2 SmoothingVector;
    private Vector2 CurrentMouseLook;

    private void Start()
    {
        //Character = this.gameObject;
    }

    void Update()
    {
        Vector2 MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        MouseInput = Vector2.Scale(MouseInput, new Vector2(Smoothing * Sensitivity, Smoothing * Sensitivity));
        SmoothingVector.x = Mathf.Lerp(SmoothingVector.x, MouseInput.x, 1f / Smoothing);
        SmoothingVector.y = Mathf.Lerp(SmoothingVector.y, MouseInput.y, 1f / Smoothing);
        CurrentMouseLook += SmoothingVector;

        //transform.localRotation = Quaternion.AngleAxis(-CurrentMouseLook.y, Vector3.right);
        //Character.transform.localRotation = Quaternion.AngleAxis(MouseInput.x, Character.transform.up);

        transform.localRotation = Quaternion.AngleAxis(-CurrentMouseLook.y, Vector3.right);
        Character.transform.localRotation = Quaternion.AngleAxis(CurrentMouseLook.x, Character.transform.up);
    }
}
