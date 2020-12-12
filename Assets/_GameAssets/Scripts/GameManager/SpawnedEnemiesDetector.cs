using UnityEngine;
using System.Collections;
using System.Reflection;

public class SpawnedEnemiesDetector : MonoBehaviour
{
    // THIS CLASS CONTROLS THE SPAWNED ENEMIES IN GAME
    // AND ANY TIME ONE OF THEM DIES

    // Array that storage the spawned enemies in scene
    public GameObject[] enemies;
    // Ammount of enemies spawned
    public int enemiesInGame;
    // Enemy selected for each turn
    private GameObject enemySelected;
    // Control if any of the spawned enemies is died
    //public bool enemyDied;
    // It will be working when any spawner point had spawned or when a enemy dies
    //public bool selectingEnemy;
    // Controls of spawning action is finished
    //public bool spawned;
    // In the demo, there will be 4 spawning points working
    //public int spawningWaves;
    // Dagon will be available only on fourth spawn wave
    //public bool isDagon;

    private void Awake()
    {
        //selectingEnemy = false;
        //enemyDied = false;
        /*spawned = false;
        isDagon = false;*/
        enemiesInGame = 0;
        //spawningWaves = 0;

    }

    private void Update()
    {
        if (enemiesInGame > 0)
        {
            print("Enemies in game " + enemiesInGame);
            // Selecting a default anemy after spawning
            DetectEnemies();
        }
        // If a spawned enemy dies --> New turn
        /*if (enemyDied) 
        {
            print("Starting new turn sequence");
            GetComponent<TurnSequenceManager>().turnSequenceDone = true;
            GetComponent<TurnSequenceManager>().turnSequenceDone = false;
        }*/
        /*if (spawningWaves < 4)
        {
            DiedOrSpawned();
            if (isDagon)
            {
                StartCoroutine(ExecuteAfterTime(1));
                isDagon = false;
            }
        }
        if (spawningWaves == 4)
        {
            DiedOrSpawned();
        }

        if (enemies.Length == 0)
        {
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
        }
        else 
        {
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().EnableHUD();
        }*/
    }

    private void DiedOrSpawned()
    {
       /* if (enemyDied || spawned)
        {
            StartCoroutine(ExecuteAfterTime(1));
            enemyDied = false;
            spawned = false;
        }*/
    }

    /*IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        DetectEnemies();
    }*/

    // Array that detects the active enemies in scene
    public void DetectEnemies()
    {
        // Detect all enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // All enemies recover its initial color
        PaintItWhite();
        // Displaying data of one of the spawned enemies in Enemy Canvas Panel
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
        print("en SelectEnemy");
        // Selecting an enemy in enemies array to display in Enemy Canvas Panel
        int index = Random.Range(0, enemies.Length);
        enemySelected = enemies[index];
        // Turning blue to highlight the chosen enemy
        enemySelected.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        // Showing enemySelected data in PanelEnemy
        GameObject.Find("PanelEnemy").GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);
        // By default, BlueGhost will attack to the enemySelected
        GetComponent<EnemySelectedManager>().EnemySelected(enemySelected);
    }
    /*public void SpawningWaves(int ammount)
    {
        spawningWaves += ammount;
    }*/
}
                
