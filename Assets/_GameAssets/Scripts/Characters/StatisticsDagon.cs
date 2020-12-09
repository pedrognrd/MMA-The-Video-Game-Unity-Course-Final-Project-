using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsDagon : StatisticsCharacter
{
    [Header("SANITY LOSS")]
    [Range(1, 10)]
    public int sanityLoss;
    protected void Awake()
    {
        characterName = "Dagon, Great Old One";
        characterConcept = "Server of Cthulhu";

        constitution = 50;
        dexterity = 20;
        intelligence = 20;
        power = 30;
        size = 60;
        strength = 52;

        fist = 80;
        shoot = 40; // uses shot for summoning skills

        damageBonus = (strength + size) / 4;
        dodge = dexterity * 2;
        hitPointsMax = constitution + size;
        hitPoints = hitPointsMax;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<DagonAttackMelee1>().Attack();
        }
       if (Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<DagonWeaponRange1>().Attack();
        }
    }
}
