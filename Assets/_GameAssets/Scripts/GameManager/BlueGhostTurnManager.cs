using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhostTurnManager : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        // Disabling Blue Ghost buttons panel
        GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
    }

    public void BlueGhostAttacked()
    {
        // If Blue Ghost was the first to play, enemy can play
        if (GetComponent<TurnSequenceManager>().whoPlaysFirst == "BlueGhost")
        {
            GetComponent<TurnSequenceManager>().EnemyPlays();
        }
        else
        {
            // Evaluate if there are more enemies in game
            StartCoroutine(BlueGhostFinished(2));
        }
    }

    IEnumerator BlueGhostFinished(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        GetComponent<TurnSequenceManager>().FinishingTurn();
    }
}
