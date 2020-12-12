using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTurnManager : MonoBehaviour
{
    public bool blueGhostFinishedTurn;

    private void Awake()
    {
        blueGhostFinishedTurn = false;
    }
    // Update is called once per frame
    void Update()
    {
        // If Blue Ghost had finishid its actions
        if (blueGhostFinishedTurn) 
        {
            print("Disabling Blue Ghost buttons panel");
            GameObject.Find("PanelHero").GetComponent<PanelHeroManager>().DisableHUD();
            // If Blue Ghost was the first to play, enemy can play
            if (GetComponent<TurnSequenceManager>().whoIsFirst == "BlueGhost")
            {
                blueGhostFinishedTurn = false;
                GetComponent<TurnSequenceManager>().EnemyPlays();
            }
            else
            {
                print("final de turno");
                GetComponent<TurnSequenceManager>().turnSequenceDone = true;
            }
        }
    }
}
