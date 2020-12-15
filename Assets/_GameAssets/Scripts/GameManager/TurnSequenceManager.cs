using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TurnSequenceManager : MonoBehaviour
{
    // THIS CLASS CONTROLS THE TURN SEQUENCE AS FOLLOWS
    [SerializeField]
    public GameObject panelCombatManager;
    // Store both kind of players in game
    [Header("Players and who's first in turn order")]
    public string[] players = new string[] { "Blue Ghost", "Enemy" };
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
        // Increase turn counter in emerging text
        GetComponent<CombatManager>().turnCounter++;
        // Increase turn in Panel Combat Panel
        GameObject.Find("PanelCombat").GetComponent<PanelCombatManager>().turn++;
        // Starting new Combat Sequence
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
        // Displaying Enemy Data in Panel Combat
        panelCombatManager.GetComponent<PanelCombatManager>().DisplayCombatPanelInfo(enemySelected);
        // Changing 2D lights to focus on enemy
        LightFocusCharacterPlaying(enemySelected);
        // Showing enemySelected data in PanelEnemy
        GameObject.Find("PanelEnemy").GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);
        // By default, BlueGhost will attack to the enemySelected
        GetComponent<EnemySelectedManager>().EnemySelected(enemySelected);
        // Enemy selected plays its action
        GetComponent<EnemySelectedManager>().chooseAttack();
    }

    public void LightFocusCharacterPlaying(GameObject character)
    {
        // Changing 2D lights to focus on characer
        character.GetComponentInChildren<Light2D>().pointLightInnerAngle = 32;
        character.GetComponentInChildren<Light2D>().pointLightOuterAngle = 32;
    }

    public void LightFocusCharacterNotPlaying(GameObject character)
    {
        // Revovering 2D lights to focus on character
        character.GetComponentInChildren<Light2D>().pointLightInnerAngle = 18;
        character.GetComponentInChildren<Light2D>().pointLightOuterAngle = 22;
    }

    public void FirstToPlay()
    {
        // Disabling Blue Ghost buttons panel until player select an enemy
        GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
        // Display Enemy Panel data
        GetComponent<CombatManager>().DisplayEnemyPanelData();
        if (whoPlaysFirst == "BlueGhost")
        {
            // Displaying BlueGhost Data in Panel Combat
            GameObject.Find("PanelCombat").GetComponent<PanelCombatManager>().DisplayCombatPanelInfo(GameObject.Find("BlueGhost"));
            // Changing 2D lights to focus on enemy
            GetComponent<TurnSequenceManager>().LightFocusCharacterPlaying(GameObject.Find("BlueGhost"));
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
        // Revovering 2D lights to focus on character
        GameObject.Find("GameManager").GetComponent<TurnSequenceManager>().LightFocusCharacterNotPlaying(GameObject.Find("BlueGhost"));
        // Revovering 2D lights to focus on character
        GameObject.Find("GameManager").GetComponent<TurnSequenceManager>().LightFocusCharacterNotPlaying(enemySelected);
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
        // Display Emerging texts
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Turn " + GetComponent<CombatManager>().turnCounter);
        textEvent2.GetComponent<PanelTextEventManager>().UpdateText("It is " + whoPlaysFirst + " turn"); 
    }
}
