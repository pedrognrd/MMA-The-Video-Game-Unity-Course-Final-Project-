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

    private void Awake()
    {
        enemiesInGame = 0;
    }

    public void DetectEnemies()
    {
        // Array that detects the active enemies in scene
        // Detect all enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // All enemies recover its initial color
        PaintItWhite();
        // Displaying data of one of the spawned enemies in Enemy Canvas Panel
        SelectEnemy();
        // Display Enemy Panel data
        GetComponent<CombatManager>().DisplayEnemyPanelData();
    }

    public void PaintItWhite()
    {
        foreach (GameObject enemy in enemies) 
        {
            enemy.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            //GameObject.Find("GameManager").GetComponent<TurnSequenceManager>().LightFocusCharacterNotPlaying(enemy);
        }
    }

    public void SelectEnemy()
    {
        // Selecting an enemy in enemies array to display in Enemy Canvas Panel
        int index = Random.Range(0, enemies.Length);
        enemySelected = enemies[index];
        // Showing enemySelected data in PanelEnemy
        GameObject.Find("PanelEnemy").GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);
        // By default, BlueGhost will attack to the enemySelected
        GetComponent<EnemySelectedManager>().EnemySelected(enemySelected);
    }
}
                
