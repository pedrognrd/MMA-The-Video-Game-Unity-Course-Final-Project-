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
    private Text textDescription;
    private Text textDamageBonus;
    public Text textHitPoints;
    private Text textSanityPoints;
    private Text textMeleeStatistics;
    private Text textRangeStatistics; 
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

    private void Awake()
    {
        GameObject.Find("AvatarEnemyDefault").GetComponent<Image>().enabled = true;
        GameObject.Find("AvatarEnemyDeepOne").GetComponent<Image>().enabled = false;
        GameObject.Find("AvatarEnemyDagon").GetComponent<Image>().enabled = false;
    }

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

    public void DisplayAvatar(GameObject enemySelected)
    {
        if (enemySelected.name == "DeepOne" || enemySelected.name == "DeepOne(Clone)")
        {
            GameObject.Find("AvatarEnemyDefault").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarEnemyDeepOne").GetComponent<Image>().enabled = true;
            GameObject.Find("AvatarEnemyDagon").GetComponent<Image>().enabled = false;
        }
        if (enemySelected.name == "Dagon" || enemySelected.name == "Dagon(Clone)")
        {
            GameObject.Find("AvatarEnemyDefault").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarEnemyDeepOne").GetComponent<Image>().enabled = false;
            GameObject.Find("AvatarEnemyDagon").GetComponent<Image>().enabled = true;
        }
    }

    public void UpdateEnemyPanel(GameObject hitName)
    {
        textName = GameObject.Find("EnemyName").GetComponent<Text>();
        textName.text = hitName.GetComponent<StatisticsCharacter>().characterName;
        textConcept = GameObject.Find("EnemyConcept").GetComponent<Text>();
        textConcept.text = hitName.GetComponent<StatisticsCharacter>().characterConcept;
        textDescription = GameObject.Find("EnemyDescription").GetComponent<Text>();
        textDescription.text = hitName.GetComponent<StatisticsCharacter>().characterDescription;
        textDamageBonus = GameObject.Find("DamageBonus").GetComponent<Text>();
        textDamageBonus.text = "Damage Bonus: " + hitName.GetComponent<StatisticsCharacter>().damageBonus;
        if (hitName.name == "DeepOne" || hitName.name == "DeepOne(Clone)")
        {
            textMeleeStatistics = GameObject.Find("MeleeStatistics").GetComponent<Text>();
            textMeleeStatistics.text = hitName.GetComponent<DeepOneAttackMelee1>().impact.ToString();
            textRangeStatistics = GameObject.Find("RangeStatistics").GetComponent<Text>();
            textRangeStatistics.text = hitName.GetComponent<DeepOneWeaponRange1>().impact.ToString();
        }

        if (hitName.name == "Dagon" || hitName.name == "Dagon(Clone)") 
        {
            textMeleeStatistics = GameObject.Find("MeleeStatistics").GetComponent<Text>();
            textMeleeStatistics.text = hitName.GetComponent<DagonAttackMelee1>().impact.ToString();
            textRangeStatistics = GameObject.Find("RangeStatistics").GetComponent<Text>();
            textRangeStatistics.text = hitName.GetComponent<DagonWeaponRange1>().impact.ToString();
        }

        hitPoints = hitName.GetComponent<StatisticsCharacter>().hitPoints;
        hitPointsMax = hitName.GetComponent<StatisticsCharacter>().hitPointsMax;
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
