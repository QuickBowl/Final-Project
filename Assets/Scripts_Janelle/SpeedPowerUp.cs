using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2f;   // e.g., 2x the normal speed
    public float duration = 5f;          // Duration of the speed boost

    private void OnTriggerEnter(Collider other)
    {
        CharMovement charMovement = other.GetComponent<CharMovement>();

        if (charMovement != null)
        {
            StartCoroutine(ApplySpeedBoost(charMovement));
            gameObject.SetActive(false); // Disable power-up to prevent re-triggering
        }
    }

    private System.Collections.IEnumerator ApplySpeedBoost(CharMovement character)
    {
        float originalSpeed = character.speed;

        character.speed = originalSpeed * speedMultiplier;

        yield return new WaitForSeconds(duration);

        character.speed = originalSpeed;

        Destroy(gameObject); // Remove the power-up after use
    }
}

