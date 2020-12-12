using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSequenceManager : MonoBehaviour
{
    // THIS CLASS CONTROLS THE TURN SEQUENCE AS FOLLOWS
    /// <summary>
    /// - Choose player
    ///     - If Blue Ghost First
    ///         - Blue Ghost Turn
    ///             - Choose Blue Ghost action
    ///             - Select enemy
    ///             - Play Blue Ghost action
    ///         - Enemy Turn
    ///             - Select enemy
    ///             - Choose Random Enemy action
    ///             - Play Random Enemy action
    ///         - End turn sequence
    ///         
    ///     - If Enemy First
    ///         - Enemy Turn
    ///             - Select enemy
    ///             - Choose Random Enemy action
    ///             - Play Random Enemy action
    ///         - Blue Ghost Turn
    ///             - Choose Blue Ghost action
    ///             - Select enemy
    ///             - Play Blue Ghost action
    ///         - End turn sequence
    ///         
    /// - If there are more enemies
    ///     - Turn counter ++
    ///     - New Turn Sequence
    /// - If there are no mor enemies
    ///     - Continue Walking
    /// </summary>

    // Store both kind of players in game
    [Header("Players and who's first in turn order")]
    public string[] players = new string[] { "BlueGhost", "Enemy" };
    // Will define who acts first in each turn
    public string whoIsFirst;
    [Header("Enemy selected")]
    // Enemy selected for each turn
    public GameObject enemySelected;
    //public bool enemyDied;

    [Header("Control of players actions")]
    // Define if hero had played the turn action
    public bool playerHeroPlayed;
    // Define if enemy had played the turn action
    public bool playerEnemyPlayed;

    // Controls if turn sequence is done
    // False --> playing
    // True  --> played
    public bool turnSequenceDone;


    private void Awake()
    {
        turnSequenceDone = true;
    }

    private void Update()
    {
        if (!turnSequenceDone)
        {
            // Cleaning console
            GetComponent<GameManager>().ClearLog();
            print("Starting new Combat Sequence");
            print("Enemies spawned " + GetComponent<SpawnedEnemiesDetector>().enemiesInGame);
            // Select who is first to play the turn
            WhoIsFirst();
            // Playing action of the first to play
            FirstToPlay();
            turnSequenceDone = true;
        }
    }

    public void FirstToPlay()
    {
        print("Detecting enemies in scene");
        GetComponent<SpawnedEnemiesDetector>().DetectEnemies();
        if (whoIsFirst == "BlueGhost")
        {
            print("Enabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().EnableHUD();
            print("Waiting till Blue Ghost plays its turn");
        }
        if (whoIsFirst == "Enemy")
        {
            print("Disabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            print("Selecting enemy");
            EnemyPlays();
        }
    }

    public void SecondToPlay() 
    {
        print("Second to play");
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

    public void WhoIsFirst()
    {
        // Selecting Hero or Enemy to play first in Turn Sequence
        whoIsFirst = players[Random.Range(0, players.Length)];
        print("whoIsFirst " + whoIsFirst);
    }
}
