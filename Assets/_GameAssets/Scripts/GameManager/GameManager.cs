using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

public class GameManager : MonoBehaviour
{
    [Header("Elements in Canvas")]
    private GameObject textEvent1;
    private GameObject textEvent2;
    /*// Define if hero had played the turn action
    public bool playerHeroPlayed;
    public bool playerHeroActionDone;
    // Define if enemy had played the turn action
    public bool playerEnemyPlayed;
    public bool playerEnemyActionDone;*/
    public int turnCounter = 0;

    protected virtual void Awake()
    {
        ClearLog();
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        // Initializing turn manager variables
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Save the city, Blue Ghost!");
        cleanTurn();
    }

    private void Update()
    {
        // TODO control enemySelected to start a turn sequence
       /* if (enemySelected)
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
        }*/

        /*if(playerEnemyActionDone)
        {
            playerEnemyPlayed = true;
        }

        if (playerHeroPlayed && playerEnemyPlayed)
        {
            // TODO: CLEAN TURN after seconds
            print("cleaning turn");
            cleanTurn();
            //enemySelected = true;
        }*/
    }

    private void cleanTurn()
    {
        //WhoIsFirst();

        /*playerHeroPlayed = false;
        playerHeroActionDone = false;
        playerEnemyPlayed = false;
        playerEnemyActionDone = false;*/
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
        /*if (whoIsFirst == "Enemy")
        {
            GetComponent<EnemySelectedManager>().chooseAttack();
        }*/
    }
}
