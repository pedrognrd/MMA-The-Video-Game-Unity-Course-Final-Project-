using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsDeepOne : StatisticsCharacter
{
    [Header("SANITY LOSS")]
    [Range(0, 6)]
    public int sanityLoss;
    protected void Awake()
    {
        characterName = "Deep One";
        characterConcept = "Server of Dagon";
        characterDescription = "Humanoid beings with fish, human and amphibian-like traits. They have scaled, ridged backs, as well as webbed hands and gilled necks. Notably, they have a head similar to that of a fish, with eyes incapable of blinking.";

        constitution = 10;
        dexterity = 10;
        intelligence = 13;
        power = 10;
        size = 16;
        strength = 14;

        fist = 25;
        throwing = 25;

        damageBonus = (strength + size) / 4;
        dodge = dexterity * 2;
        hitPointsMax = constitution + size;
        hitPoints = hitPointsMax;
    }
}
