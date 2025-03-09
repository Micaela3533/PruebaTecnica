using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No se encontró el objeto FirePoint como hijo.");
        }


    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (firePoint == null) return;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);



    }


}