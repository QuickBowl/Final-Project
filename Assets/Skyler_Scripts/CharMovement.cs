using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpHeight = 15.0f; 
    public float gravity = -5.0f;
    //public bool ground;
    //public float distToGround;

    private CharacterController control;
    private float airSpeed;

    void Start()
    {
        control = GetComponent<CharacterController>();
        //distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    //void SeeIfGrounded ()
    //{
        //RaycastHit below;
        //float check = .25f;
        //Vector3 down = new Vector3(0, -1);

        //if(Physics.Raycast(transform.position, down, out below, check))
        //Vector3 bounds = new Vector3(GetComponent<Collider>().bounds.center.x, GetComponent<Collider>().bounds.min.y - 0.1f, GetComponent<Collider>().bounds.center.z);
        //if(Physics.CheckCapsule(GetComponent<Collider>().bounds.center, bounds, 0.2f))
        //{
            //ground = true;
        //}
        //else
        //{
            //ground = false;
        //}
    //}

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 mover = new Vector3(deltaX, 0, deltaZ);
        mover = Vector3.ClampMagnitude(mover, speed);
        mover.y = gravity;
        mover *= Time.deltaTime;
        mover = transform.TransformDirection(mover);

        control.Move(mover);
        
        if (Input.GetButtonDown("Jump"))
        {
            //if (ground == true)
            //{
                airSpeed = jumpHeight;
                //ground = false;
            //}
        }

    }
}
