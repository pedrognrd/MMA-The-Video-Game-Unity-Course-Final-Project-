using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // Choose enemy attack
        attack = enemyAttacks[Random.Range(0, 1)];
        StartCoroutine(EnemyAttack(2));
    }

    IEnumerator EnemyAttack(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        if (enemySelected.layer == 8 && !enemySelected.GetComponent<DeepOneWeaponRange1>().canThrow)
        {
            // Enemy can throw its weapon only once, If done, enemy will do a Range attack
            attack = "Range";
        }
        if (enemySelected.layer == 9 && !enemySelected.GetComponent<DagonWeaponRange1>().canShoot)
        {
            // Enemy can shoot its weapon only once, If done, enemy will do a Range attack
            attack = "Range";
        }
        if (enemySelected.layer == 8 && enemySelected.GetComponent<DeepOneWeaponRange1>().canThrow)
        {
            if (attack == "Melee")
            {
                enemySelected.GetComponent<DeepOneAttackMelee1>().Attack();
                EvaluateAttack();
            }
            if (attack == "Range")
            {
                enemySelected.GetComponent<DeepOneWeaponRange1>().Attack();
                EvaluateAttack();
            }
        }
        if (enemySelected.layer == 9 && enemySelected.GetComponent<DagonWeaponRange1>().canShoot)
        {
            if (attack == "Melee")
            {
                enemySelected.GetComponent<DagonAttackMelee1>().Attack();
                EvaluateAttack();
            }
            if (attack == "Range")
            {
                // TODO: Summoning spells. Enemy will be available to summoning each 5 turns
                enemySelected.GetComponent<DagonAttackMelee1>().Attack();
                EvaluateAttack();
            }
        }
    }

    private void EvaluateAttack()
    {
        // If Blue Ghost was the first to play, the turn sequence is finished
        if (GameObject.Find("GameManager").GetComponent<TurnSequenceManager>().whoPlaysFirst == "BlueGhost")
        {
            // Disabling Blue Ghost buttons panel
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            // End of turn
            StartCoroutine(EnemyFinished(2));
        }
        else
        {
            // Disabling Blue Ghost buttons panel
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            // Enabling Blue Ghost buttons panel
            //GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().EnableHUD();
            StartCoroutine(EnemyWaiting(2));
        }
    }

    IEnumerator EnemyFinished(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        // All enemies recover its original color
        GameObject.Find("GameManager").GetComponent<SpawnedEnemiesDetector>().PaintItWhite();
        GetComponent<TurnSequenceManager>().FinishingTurn();
    }

    IEnumerator EnemyWaiting(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        // All enemies recover its original color
        GameObject.Find("GameManager").GetComponent<SpawnedEnemiesDetector>().PaintItWhite();
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Blue Ghost, is your turn!");
    }

    public void Enemydied()
    {
        // Evaluate if there are more enemies in game");
        GetComponent<TurnSequenceManager>().FinishingTurn();
    }

    public void EnemySelected(GameObject enemySend)
    {
        enemySelected = enemySend;
        print("enemySelected.name " + enemySelected.name);
        // Sending enemySelected data to BlueGhost
        blueGhost = GameObject.Find("BlueGhost");
        blueGhost.GetComponent<BlueGhostAttackMelee1>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostAttackMelee2>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostWeaponRange1>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostWeaponRange2>().UpdatingEnemySelected(enemySelected);
        // Sending enemySelected data to PanelEnemy
        panelEnemyManager = GameObject.Find("PanelEnemy");
        panelEnemyManager.GetComponent<PanelEnemyManager>().DisplayAvatar(enemySelected);
        panelEnemyManager.GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);
    }
}
