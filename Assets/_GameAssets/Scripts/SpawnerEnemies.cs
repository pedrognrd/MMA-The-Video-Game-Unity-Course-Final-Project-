using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    private GameObject prefabEnemy;
    [SerializeField]
    private GameObject enemyToSpawn;
    [SerializeField]
    private float timeBetweenInstances;
    private int minEnemies = 1;
    private int maxEnemies = 4;
    public int spawning;

    private int enemiesCreated = 0;

    public void SpawnDeepOnes()
    {
        enemiesCreated = 0;
        spawning = Random.Range(minEnemies, maxEnemies);
        InvokeRepeating("Spawning", 0, timeBetweenInstances);
        
    }

    private void Spawning() 
    {
        prefabEnemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);

        enemiesCreated++;
        if (enemiesCreated == spawning)
        {
            CancelInvoke();
        }
    }
}
