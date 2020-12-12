using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhostTurnManager : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        print("Disabling Blue Ghost buttons panel");
        GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
    }

    public void BlueGhostAttacked()
    {
        // If Blue Ghost was the first to play, enemy can play
        if (GetComponent<TurnSequenceManager>().whoIsPlaying == "BlueGhost")
        {
            GetComponent<TurnSequenceManager>().EnemyPlays();
        }
        else
        {
            print("Evaluate if there are more enemies in game");
            //GetComponent<TurnSequenceManager>().FinishingTurn();
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
