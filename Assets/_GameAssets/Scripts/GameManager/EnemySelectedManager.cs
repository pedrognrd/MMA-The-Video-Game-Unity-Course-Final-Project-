using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectedManager : MonoBehaviour
{
    // THIS CLASS CONTROLS THE SELECTED ENEMY
    private GameObject panelEnemyManager;
    private GameObject blueGhost;
    public GameObject enemySelected;
    public string[] enemyAttacks = new string[] { "Melee", "Range" };
    public string attack;
    [Header("Elements in Canvas")]
    private GameObject textEvent1;
    private GameObject textEvent2;

    private void Awake()
    {
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
    }

    public void chooseAttack() 
    {
        attack = enemyAttacks[Random.Range(0, 1)];
        StartCoroutine(EnemyAttack(2));
    }

    IEnumerator EnemyAttack(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        if (enemySelected.layer == 8)
        {
            attack = "Range";
            if (attack == "Melee")
            {
                print("attack melee" + attack);
                enemySelected.GetComponent<DeepOneAttackMelee1>().Attack();
            }
            if (attack == "Range")
            {
                print("attack range " + attack);
                enemySelected.GetComponent<DeepOneWeaponRange1>().Attack();
            }
        }

        if (enemySelected.layer == 9)
        {
            if (attack == "Melee")
            {
                enemySelected.GetComponent<DagonAttackMelee1>().Attack();
            }
            else
            {
                enemySelected.GetComponent<DagonWeaponRange1>().Attack();
            }
        }
        // If Blue Ghost was the first to play, the turn sequence is finished
        if (GameObject.Find("GameManager").GetComponent<TurnSequenceManager>().whoIsPlaying == "BlueGhost")
        {
            print("Disabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            print("final de turno");
            //GetComponent<TurnSequenceManager>().turnSequenceDone = true;
            //GetComponent<TurnSequenceManager>().FinishingTurn();
            StartCoroutine(EnemyFinished(2));
        }
        else 
        {
            print("Enabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().EnableHUD();
            StartCoroutine(EnemyWaiting(2));
        }
    }

    IEnumerator EnemyFinished(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        GetComponent<TurnSequenceManager>().FinishingTurn();
    }

    IEnumerator EnemyWaiting(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Blue Ghost, is your turn!");
    }

    public void Enemydied()
    {
        print("Evaluate if there are more enemies in game");
        GetComponent<TurnSequenceManager>().FinishingTurn();
    }

    public void EnemySelected(GameObject enemySend)
    {
        enemySelected = enemySend;
        // Sending enemySelected data to BlueGhost
        blueGhost = GameObject.Find("BlueGhost");
        blueGhost.GetComponent<BlueGhostAttackMelee1>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostAttackMelee2>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostWeaponRange1>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostWeaponRange2>().UpdatingEnemySelected(enemySelected);
        // Sending enemySelected data to PanelEnemy
        panelEnemyManager = GameObject.Find("PanelEnemy");
        panelEnemyManager.GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);
    }
}
