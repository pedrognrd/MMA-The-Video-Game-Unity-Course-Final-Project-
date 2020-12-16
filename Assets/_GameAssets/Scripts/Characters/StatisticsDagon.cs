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
        characterName = "Father Dagon";
        characterConcept = "Server of Cthulhu";
        characterDescription = "Deity who presides over the Deep Ones. Also known as Father Dagon and the consort of Mother Hydra, although they are Deities, they are generally not considered Great Old Ones.";
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
        // FOR TESTING PURPOSES
        hitPoints = 40;
        hitPointsMax = 40;
        // FOR TESTING PURPOSES
    }
}
