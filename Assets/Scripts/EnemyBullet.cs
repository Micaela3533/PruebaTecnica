using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 5f;
    public int damage = 1;
    public float lifeTime = 3f; 
    public Transform target;


    private Vector3 direction;


    void Start()
    {

        Destroy(gameObject, lifeTime);

        GameObject ship = GameObject.FindGameObjectWithTag("Player");
        if (ship != null)
        {
            target = ship.transform;

        }

        if (target != null)
        {
            direction = (target.position - transform.position).normalized;
        }

    }

    void Update()
    {

        if (direction != Vector3.zero)
        {
            transform.position += direction * speed * Time.deltaTime;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShipController ship = other.GetComponent<ShipController>();
            if (ship != null)
            {
                ship.TakeDamage(damage);
                Debug.Log("Player hit! Remaining health: " + ship.health);
            }

            Destroy(gameObject);
        }
    }
}
