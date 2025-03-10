using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpHeight = 15.0f; 
    public float gravity = -5.0f;

    private CharacterController control;
    private float airSpeed;

    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 mover = new Vector3(deltaX, 0, deltaZ);
        mover = Vector3.ClampMagnitude(mover, speed);
        airSpeed += gravity * Time.deltaTime;
        mover.y = airSpeed;
        mover *= Time.deltaTime;
        mover = transform.TransformDirection(mover);

        control.Move(mover);
        
        if (Input.GetButtonDown("Jump"))
        {
            airSpeed = jumpHeight;
        }

    }
}
