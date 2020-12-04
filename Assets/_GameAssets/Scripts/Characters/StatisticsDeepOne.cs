using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsDeepOne : StatisticsCharacter
{
    protected void Awake()
    {
        characterName = "Deep One";
        characterConcept = "Villain";

        constitution = 10;
        dexterity = 10;
        intelligence = 13;
        power = 10;
        size = 16;
        strength = 14;

        fist = 25;
        kick = 00;
        medicine = 70;
        throwing = 25;
        shot = 20;

        damageBonus = strength + size;
        dodge = dexterity * 2;
        hitPointsMax = constitution + size;
        hitPoints = hitPointsMax;
        luck = power * 5;
        sanityMax = power * 5;
        sanity = sanityMax;
    }
}
