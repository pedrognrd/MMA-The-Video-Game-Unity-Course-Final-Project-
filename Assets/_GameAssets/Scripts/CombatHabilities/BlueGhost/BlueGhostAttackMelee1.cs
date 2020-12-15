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

    public int damageBonus;

    protected override void Awake()
    {
        base.Awake();
        LoadingStatistics();
    }

    // Start is called before the first frame update
    void Start()
    {
        // If impact value is lower than fist character's hability value
        if (impact < character.GetComponent<StatisticsCharacter>().fist)
        {
            impact = character.GetComponent<StatisticsCharacter>().fist;
        }
    }

    private void LoadingStatistics()
    {
        // Defining weapon statistics
        ammo = -1; // -1 = infinite
        chargers = -1; // -1 = infinite
        criticalMod = -5;
        // Add character damageBonus
        damageMax = 8;
        damageMin = 4;
        distance = 1; // When the character increase its level, distanci will be higer
        hitEffect = 0; // 0 = none, 1 = bleeding, 2 = move, 3 = stun
        impact = 50;
        kind = 1; // 1 = melee, 2 = range, 3 = magic
    }

    public override void Attack()
    {
        //InvokeMelee1();
        // Apply a delay for the enemy damage animation
        Invoke("InvokeMelee1", 0.5f);
        // A message is shown in screen
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Indigo Fist");
        // A percentual roll is made
        attackRoll = Random.Range(1, 100);
        // If the percentual roll is lower than impact value, the attack is a success
        if (attackRoll <= impact)
        {
            // Calculate the damage done
            InflictDamage();
            // Apply weapon effects if have it
        }
        else
        {
            // The attack is a failed, a message is shown in screen
            textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Attack Failed");
            // Enemy will play its defense animation
            enemyCharacter.GetComponent<CharacterAnimations>().Defense();
        }
        GameObject.Find("GameManager").GetComponent<BlueGhostTurnManager>().BlueGhostAttacked();
    }

    private void InvokeMelee1()
    {
        // Play Melee1 animation
        GetComponent<CharacterAnimations>().Melee1();
    }

    private void InflictDamage()
    {
        // There is damageBonus in Melee Skills
        damageBonus = GetComponent<StatisticsBlueGhost>().damageBonus;
        // If the attackRoll is a 20% of the impact value, the attack is a critical attack
        if (attackRoll < ((impact * 20) / 100) + criticalMod)
        {
            // With critical attack the weapon inflicts its maximum damage
            damage = damageMax;
        }
        else
        {
            // With normal attack the weapon inflicts a random range of damage
            damage = Random.Range(damageMin, damageMax);
        }
        // Adding damageBonus in Melee Skills
        damage += damageBonus;
        // Update hitPoints in Enemy HUD
        panelEnemy.GetComponent<PanelEnemyManager>().UpdateHitPoints(damage);
        // damage is subtracted from enemy hitPoints
        enemyCharacter.GetComponent<StatisticsCharacter>().DamageReceived(damage);
    }

    public void UpdatingEnemySelected(GameObject hitName)
    {
        // Capturing Enemy to Attack after being selecting
        enemyCharacter = hitName;
    }
}
