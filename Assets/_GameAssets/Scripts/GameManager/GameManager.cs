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
    /// - Text: New turn 
    /// - Select randomly who starts the turn
    ///     - Clean panel texts of the second player
    /// - Play actions of first to play (player or each enemy)
    ///     - Select action/s
    ///     - Execute action/s
    /// - Play actions of second to play (player or each enemy)
    ///     - Select action/s
    ///     - Execute action/s
    /// - Turn counter ++
    /// - If both had played --> New Turn
    /// </summary>
    /// 
    [Header("Elements in Canvas")]
    private GameObject textEvent1;
    private GameObject textEvent2;
    public GameObject panelHero;
    public GameObject panelEnemy;
    [Header("Players and who's first in turn order")]
    public string[] players = new string[] { "BlueGhost", "Enemy" };
    public string whoIsFirst;
    public bool playerHeroPlayed;
    public bool playerHeroActionDone; 
    public bool playerEnemyPlayed;
    public bool playerEnemyActionDone;

    private int turnCounter = 0;

    protected virtual void Awake()
    {
        ClearLog();
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        panelHero = GameObject.Find("PanelHero");
        panelEnemy = GameObject.Find("PanelEnemy");
        // Initializing turn manager variables
        cleanTurn();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (playerHeroActionDone) 
        {
            playerHeroPlayed = true;
        }

        if(playerEnemyActionDone)
        {
            playerEnemyPlayed = true;
        }

        if (playerHeroPlayed && playerEnemyPlayed)
        {
            cleanTurn();
        }
    }

    private void cleanTurn()
    {
        panelHero.SetActive(false);
        panelEnemy.SetActive(false);
        whoIsFirst = players[Random.Range(0, players.Length)];
        print("whoIsFirst " + whoIsFirst);
        WhoIsFirst();

        playerHeroPlayed = false;
        playerHeroActionDone = false;
        playerEnemyPlayed = false;
        playerEnemyActionDone = false;
        turnCounter++;
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Save the city, Blue Ghost!");
        textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Turn " + turnCounter);
    }

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    private void WhoIsFirst() 
    {
        if (whoIsFirst == "BlueGhost")
        {
            panelHero.SetActive(true);
            panelEnemy.SetActive(false);
        }
        if (whoIsFirst == "Enemy")
        {
            panelHero.SetActive(false);
            panelEnemy.SetActive(true);
        }
    }
}
