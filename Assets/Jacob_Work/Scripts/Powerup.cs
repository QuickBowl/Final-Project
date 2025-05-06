using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private AudioClip powerUpSound;
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
        powerupEffect.Apply(collision.gameObject);
    }
}
