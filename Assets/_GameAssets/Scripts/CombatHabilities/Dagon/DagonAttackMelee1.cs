using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagonAttackMelee1 : CombatSkills
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
        enemyCharacter = GameObject.Find("BlueGhost");
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
        criticalMod = 0;
        // Add character damageBonus
        damageMax = 30;
        damageMin = 7;
        distance = 1; // When the character increase its level, distanci will be higer
        hitEffect = 2; // 0 = none, 1 = bleeding, 2 = move, 3 = stun
        impact = 50;
        kind = 1; // 1 = melee, 2 = range, 3 = magic
    }

    public override void Attack()
    {
        // Using weapon, a message is shown in screen
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Claw of Dagon!");
        // A percentual roll is made
        attackRoll = Random.Range(1, 100);
        // If the percentual roll is lower than impact value, the attack is a success
        if (attackRoll <= impact)
        {
            InflictDamage();
            // Apply weapon effects if have it
        }
        else
        {
            // The attack is a failed, a message is shown in screen
            textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Attack Failed");
        }
    }

    private void InflictDamage()
    {
        // There is damageBonus in Melee Skills
        damageBonus = GetComponent<StatisticsDagon>().damageBonus;
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
        // Update hitPoints in Hero HUD
        panelHero.GetComponent<PanelHeroManager>().UpdateHitPoints(damage);
        // damage is subtracted from enemy hitPoints
        enemyCharacter.GetComponent<StatisticsBlueGhost>().DamageReceived(damage);
    }
}
