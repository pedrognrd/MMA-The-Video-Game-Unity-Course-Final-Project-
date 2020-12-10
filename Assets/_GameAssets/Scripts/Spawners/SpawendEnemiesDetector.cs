using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

public class SpawendEnemiesDetector : MonoBehaviour
{
    // THIS CLASS CONTROLS THE AMMOUNT OF ENEMIES IN SCENE
    // It will be working when any spawner point is spawning or a enemy dies
    public bool selectingEnemy;
    // In the demo, there will be 4 spawning points working
    public int spawningWaves;
    // Array with the enemies in scene
    public GameObject[] enemies;
    // 
    public GameObject enemySelected;
    public bool enemyDied;
    public bool spawned;
    public bool isDagon;

    private void Awake()
    {
        selectingEnemy = false;
        enemyDied = false;
        spawned = false;
        isDagon = false; 
        spawningWaves = 0;
    }

    private void Update()
    {
        // TODO control not choosing Dagon if spawningWaves < 4
        // TODO control  choosing Dagon if spawningWaves <= 4
        if (spawningWaves <= 4)
        {
            if (enemyDied)
            {
                StartCoroutine(ExecuteAfterTime(2));
                print("MURIO");
                enemyDied = false;
            }

            if (spawned)
            {
                StartCoroutine(ExecuteAfterTime(2));
                spawned = false;
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        print("en la co-rutina");
        DetectEnemies();
    }

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    // Create of array that detects the active enemies in scene
    public void DetectEnemies()
    {
        ClearLog();
        print("enemies.Length ANTES" + enemies.Length);
        print("enemyDied ANTES" + enemyDied);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print("enemies.Length DESPUES" + enemies.Length); 
        PaintItWhite();
        SelectEnemy();
    }

    public void PaintItWhite()
    {
        foreach (GameObject enemy in enemies) 
        {
            enemy.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }

    public void SelectEnemy()
    {
        int index = Random.Range(0, enemies.Length);
        enemySelected = enemies[index];
        enemySelected.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
    }
    public void SpawningWaves(int ammount)
    {
        spawningWaves += ammount;
    }
}
                
