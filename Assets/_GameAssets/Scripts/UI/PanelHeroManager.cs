using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class PanelHeroManager : MonoBehaviour
{
    // HUD Hero data
    [Header("PANEL OBJECTS")]
    private Text textName;
    private Text textConcept;
    private Text textHitPoints;
    private Text textSanityPoints;
    private int hitPoints;
    private int hitPointsMax;
    private int sanity;
    private int sanityMax;

    // HUD Hero Buttons
    [Header("PANEL BUTTONS")]
    public Button attackMelee1;
    public Button attackMelee2;
    public Button attackRange1;
    public Button attackRange2;
    public GameObject button1;
    
    private void Start()
    {
        // Capture Hero statistics
        LoadingStatistics();
        // Disable all Hero buttons
        DisableHUD();
    }

    public void EnableHUD()
    {
        attackMelee1.interactable = true;
        attackMelee2.interactable = true;
        attackRange1.interactable = true;
        attackRange2.interactable = true;
       // button1.GetComponent<Button>.setActive(false);
    }

    public void DisableHUD()
    {
        attackMelee1.interactable = false;
        attackMelee2.interactable = false;
        attackRange1.interactable = false;
        attackRange2.interactable = false;
    }

    public void UpdateEnemyPanel(GameObject hitName)
    {
        // Loading enemySelected data received into PanelEnemy
        textName = GameObject.Find("HeroName").GetComponent<Text>();
        textName.text = hitName.GetComponent<StatisticsBlueGhost>().characterName;
        textConcept = GameObject.Find("HeroConcept").GetComponent<Text>();
        textConcept.text = hitName.GetComponent<StatisticsBlueGhost>().characterConcept;

        hitPoints = hitName.GetComponent<StatisticsBlueGhost>().hitPoints;
        hitPointsMax = hitName.GetComponent<StatisticsBlueGhost>().hitPointsMax;
        textHitPoints = GameObject.Find("HeroHitPoints").GetComponent<Text>();
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
    }

    public void LoadingStatistics()
    {
        //textName = GameObject.Find("HeroName").GetComponent<Text>();
        //textName.text = GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().characterName;
        textConcept = GameObject.Find("HeroConcept").GetComponent<Text>();
        textConcept.text = GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().characterConcept;

        hitPoints = GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().hitPoints;
        hitPointsMax = GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().hitPointsMax;
        sanity = GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().sanity;
        sanityMax = GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().sanityMax;
        textHitPoints = GameObject.Find("HeroHitPoints").GetComponent<Text>();
        textSanityPoints = GameObject.Find("HeroSanityPoints").GetComponent<Text>();
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
        textSanityPoints.text = sanity + "/" + sanityMax;
    }

    public void UpdateHitPoints(int damage)
    {
        hitPoints -= damage;
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
    }
}