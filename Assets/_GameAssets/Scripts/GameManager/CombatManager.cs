using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void NewCombat()
    {
        print("newTurn can happen after spawning enemies or after first turn sequence finished");
        StartCoroutine(StartingNewCombat(2));
    }

    IEnumerator StartingNewCombat(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        //GetComponent<TurnSequenceManager>().turnSequenceDone = false;
        GetComponent<TurnSequenceManager>().NewTurn();
    }

    public void CombatEnds()
    {
        print("Combat ends when there are enemies in game");
        StartCoroutine(FinishingCombatEnds(2));
    }

    IEnumerator FinishingCombatEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        print("Cleaning turnCounter");
        turnCounter = 0;
        textEvent1.GetComponent<PanelTextEventManager>().UpdateText("Combat finished, continue walking");
    }
}
