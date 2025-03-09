using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage = 25;

        void Start()
        {
            Destroy(gameObject, 3f); 
        }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

           
            Destroy(gameObject);
        }

    }
}
