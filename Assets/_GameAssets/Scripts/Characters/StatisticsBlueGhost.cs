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

        fist = 82;
        kick = 72;
        medicine = 70;
        throwing = 74;
        shot = 84;

        damageBonus = (strength + size) / 4;
        dodge = dexterity * 2;
        hitPointsMax = constitution + size;
        hitPoints = hitPointsMax;
        sanityMax = power * 5;
        sanity = sanityMax;
    }
}
