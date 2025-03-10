using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the Player in the Inspector
    public Vector3 offset = new Vector3(0, 3, -5);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.LookAt(player); // Ensures camera is facing the player
        }
    }
}
