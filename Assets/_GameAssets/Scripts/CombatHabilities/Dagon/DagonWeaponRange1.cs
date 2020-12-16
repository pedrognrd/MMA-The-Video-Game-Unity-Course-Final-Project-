using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagonWeaponRange1 : CombatSkills
{
    // TODO: The hat will be thrown at the selected enemy
    // TODO: If enemy dies, make animation
    // TODO: Update HUD
    // TODO: Update threat level
    // TDOO: Update Arkham threat level

    public int damageBonus;
    public int spawnNumber;
    private int minEnemies = 1;
    private int maxEnemies = 3;

    protected override void Awake()
    {
        base.Awake();
        // Capturing Interactive GameObjects
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        //canShoot = GetComponent<CombatSkills>().canShoot;
        //canShoot = true;
        LoadingStatistics();
        enemyCharacter = GameObject.Find("BlueGhost");
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
        // there is no ammo, DeepOne only throws one spear and it is controlled with canThrow in EnemyManager
        ammo = -1; // -1 = infinite
        chargers = -1; // -1 = infinite
        criticalMod = -5;
        damageMax = 6;
        damageMin = 1;
        distance = 8; // When the character increase its level, distanci will be higer
        hitEffect = 2; // 0 = none, 1 = bleeding, 2 = move, 3 = stun
        impact = 60;
        kind = 2; // 1 = melee, 2 = range, 3 = magic
    }

    public override void Attack()
    {
        // play attack sound
        characterSM.PlayAudioThrow();
        // Play Range1 animation
        GetComponent<CharacterAnimations>().Range1();
        if (canShoot)
        {
            // Using weapon, a message is shown in screen
            textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Children, come to me!");
            textEvent1.GetComponent<PanelTextEventManager>().UpdateText("");
            // A percentual roll is made
            attackRoll = Random.Range(1, 100);
            attackRoll = 1;

            // If the percentual roll is lower than impact value, the attack is a success
            if (attackRoll <= impact)
            {
                // Calculate the damage done
                InflictDamage();
                // TODO: Apply weapon effects if have it
            }
            if (attackRoll > impact)
            {
                // Using weapon, a message is shown in screen
                textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Summoning cast fails!");
            }
            // DeepOne will no longer be able to throw Spear
            canShoot = false;
        }
        else
        {
            // TODO: Delete when random attack enemy will be done
            textEvent1.GetComponent<PanelTextEventManager>().UpdateText("No more spells!");
        }
    }

    private void InflictDamage()
    {
        spawnNumber = Random.Range(minEnemies, maxEnemies);
        print("spawning enemies");
        GameObject.Find("DagonSpawner").GetComponent<SpawnerEnemies>().SpawnEnemies(spawnNumber);
    }
}