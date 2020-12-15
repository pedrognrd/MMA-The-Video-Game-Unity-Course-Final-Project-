using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [Header("Elements in Canvas")]
    private GameObject textEvent1;
    private GameObject textEvent2;

    public int turnCounter = 0;

    protected virtual void Awake()
    {
        // Capturing text fields and panels of the Canvas
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        // Initializing turn manager variables
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Save the city, Blue Ghost!");
        textEvent2.GetComponent<PanelTextEventManager>().UpdateText("Dagon is at the end of the street!");
        // Hide Enemy Panel data
        HideEnemyPanelData();
        GameObject.Find("PanelCombatSkillsInfo").GetComponent< PanelHeroSkillsManager >().hideWeaponsInfo();
    }

    public void CombatEnds()
    {
        // Combat ends when there are no enemies in game
        StartCoroutine(FinishingCombatEnds(2));
        // Display default enemy avatar
        GameObject.Find("AvatarEnemyDefault").GetComponent<Image>().enabled = true;
        GameObject.Find("AvatarEnemyDeepOne").GetComponent<Image>().enabled = false;
        GameObject.Find("AvatarEnemyDagon").GetComponent<Image>().enabled = false;
        // Cleaning Panel Combat Panel
        GameObject.Find("PanelCombat").GetComponent<PanelCombatManager>().CleaningCombatPanel();
    }

    IEnumerator FinishingCombatEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        // Hide Enemy Panel data
        HideEnemyPanelData();
        // Cleaning turnCounter
        turnCounter = 0;
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Combat finished, continue walking");
    }

    public void DisplayEnemyPanelData()
    {
        // Display Enemy Panel data
        GameObject.Find("EnemyName").GetComponent<Text>().enabled = true;
        GameObject.Find("EnemyDescription").GetComponent<Text>().enabled = true;
        GameObject.Find("DamageBonus").GetComponent<Text>().enabled = true;
        GameObject.Find("EnemyConcept").GetComponent<Text>().enabled = true;
        GameObject.Find("EnemyHitPoints").GetComponent<Text>().enabled = true;
        GameObject.Find("AvatarEnemyLife").GetComponent<Image>().enabled = true;
        GameObject.Find("MeleeStatistics").GetComponent<Text>().enabled = true;
        GameObject.Find("IconMelee").GetComponent<Image>().enabled = true;
        GameObject.Find("RangeStatistics").GetComponent<Text>().enabled = true;
        GameObject.Find("IconRange").GetComponent<Image>().enabled = true;
    }
    private static void HideEnemyPanelData()
    {
        // Hide Enemy Panel data
        GameObject.Find("EnemyName").GetComponent<Text>().enabled = false;
        GameObject.Find("EnemyDescription").GetComponent<Text>().enabled = false;
        GameObject.Find("DamageBonus").GetComponent<Text>().enabled = false;
        GameObject.Find("EnemyConcept").GetComponent<Text>().enabled = false;
        GameObject.Find("EnemyHitPoints").GetComponent<Text>().enabled = false;
        GameObject.Find("AvatarEnemyLife").GetComponent<Image>().enabled = false;
        GameObject.Find("MeleeStatistics").GetComponent<Text>().enabled = false;
        GameObject.Find("IconMelee").GetComponent<Image>().enabled = false;
        GameObject.Find("RangeStatistics").GetComponent<Text>().enabled = false;
        GameObject.Find("IconRange").GetComponent<Image>().enabled = false;
    }

    public void NewCombat()
    {
        // NewTurn can happen after spawning enemies or after first turn sequence finished
        StartCoroutine(StartingNewCombat(2));
    }

    IEnumerator StartingNewCombat(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        GetComponent<TurnSequenceManager>().NewTurn();
    }
}
