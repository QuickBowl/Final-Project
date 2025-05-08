using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //set zoom
    int zoom = 20;
    //set normal fov
    int normal = 60;
    //will smooth zoom in motion of camera, so it doesnt rapidly change scene
    float smooth = 5;

    //establish zoom
    private bool isZoomed = false;


    // Update is called once per frame
    void Update()
    {
        //get input from right click
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }

        //for this instance, if iszoomed is true (m2 is pressed), get component of camera and zoom
        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
        else //otherwise stay normal
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }
}
