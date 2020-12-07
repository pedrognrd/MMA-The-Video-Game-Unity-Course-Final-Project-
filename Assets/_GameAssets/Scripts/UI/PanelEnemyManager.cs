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

    public void LoadingStatistics()
    {
        textName = GameObject.Find("EnemyName").GetComponent<Text>();
        textName.text = GameObject.Find("Dagon").GetComponent<StatisticsCharacter>().characterName;
        textConcept = GameObject.Find("EnemyConcept").GetComponent<Text>();
        textConcept.text = GameObject.Find("Dagon").GetComponent<StatisticsCharacter>().characterConcept;

        hitPoints = GameObject.Find("DeepOne").GetComponent<StatisticsCharacter>().hitPoints;
        hitPointsMax = GameObject.Find("DeepOne").GetComponent<StatisticsCharacter>().hitPointsMax;
        sanity = GameObject.Find("DeepOne").GetComponent<StatisticsCharacter>().sanity;
        sanityMax = GameObject.Find("DeepOne").GetComponent<StatisticsCharacter>().sanityMax;
        textHitPoints = GameObject.Find("EnemyHitPoints").GetComponent<Text>();
        textSanityPoints = GameObject.Find("EnemySanityPoints").GetComponent<Text>();
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
        textSanityPoints.text = sanity + "/" + sanityMax;
    }

    // Update enemy hit points
    public void UpdateHitPoints(int damage)
    {
        hitPoints -= damage;
        textHitPoints.text = hitPoints + "/" + hitPointsMax;
    }
}
