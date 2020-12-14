using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEnemyManager : MonoBehaviour
{
    // HUD Enemy data
    [Header("PANEL OBJECTS")] 
    private Text textName;
    private Text textConcept;
    public Text textHitPoints;
    private Text textSanityPoints;
    public int hitPoints;
    private int hitPointsMax;
    private int sanity;
    private int sanityMax;

    // HUD Enemy Buttons
    [Header("PANEL BUTTONS")]
    public Button attackMelee1;
    public Button attackMelee2;
    public Button attackRange1;
    public Button attackRange2;

    public void EnableHUD()
    {
        attackMelee1.interactable = true;
        attackMelee2.interactable = true;
        attackRange1.interactable = true;
        attackRange2.interactable = true;
    }

    public void DisableHUD()
    {
        // Disable enemy panel");
        attackMelee1.interactable = false;
        attackMelee2.interactable = false;
        attackRange1.interactable = false;
        attackRange2.interactable = false;
    }
    public void UpdateEnemyPanel(GameObject hitName)
    {
        textName = GameObject.Find("EnemyName").GetComponent<Text>();
        textName.text = hitName.GetComponent<StatisticsCharacter>().characterName;
        textConcept = GameObject.Find("EnemyConcept").GetComponent<Text>();
        textConcept.text = hitName.GetComponent<StatisticsCharacter>().characterConcept;

        hitPoints = hitName.GetComponent<StatisticsCharacter>().hitPoints;
        hitPointsMax = hitName.GetComponent<StatisticsCharacter>().hitPointsMax;
        textHitPoints = GameObject.Find("EnemyHitPoints").GetComponent<Text>();
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
    }

    public void LoadingStatistics()
    {
        textName = GameObject.Find("EnemyName").GetComponent<Text>();
        textName.text = GameObject.Find("Dagon").GetComponent<StatisticsCharacter>().characterName;
        textConcept = GameObject.Find("EnemyConcept").GetComponent<Text>();
        textConcept.text = GameObject.Find("Dagon").GetComponent<StatisticsCharacter>().characterConcept;

        hitPoints = GameObject.Find("Dagon").GetComponent<StatisticsCharacter>().hitPoints;
        hitPointsMax = GameObject.Find("Dagon").GetComponent<StatisticsCharacter>().hitPointsMax;
        textHitPoints = GameObject.Find("EnemyHitPoints").GetComponent<Text>();
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
    }

    // Update enemy hit points
    public void UpdateHitPoints(int damage)
    {
        hitPoints -= damage;
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
    }
}
