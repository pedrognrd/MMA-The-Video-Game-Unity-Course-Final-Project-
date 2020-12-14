using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSequenceManager : MonoBehaviour
{
    // THIS CLASS CONTROLS THE TURN SEQUENCE AS FOLLOWS
    // Store both kind of players in game
    [Header("Players and who's first in turn order")]
    public string[] players = new string[] { "BlueGhost", "Enemy" };
    // Will define who acts first in each turn
    public string whoPlaysFirst;
    [Header("Enemy selected")]
    // Enemy selected for each turn
    public GameObject enemySelected;
    //public bool enemyDied;

    [Header("Control of players actions")]
    // Define if hero had played the turn action
    public bool playerHeroPlayed;
    // Define if enemy had played the turn action
    public bool playerEnemyPlayed;

    [Header("Elements in Canvas")]
    private GameObject textEvent1;
    private GameObject textEvent2;

    private void Awake()
    {
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
    }

    public void NewTurn()
    {
        GetComponent<CombatManager>().turnCounter++;
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Turn " + GetComponent<CombatManager>().turnCounter);
        // Starting new Combat Sequence
        print("Enemies spawned " + GetComponent<SpawnedEnemiesDetector>().enemiesInGame);
        // Select who is first to play the turn
        WhoIsFirst();
        // Playing action of the first to play
        FirstToPlay();
    }

    public void EnemyPlays()
    {
        // Select randomly an index from enemies array
        int index = Random.Range(0, GetComponent<SpawnedEnemiesDetector>().enemies.Length);
        // Selecting an enemy from enemies array
        enemySelected = GetComponent<SpawnedEnemiesDetector>().enemies[index];
        // All enemies recover its original color
        GetComponent<SpawnedEnemiesDetector>().PaintItWhite();
        // Turning blue to highlight the chosen enemy
        enemySelected.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        //enemySelected.GetComponent<SpriteRenderer>().color = Color.blue;
        // Showing enemySelected data in PanelEnemy
        GameObject.Find("PanelEnemy").GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);
        // By default, BlueGhost will attack to the enemySelected
        GetComponent<EnemySelectedManager>().EnemySelected(enemySelected);
        // Enemy selected plays its action
        GetComponent<EnemySelectedManager>().chooseAttack();
    }

    public void FirstToPlay()
    {
        // Disabling Blue Ghost buttons panel until player select an enemy
        GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
        // Detecting enemies in scene
        GetComponent<SpawnedEnemiesDetector>().DetectEnemies();
        if (whoPlaysFirst == "BlueGhost")
        {
            // Enabling Blue Ghost buttons panel
            //GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().EnableHUD();
            // Waiting till Blue Ghost plays its turn
        }
        if (whoPlaysFirst == "Enemy")
        {
            // Disabling Blue Ghost buttons panel
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            // Selecting enemy
            EnemyPlays();
        }
    }

    public void FinishingTurn() 
    {
        // After both players play its actions, evaluate if there will be a new turn
        if (GetComponent<SpawnedEnemiesDetector>().enemiesInGame > 0)
        {
            // Starting new turn sequence
            GetComponent<TurnSequenceManager>().NewTurn();
            
        }
        if (GetComponent<SpawnedEnemiesDetector>().enemiesInGame == 0)
        {
            // Combat Sequence Finished
            GetComponent<CombatManager>().CombatEnds();
        }
    }

    public void WhoIsFirst()
    {
        // Selecting Hero or Enemy to play first in Turn Sequence
        whoPlaysFirst = players[Random.Range(0, players.Length)];
        print("whoIsFirst " + whoPlaysFirst);
        textEvent2.GetComponent<PanelTextEventManager>().UpdateText("It is " + whoPlaysFirst + " turn"); 
    }
}
