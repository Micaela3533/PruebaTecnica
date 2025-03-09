using UnityEngine;

public class ShipController : MonoBehaviour
{
    public int health = 1000;

    public float movementSpeed;
    public float maxSpeed;


    private Animator animator;
    private Rigidbody rB;


    void Start()
    {
        rB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector3 motion = new Vector3(x, 0f, 0f);

        if (rB.linearVelocity.magnitude < maxSpeed)
        {
            rB.AddForce(motion * movementSpeed * Time.deltaTime);
        }

        animator.SetBool("moving", x != 0);

        FaceDirection(x);

    }


    void FaceDirection(float x)
    {
        if (x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}

