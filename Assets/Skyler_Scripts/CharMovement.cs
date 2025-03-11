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

    void Start()
    {
        control = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

        if (control.isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
                airSpeed = jumpHeight;

            }
        }

    }
}
