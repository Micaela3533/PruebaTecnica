using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType { Big, Medium, Small }
    public EnemyType enemyType;
    public int health;

    //neuvo
    private EnemySpawner spawner;

    public int points = 0;

    void Start()
    {

        // Referencia al spawner
        spawner = FindObjectOfType<EnemySpawner>();

        switch (enemyType)
        {
            case EnemyType.Big:
                health = 125;
                points = 300;
                break;
            case EnemyType.Medium:
                health = 100;
                points = 200;
                break;
            case EnemyType.Small:
                health = 50;
                points = 100;
                break;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        // Si la vida llega a cero, destruir al enemigo
        if (health <= 0)
        {
            if (spawner != null)
            {
                spawner.OnEnemyDestroyed();
            }

            ScoreManager.instance.AddScore(points);

            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
