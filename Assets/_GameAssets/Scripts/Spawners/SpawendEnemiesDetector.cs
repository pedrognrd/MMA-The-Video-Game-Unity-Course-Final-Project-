using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawendEnemiesDetector : MonoBehaviour
{
    // THIS CLASS CONTROLS THE AMMOUNT OF ENEMIES IN SCENE
    public bool selectingEnemy;
    // It will be working when any spawner point is spawning
    public bool spawning;
    // In the demo, there will be 4 spawning points working
    public int spawningWaves;
    // Array with the enemies in scene
    public GameObject[] enemies;

    public GameObject enemySelected;


    private void Awake()
    {
        selectingEnemy = false;
        spawning = false;
        spawningWaves = 0;
    }

    private void Update()
    {
        //DetectEnemies();
        if (selectingEnemy) 
        {
            SelectEnemy(enemies);
            if (spawningWaves < 4)
            {
                if (enemySelected.name == "Dagon")
                {
                    enemySelected.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    selectingEnemy = true;
                }
            }
        }
    }

    // Create of array that detects the active enemies in scene
    public void DetectEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print("enemies antes del if" + enemies.Length);
        if (spawning)
        {
            foreach (GameObject enemy in enemies)
            {
                print("enemy" + enemy.name);
                // Dagon will not be selected for random enemy selection till the fourth wave of spawning
                if (spawningWaves < 4)
                {
                    // CREATE METHOD FOR RANDOM SELECTION WITHOUT DAGON
                }
                else {
                    // CREATE METHOD FOR RANDOM SELECTION WITH DAGON
                }
            }
            spawning = false;
            selectingEnemy = true;
            spawningWaves++;
        }
    }

    private void SelectEnemy(GameObject[] enemies) 
    {
        int index = Random.Range(0, enemies.Length);
        enemySelected = enemies[index];
        enemySelected.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        selectingEnemy = false;
        print("Enemy selected " + enemySelected.name);
    }
}
                