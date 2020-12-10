using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    // THIS CLASS INSTANTIATE DEEPONES
    private GameObject prefabEnemy;
    [SerializeField]
    private GameObject enemyToSpawn;
    [SerializeField]
    private float timeBetweenInstances;
    public int spawning;
    private int enemiesCreated = 0;

    public void SpawnDeepOnes(int number)
    {
        enemiesCreated = 0;
        spawning = number;
        print("spawning " + spawning);
        InvokeRepeating("Spawning", 0, timeBetweenInstances);
    }

    private void Spawning() 
    {
        prefabEnemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);

        enemiesCreated++;
        if (enemiesCreated >= spawning)
        {
            CancelInvoke();
            GameObject.Find("GameManager").GetComponent<SpawendEnemiesDetector>().spawning = true;
            GameObject.Find("GameManager").GetComponent<SpawendEnemiesDetector>().DetectEnemies();
        }
    }
}
