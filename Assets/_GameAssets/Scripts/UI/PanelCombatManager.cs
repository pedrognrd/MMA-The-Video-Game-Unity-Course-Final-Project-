using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCombatManager : MonoBehaviour
{
    private Text whoIsPlaying;
    private Text turnCounter;
    private Text turnNumber;
    public int turn;

    private void Awake()
    {
        CleaningCombatPanel();
    }

    public void CleaningCombatPanel() 
    {
        turn = 0;
        whoIsPlaying = GameObject.Find("WhoIsPlaying").GetComponent<Text>();
        whoIsPlaying.enabled = false;
        turnCounter = GameObject.Find("TurnCounter").GetComponent<Text>();
        turnCounter.enabled = false;
        turnNumber = GameObject.Find("TurnNumber").GetComponent<Text>();
        turnNumber.text = "";
        GameObject.Find("AvatarTurnHero").GetComponent<Image>().enabled = false;
        GameObject.Find("AvatarTurnDefault").GetComponent<Image>().enabled = true;
        GameObject.Find("AvatarTurnDeepOne").GetComponent<Image>().enabled = false;
        GameObject.Find("AvatarTurnDagon").GetComponent<Image>().enabled = false;
    }

    public void DisplayCombatPanelInfo(GameObject characterPlaying)
    {
        turnNumber.text = "" + turn.ToString();
        whoIsPlaying.enabled = true;
        turnCounter.enabled = true;
        if (characterPlaying.name == "BlueGhost" || characterPlaying.name == "BlueGhost(Clone)")
        {
            GameObject.Find("AvatarTurnHero").GetComponent<Image>().enabled = true;
            GameObject.Find("AvatarTurnDefault").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarTurnDeepOne").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarTurnDagon").GetComponent<Image>().enabled = false;
        }
        if (characterPlaying.name == "DeepOne" || characterPlaying.name == "DeepOne(Clone)")
        {
            GameObject.Find("AvatarTurnHero").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarTurnDefault").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarTurnDeepOne").GetComponent<Image>().enabled = true;
            GameObject.Find("AvatarTurnDagon").GetComponent<Image>().enabled = false;
        }
        if (characterPlaying.name == "Dagon" || characterPlaying.name == "Dagon(Clone)")
        {
            GameObject.Find("AvatarTurnHero").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarTurnDefault").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarTurnDeepOne").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarTurnDagon").GetComponent<Image>().enabled = true;
        }
    }
}
