﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhostWeaponRange2 : CombatSkills
{
    // TODO: The gun shots at the selected enemy
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
        // If impact value is lower than shooting character's hability value
        if (impact < character.GetComponent<StatisticsCharacter>().shoot)
        {
            impact = character.GetComponent<StatisticsCharacter>().shoot;
        }
    }

    private void LoadingStatistics()
    {
        // Defining weapon statistics
        ammoMax = 8; // -1 = infinite
        ammo = ammoMax; // -1 = infinite
        chargersMax = 10; // -1 = infinite
        chargers = chargersMax; // -1 = infinite
        criticalMod = -4;
        damageMax = 16;
        damageMin = 10;
        distance = 10; // When the character increase its level, distanci will be higer
        hitEffect = 3; // 0 = none, 1 = bleeding, 2 = move, 3 = stun
        impact = 65;
        kind = 2; // 1 = melee, 2 = range, 3 = magic
    }

    public override void Attack()
    {
        // play attack sound
        characterSM.PlayAudioShoot();
        // Instantiate shot effect prefab
        GetComponent<ThrowingAndShooting>().ShootGun();
        // Play Range2 animation
        GetComponent<CharacterAnimations>().Range2();
        // A percentual roll is made
        attackRoll = Random.Range(1, 100);
        // Substract ammo
        ammo--;
        // If the percentual roll is lower than impact value, the attack is a success
        if (attackRoll <= impact)
        {
            if (ammo >= 0)
            {
                // Using weapon, a message is shown in screen
                textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Shooting Blue Colt");
                textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Ammo Left" + ammo);
                // Calculate the damage done
                InflictDamage();
                // TODO: Apply weapon effects if have it
            }
            else
            {
                if (chargers >= 0)
                {
                    ammo = ammoMax;
                    textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Recharging Blue Colt");
                    textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Ammo Left: " + ammo + "Chargers: " + chargers);
                    chargers--;
                }
                else
                {
                    textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Blue Colt out of Ammo!");
                }
            }
        }
        if (attackRoll > impact)
        {
            if (ammo >= 0)
            {
                // Using weapon, a message is shown in screen
                textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Blue Colt Failed!");
                textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Ammo Left:" + ammo);
                // Enemy will play its defense animation
                enemyCharacter.GetComponent<CharacterAnimations>().Defense();
            }
            else
            {
                if (chargers >= 0)
                {
                    ammo = ammoMax;
                    textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Recharging Blue Colt");
                    textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Ammo Left: " + ammo + "Chargers: " + chargers);
                    chargers--;
                }
                else {
                    textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Blue Colt out of Ammo!");
                }
            }
        }
        GameObject.Find("GameManager").GetComponent<BlueGhostTurnManager>().BlueGhostAttacked();
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