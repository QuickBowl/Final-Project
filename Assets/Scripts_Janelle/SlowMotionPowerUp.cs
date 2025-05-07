using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionPowerUp : MonoBehaviour
{
    public float freezeDuration = 2f;
    public float slowFactor = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateTimeFreeze());
            Destroy(gameObject); // remove the power-up
        }
    }

    private System.Collections.IEnumerator ActivateTimeFreeze()
    {
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale; // update physics steps

        yield return new WaitForSecondsRealtime(freezeDuration); // unaffected by slow time

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; // reset to default
    }
}

