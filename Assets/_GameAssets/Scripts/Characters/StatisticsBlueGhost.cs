using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsBlueGhost : StatisticsCharacter
{
    protected void Awake()
    {
        characterName = "Blue Ghost";
        characterConcept = "Night Vigilante";

        constitution = 15;
        dexterity = 16;
        intelligence = 13;
        power = 14; 
        size = 15;
        strength = 14;

        fist = 76;
        kick = 73;
        medicine = 70;
        throwing = 70;
        shot = 75;

        damageBonus = strength + size;
        dodge = dexterity * 2;
        hitPointsMax = constitution + size;
        hitPoints = hitPointsMax;
        luck = power * 5;
        sanityMax = power * 5;
        sanity = sanityMax;
    }
}
