using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingHat : CombatSkill
{
    protected void Awake()
    {
        ammo = -1; // -1 = infinite
        criticalMod = -5;
        damageMax = 12;
        damageMin = 8;
        distance = 10; // When the character increase its level, distanci will be higer
        hitEffect = 0; // 0 = none, 1 = bleeding, 2 = criticalHit, 3 = move, 4 = stun
        impact = 60;
        kind = 2; // 1 = melee, 2 = distance, 3 = magic
    }

    // Start is called before the first frame update
    void Start()
    {
        // If impact value is lower than throwing character's hability value
        if (impact < character.GetComponent<StatisticsCharacter>().throwing) {
            impact = character.GetComponent<StatisticsCharacter>().throwing;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO: The hat will be thrown at the selected enemy
    // TODO: If enemy dies, take animation
    // TODO: Update HUD
    // TODO: Update threat level
    // TDOO: Update Arkham threat level
    public override void Attack()
    {
        GameObject.Find("TextCurrentEvent").GetComponent<PanelTextCurrentEventManager>().UpdateText("Throwing hat");
        // A percentual roll is made
        attackRoll = Random.Range(1, 100);
        // If the percentual roll is lower than impact value, the attack is a success
        if (attackRoll < impact)
        {
            // If the attackRoll is a 20% of the impact value, the attack is a critical attack
            if (attackRoll < ((impact * 20) / 100) + criticalMod)
            {
                // With critical attack the weapon inflicts its maximum damage
                damage = damageMax;
            }
            else {
                // With normal attack the weapon inflicts a random range of damage
                damage = Random.Range(damageMin, damageMax);
            }
            // damage is subtracted from enemy hitPoints
            GameObject.Find("DeepOne").GetComponent<StatisticsDeepOne>().hitPoints -= damage;
            // Update hitPoints in Enemy HUD
            GameObject.Find("PanelEnemy").GetComponent<PanelEnemyManager>().UpdateHitPoints(damage);
            // Is the enemy dead?
            if (GameObject.Find("DeepOne").GetComponent<StatisticsDeepOne>().hitPoints < 0)
            {
                print("Enemy is dead");
                //Destroy(GameObject.Find("DeepOne"));
            }
            // Apply weapon effects if have it
            // Substract ammo if have it
        }
        else {
            // The attack is a failed
            print("Attack failed " + attackRoll);
        }
    }
}
