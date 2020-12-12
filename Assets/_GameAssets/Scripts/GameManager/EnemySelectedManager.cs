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
            if (attack == "Melee")
            {
                print("attack melee" + attack);
                enemySelected.GetComponent<DeepOneAttackMelee1>().Attack();
            }
            else
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
        if (GameObject.Find("GameManager").GetComponent<TurnSequenceManager>().whoIsFirst == "BlueGhost")
        {
            print("Disabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            print("final de turno");
            GetComponent<TurnSequenceManager>().turnSequenceDone = true;
        }
        else 
        {
            print("Enabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().EnableHUD();
            print("Waiting till Blue Ghost plays its turn");
        }
    }

    public void Enemydied()
    {
        if (GetComponent<SpawnedEnemiesDetector>().enemiesInGame > 0)
        {
            print("Starting new turn sequence");
            GetComponent<TurnSequenceManager>().turnSequenceDone = true;
            GetComponent<TurnSequenceManager>().turnSequenceDone = false;
        }
        if (GetComponent<SpawnedEnemiesDetector>().enemiesInGame == 0)
        {
            print("Combat Sequence Finished ");
            GetComponent<TurnSequenceManager>().turnSequenceDone = true;
        }
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
