using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public float speed = 10f;

    public GameObject laserPrefab;
    public Transform firePoint;
    public float laserSpeed = 30f;
    public float fireRate = 0.1f;

    private float nextFireTime = 0f;




    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (firePoint == null) return;

        GameObject laser = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = laser.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.up * laserSpeed;
    }
}
