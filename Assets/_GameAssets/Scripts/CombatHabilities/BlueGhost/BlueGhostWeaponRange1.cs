using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhostWeaponRange1 : CombatSkills
{
    // TODO: The hat will be thrown at the selected enemy
    // TODO: If enemy dies, make animation
    // TODO: Update HUD
    // TODO: Update threat level
    // TDOO: Update Arkham threat level

    protected override void Awake()
    {
        base.Awake();
        LoadingStatistics();
    }

    // Start is called before the first frame update
    void Start()
    {
        // If impact value is lower than throwing character's hability value
        if (impact < character.GetComponent<StatisticsCharacter>().throwing)
        {
            impact = character.GetComponent<StatisticsCharacter>().throwing;
        }
    }

    private void LoadingStatistics()
    {
        // Defining weapon statistics
        ammo = -1; // -1 = infinite
        chargers = -1; // -1 = infinite
        criticalMod = -5;
        damageMax = 12;
        damageMin = 8;
        distance = 10; // When the character increase its level, distanci will be higer
        hitEffect = 0; // 0 = none, 1 = bleeding, 2 = move, 3 = stun
        impact = 60;
        kind = 2; // 1 = melee, 2 = range, 3 = magic
    }

    public override void Attack()
    {
        // Play Range1 animation
        GetComponent<CharacterAnimations>().Range1();
        // Using weapon, a message is shown in screen
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Throwing Blue Hat");
        // A percentual roll is made
        attackRoll = Random.Range(1, 100);
        // If the percentual roll is lower than impact value, the attack is a success
        if (attackRoll <= impact)
        {
            // Calculate the damage done
            InflictDamage();
            // Play Damage enemy animation
            //enemyCharacter.GetComponent<CharacterAnimations>().Damage();
            // Apply a delay for the enemy damage animation
            Invoke("InvokeDamage", 1.0f);
            // Apply weapon effects if have it
            // Substract ammo if have it
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

    private void InvokeDamage()
    {
        // Play Damage enemy animation
        enemyCharacter.GetComponent<CharacterAnimations>().Damage();
    }

    private void InflictDamage()
    {
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