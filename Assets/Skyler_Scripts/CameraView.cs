using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    void Start()
    {
        
    }

    public enum Axes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public Axes axes = Axes.MouseXandY;
    public float xSens = 13.0f;
    public float ySens = 13.0f;

    public float minimumVert = -45f;
    public float maximumVert = 45f;

    private float verticalRot = 0;



    void Update()
    {
        if (axes == Axes.MouseXandY)
        {
            transform.Rotate(0, xSens * Input.GetAxis("Mouse X"), 0);
        }
        else if (axes == Axes.MouseY)
        {
            verticalRot -= Input.GetAxis("Mouse Y") * ySens;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float xRotate = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, xRotate, 0);
        }
        else
        {
            verticalRot -= Input.GetAxis("Mouse Y") * ySens;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * xSens;
            float xRotate = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, xRotate, 0);
        }
    }
}
