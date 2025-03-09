using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefabs; 
    public float spawnHeight = 5f; 
    public float spawnRangeX = 8f; 
    public int maxEnemies = 10; 
    private int currentEnemyCount = 0;


    private int totalEnemies = 0;
    private int currentEnemies; 
    public GameObject victoryScreen;

    private List<Vector3> occupiedPositions = new List<Vector3>();



    void Start()
    {
        victoryScreen.SetActive(false);
        SpawnEnemies();
        currentEnemies = maxEnemies;

    }

    void Update()
    {
        if (currentEnemyCount == 0 && totalEnemies < maxEnemies)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {

        int enemiesToSpawn = Random.Range(1, 4);

        if (totalEnemies + enemiesToSpawn <= maxEnemies)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Vector3 spawnPosition = GetValidSpawnPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                occupiedPositions.Add(spawnPosition);

                currentEnemyCount++;
                totalEnemies++;
            }
        }

    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPosition;
        bool validPosition = false;
        int maxAttempts = 10;  

        while (!validPosition && maxAttempts > 0)
        {
            spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight, 0f);

           
            validPosition = true;
            foreach (Vector3 occupiedPosition in occupiedPositions)
            {
                if (Vector3.Distance(spawnPosition, occupiedPosition) < 2f) 
                {
                    validPosition = false;
                    break;
                }
            }

            maxAttempts--;
            if (validPosition)
                return spawnPosition;
        }

      
        return new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight, 0f);
    }

    public void OnEnemyDestroyed()
    {
        currentEnemies--;
        currentEnemyCount--;
        if (currentEnemies <= 0)
        {
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f; 
    }
}
