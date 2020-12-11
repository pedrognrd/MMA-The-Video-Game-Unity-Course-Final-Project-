using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectedManager : MonoBehaviour
{
    // THIS CLASS CONTROLS THE SELECTED ENEMY
    GameObject panelEnemyManager;
    GameObject blueGhost;
    GameObject enemySelected;
    public string[] enemyAttacks = new string[] { "Melee", "Range" };
    public string attack;

    public void chooseAttack() 
    {
        attack = enemyAttacks[Random.Range(0, 1)];
        StartCoroutine(EnemyAttack(4));
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

        GetComponent<GameManager>().playerEnemyActionDone = true;
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
