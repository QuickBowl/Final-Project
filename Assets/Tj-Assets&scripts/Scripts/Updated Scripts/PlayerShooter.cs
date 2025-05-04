using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;     // Cannonball prefab
    public Transform shootPoint;            // Muzzle or camera forward
    public float shootForce = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * shootForce;
        }
    }
}
