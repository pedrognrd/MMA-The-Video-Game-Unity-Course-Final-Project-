using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    /*private int attackRoll;
    private int criticalMod;
    private int damage;
    private int damageMax;
    private int damageMin;
    private int hitEffect;
    private int impact;
    private GameObject enemyCharacter; 
    private GameObject panelEnemy;
    private GameObject textEvent1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InflictingDamage()
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
    }*/
}
