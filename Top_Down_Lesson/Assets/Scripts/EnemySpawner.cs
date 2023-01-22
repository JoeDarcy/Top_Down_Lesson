using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab_1;
    [SerializeField] private float spawnRate;

    private float timer;
    private GameObject enemyInstance_1;
    private Vector2 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Set spawn rate timer
        timer = spawnRate;   
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Create a random spawn position
            spawnPosition = new Vector2(Random.Range(10, 20), Random.Range(6, 10));

            // Instantiate enemy prefabs
            enemyInstance_1 = Instantiate(enemyPrefab_1, spawnPosition, Quaternion.identity);

            // Reset timer
            timer = spawnRate;
        }
    }
}
