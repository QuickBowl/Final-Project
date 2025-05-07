using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpHeight = 15.0f; 
    public float gravity = -5.0f;
    [SerializeField] private AudioClip jumpSound;
    private CharacterController control;
    private float airSpeed;
    private bool sprint;

    void Start()
    {
        control = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!sprint && Input.GetButtonUp("Sprint"))
        //{
        //    sprint = true;
        //}
        //else if(sprint && Input.GetButtonUp("Sprint"))
        //{
        //    sprint = false;
        //}

        //if (sprint)
        //{
        //    speed = 14.0f;
        //}

        if (Input.GetButtonDown("Sprint"))
        {
            speed = 14.0f;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            speed = 7.0f;
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 mover = new Vector3(deltaX, 0, deltaZ);

        
        mover = Vector3.ClampMagnitude(mover, speed);
        airSpeed += gravity * Time.unscaledDeltaTime;
        mover.y = airSpeed;
        mover *= Time.unscaledDeltaTime;
        mover = transform.TransformDirection(mover);

        control.Move(mover);

        if (control.isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
                airSpeed = jumpHeight;

            }
        }

    }
}
