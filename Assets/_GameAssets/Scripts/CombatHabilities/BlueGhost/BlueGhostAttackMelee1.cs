using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhostAttackMelee1 : CombatSkills
{

    // TODO: Attack Animation
    // TODO: If enemy dies, make animation
    // TODO: Update HUD
    // TODO: Update threat level
    // TDOO: Update Arkham threat level

    GameObject textEvent1;
    GameObject enemyCharacter;
    GameObject panelEnemy;
    protected void Awake()
    {
        LoadingStatistics();
        LoadingGameObjects();
    }


    // Start is called before the first frame update
    void Start()
    {
        damageMax += GetComponent<StatisticsBlueGhost>().damageBonus;
        damageMin += GetComponent<StatisticsBlueGhost>().damageBonus;
        // If impact value is lower than throwing character's hability value
        if (impact < character.GetComponent<StatisticsCharacter>().throwing)
        {
            impact = character.GetComponent<StatisticsCharacter>().throwing;
        }
    }

    private void LoadingGameObjects()
    {
        // Capturing GameObjects
        textEvent1 = GameObject.Find("TextEvent1");
        enemyCharacter = GameObject.Find("DeepOne");
        panelEnemy = GameObject.Find("PanelEnemy");
    }

    private void LoadingStatistics()
    {
        // Defining weapon statistics
        ammo = -1; // -1 = infinite
        chargers = -1; // -1 = infinite
        criticalMod = -5;
        // Add character damageBonus
        damageMax = 4;
        damageMin = 1;
        distance = 1; // When the character increase its level, distanci will be higer
        hitEffect = 0; // 0 = none, 1 = bleeding, 2 = move, 3 = stun
        impact = 50;
        kind = 1; // 1 = melee, 2 = range, 3 = magic
    }

    public override void Attack()
    {
        // Using weapon, a message is shown in screen
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Indigo Fist");
        // A percentual roll is made
        attackRoll = Random.Range(1, 100);
        // If the percentual roll is lower than impact value, the attack is a success
        if (attackRoll < impact)
        {
            InflictDamage();
            // Is the enemy dead?
            if (enemyCharacter.GetComponent<StatisticsDeepOne>().hitPoints <= 0)
            {
                textEvent1.GetComponent<PanelTextEventManager>().UpdateText(enemyCharacter.GetComponent<StatisticsDeepOne>().characterName + " is dead");
                Destroy(enemyCharacter);
            }
            // Apply weapon effects if have it
            // Substract ammo if have it
        }
        else
        {
            // The attack is a failed, a message is shown in screen
            textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Attack Failed");
        }
    }

    private void InflictDamage()
    {
        // If the attackRoll is a 20% of the impact value, the attack is a critical attack
        if (attackRoll < ((impact * 20) / 100) + criticalMod)
        {
            // With critical attack the weapon inflicts its maximum damage
            damage = damageMax;
            // it causes stun effect
            hitEffect = 3;
        }
        else
        {
            // With normal attack the weapon inflicts a random range of damage
            damage = Random.Range(damageMin, damageMax);
        }
        // Instantiate flying points
        enemyCharacter.GetComponent<FlyingPointsManager>().InstantiateFlyingPoints(damage);
        // damage is subtracted from enemy hitPoints
        enemyCharacter.GetComponent<StatisticsDeepOne>().hitPoints -= damage;
        // Update hitPoints in Enemy HUD
        panelEnemy.GetComponent<PanelEnemyManager>().UpdateHitPoints(damage);
    }
}
