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
    public string whoIsPlaying;
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

    // Controls if turn sequence is done
    // False --> playing
    // True  --> played
    //public bool turnSequenceDone;

    private void Awake()
    {
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        //turnSequenceDone = true;
    }

    private void Update()
    {
        /*if (!turnSequenceDone)
        {
            NewTurn();
            turnSequenceDone = true;
        }*/
    }

    public void NewTurn()
    {
        // Cleaning console
        //GetComponent<GameManager>().ClearLog();
        GetComponent<CombatManager>().turnCounter++;
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Turn " + GetComponent<CombatManager>().turnCounter);
        print("Starting new Combat Sequence");
        print("Enemies spawned " + GetComponent<SpawnedEnemiesDetector>().enemiesInGame);
        // Select who is first to play the turn
        WhoIsPlaying();
        // Playing action of the first to play
        FirstToPlay();
    }

    public void EnemyPlays()
    {
        // Select randomly an index from enemies array
        int index = Random.Range(0, GetComponent<SpawnedEnemiesDetector>().enemies.Length);
        print("enemies.Length " + GetComponent<SpawnedEnemiesDetector>().enemies.Length);
        print("index " + index);
        // Selecting an enemy from enemies array
        enemySelected = GetComponent<SpawnedEnemiesDetector>().enemies[index];
        // Turning blue to highlight the chosen enemy
        enemySelected.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        // Showing enemySelected data in PanelEnemy
        GameObject.Find("PanelEnemy").GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);
        // By default, BlueGhost will attack to the enemySelected
        GetComponent<EnemySelectedManager>().EnemySelected(enemySelected);
        // Enemy selected plays its action
        GetComponent<EnemySelectedManager>().chooseAttack();
    }

    public void FirstToPlay()
    {
        print("Detecting enemies in scene");
        GetComponent<SpawnedEnemiesDetector>().DetectEnemies();
        if (whoIsPlaying == "BlueGhost")
        {
            print("Enabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().EnableHUD();
            print("Waiting till Blue Ghost plays its turn");
        }
        if (whoIsPlaying == "Enemy")
        {
            print("Disabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            print("Selecting enemy");
            EnemyPlays();
            //textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Blue Ghost, is your turn");
        }
    }

    public void FinishingTurn() 
    {
        print("After both players play its actions, evaluate if there will be a new turn");
        if (GetComponent<SpawnedEnemiesDetector>().enemiesInGame > 0)
        {
            print("New turn");
            //GetComponent<CombatManager>().NewCombat();
            print("Starting new turn sequence");
            //GetComponent<TurnSequenceManager>().turnSequenceDone = true;
            //GetComponent<TurnSequenceManager>().turnSequenceDone = false; 
            GetComponent<TurnSequenceManager>().NewTurn();
            
        }
        if (GetComponent<SpawnedEnemiesDetector>().enemiesInGame == 0)
        {
            print("Combat Sequence Finished ");
            GetComponent<CombatManager>().CombatEnds();
            //GetComponent<TurnSequenceManager>().turnSequenceDone = true;
        }
    }

    public void WhoIsPlaying()
    {
        // Selecting Hero or Enemy to play first in Turn Sequence
        whoIsPlaying = players[Random.Range(0, players.Length)];
        print("whoIsFirst " + whoIsPlaying);
        textEvent2.GetComponent<PanelTextEventManager>().UpdateText("It is " + whoIsPlaying + " turn"); 
    }
}
