using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    // THIS CLASS INSTANTIATE ENEMIES AND SELECT ONE OF THEM AFTER FINISH SPAWNING
    private GameObject prefabEnemy;
    [SerializeField]
    private GameObject enemyToSpawn;
    [SerializeField]
    private float timeBetweenInstances;
    public int spawning;
    private int enemiesCreated = 0;

    public void SpawnEnemies(int number)
    {
        enemiesCreated = 0;
        spawning = number;
        InvokeRepeating("Spawning", 0, timeBetweenInstances);
    }

    private void Spawning() 
    {
        prefabEnemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);

        enemiesCreated++;
        if (enemiesCreated >= spawning)
        {
            CancelInvoke();
            GameObject.Find("GameManager").GetComponent<SpawnedEnemiesDetector>().enemiesInGame = enemiesCreated;
            GameObject.Find("GameManager").GetComponent<SpawnedEnemiesDetector>().DetectEnemies();
            // Start new combat sequence
            GameObject.Find("GameManager").GetComponent<CombatManager>().NewCombat();
        }
    }
}
