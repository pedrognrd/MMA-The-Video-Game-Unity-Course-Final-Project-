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
            // Starts enemy turn
            GetComponent<TurnSequenceManager>().EnemyPlays();
        }
        else
        {
            // Evaluate if there are more enemies in game
            StartCoroutine(BlueGhostFinished(2));
        }
        // Revovering 2D lights to focus on character
        GameObject.Find("GameManager").GetComponent<TurnSequenceManager>().LightFocusCharacterNotPlaying(GameObject.Find("BlueGhost"));
    }

    IEnumerator BlueGhostFinished(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        // Displaying Enemy Data in Panel Combat
        GetComponent<TurnSequenceManager>().FinishingTurn();
    }
}
