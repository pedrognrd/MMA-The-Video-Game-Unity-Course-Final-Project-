using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// TODO: Create turn sequence
    /// </summary>

    [Header("Elements in Canvas")]
    private GameObject textEvent1;
    private GameObject textEvent2;
    //public GameObject panelHero;
    //public GameObject panelEnemy;
    [Header("Players and who's first in turn order")]
    public string[] players = new string[] { "BlueGhost", "Enemy" };
    // Define the enemy selected after a spawning or a dead
    public bool enemySelected;
    // Define who acts first in each turn
    public string whoIsFirst;
    // Define if hero had played the turn action
    public bool playerHeroPlayed;
    public bool playerHeroActionDone;
    // Define if enemy had played the turn action
    public bool playerEnemyPlayed;
    public bool playerEnemyActionDone;

    public int turnCounter = 0;

    protected virtual void Awake()
    {
        ClearLog();
        enemySelected = false;
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        //panelHero = GameObject.Find("PanelHero");
        //panelEnemy = GameObject.Find("PanelEnemy");
        // Initializing turn manager variables
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Save the city, Blue Ghost!");
        cleanTurn();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        // TODO control enemySelected to start a turn sequence
        if (enemySelected)
        {
            WhoIsFirst();
            turnSequence();
        }

        if (playerHeroActionDone) 
        {
            playerHeroPlayed = true;
            if (whoIsFirst == "BlueGhost")
            {
                GetComponent<EnemySelectedManager>().chooseAttack();
                WhoIsFirst();
                turnSequence();
            }
        }

        if(playerEnemyActionDone)
        {
            playerEnemyPlayed = true;
        }

        if (playerHeroPlayed && playerEnemyPlayed)
        {
            // TODO: CLEAN TURN after seconds
            print("cleaning turn");
            cleanTurn();
            enemySelected = true;
        }
    }

    private void cleanTurn()
    {
        //WhoIsFirst();

        playerHeroPlayed = false;
        playerHeroActionDone = false;
        playerEnemyPlayed = false;
        playerEnemyActionDone = false;
        turnCounter++;
        textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Turn " + turnCounter);
    }

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    public void turnSequence() 
    {
        // Enemy attack first if is the chosen in whoIsFirst
        if (whoIsFirst == "Enemy")
        {
            GetComponent<EnemySelectedManager>().chooseAttack();
        }
    }

    public void WhoIsFirst() 
    {
        // Selecting Hero or Enemy to play first in Turn Sequence
        whoIsFirst = players[Random.Range(0, players.Length)];
        print("whoIsFirst " + whoIsFirst);
        enemySelected = false;
    }
}
