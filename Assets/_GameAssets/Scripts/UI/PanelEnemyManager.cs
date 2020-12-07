using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEnemyManager : MonoBehaviour
{
    private Text textName;
    private Text textConcept;
    public Text textHitPoints;
    private Text textSanityPoints;
    public int hitPoints;
    private int hitPointsMax;
    private int sanity;
    private int sanityMax;

    private void Start()
    {
        // Capture Hero statistics
        LoadingStatistics();
    }

    public void UpdateEnemyPanel(GameObject hitName)
    {
        // Loading enemySelected data received into PanelEnemy
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
