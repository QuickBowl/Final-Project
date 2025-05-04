using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name);

        TurretScript_1 turret = collision.gameObject.GetComponent<TurretScript_1>();
        if (turret != null)
        {
            Debug.Log("Turret hit by bullet!");
            turret.TakeDamage(1);
        }

        Destroy(gameObject); // Destroy the bullet after impact
    }
}
