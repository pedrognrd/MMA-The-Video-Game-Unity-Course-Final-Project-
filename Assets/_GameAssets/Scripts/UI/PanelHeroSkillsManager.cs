using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHeroSkillsManager : MonoBehaviour
{
    private GameObject panelCombatSkillsInfo;

    //HUD Weapon Panel
    private Text weaponName;
    private Text weaponKind;
    private Text weaponImpact;
    private Text weaponDamage;
    private Text weaponDamageBonus;
    private Text weaponEffect;

    private void Awake()
    {
        panelCombatSkillsInfo = GameObject.Find("PanelCombatSkillsInfo");
        hideWeaponsInfo();
    }

    public void hideWeaponsInfo()
    {
        weaponName = GameObject.Find("BlueGhostWeaponName").GetComponent<Text>();
        weaponName.text = "";
        weaponKind = GameObject.Find("BlueGhostWeaponKind").GetComponent<Text>();
        weaponKind.text = "";
        weaponImpact = GameObject.Find("BlueGhostWeaponImpact").GetComponent<Text>();
        weaponImpact.text = "";
        weaponDamage = GameObject.Find("BlueGhostWeaponDamage").GetComponent<Text>();
        weaponDamage.text = "";
        weaponDamageBonus = GameObject.Find("BlueGhostWeaponDamageBonus").GetComponent<Text>();
        weaponDamageBonus.text = "";
        weaponEffect = GameObject.Find("BlueGhostWeaponEffect").GetComponent<Text>();
        weaponEffect.text = "";
    }
    public void WeaponInfo1()
    {
        weaponName = GameObject.Find("BlueGhostWeaponName").GetComponent<Text>();
        weaponName.text = "Indigo Fist";
        weaponKind = GameObject.Find("BlueGhostWeaponKind").GetComponent<Text>();
        weaponKind.text = "Kind: Melee";
        weaponImpact = GameObject.Find("BlueGhostWeaponImpact").GetComponent<Text>();
        weaponImpact.text = "Impact: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().fist.ToString();
        weaponDamage = GameObject.Find("BlueGhostWeaponDamage").GetComponent<Text>();
        weaponDamage.text = "Damage:  4-8";
        weaponDamageBonus = GameObject.Find("BlueGhostWeaponDamageBonus").GetComponent<Text>();
        weaponDamageBonus.text = "Damage Bonus: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().damageBonus.ToString();
        weaponEffect = GameObject.Find("BlueGhostWeaponEffect").GetComponent<Text>();
        weaponEffect.text = "Effect: Stun";
    }

    public void WeaponInfo2()
    {
        weaponName = GameObject.Find("BlueGhostWeaponName").GetComponent<Text>();
        weaponName.text = "Prussian Kick";
        weaponKind = GameObject.Find("BlueGhostWeaponKind").GetComponent<Text>();
        weaponKind.text = "Kind: Melee";
        weaponImpact = GameObject.Find("BlueGhostWeaponImpact").GetComponent<Text>();
        weaponImpact.text = "Impact: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().kick.ToString();
        weaponDamage = GameObject.Find("BlueGhostWeaponDamage").GetComponent<Text>();
        weaponDamage.text = "Damage:  6-12";
        weaponDamageBonus = GameObject.Find("BlueGhostWeaponDamageBonus").GetComponent<Text>();
        weaponDamageBonus.text = "Damage Bonus: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().damageBonus.ToString();
        weaponEffect = GameObject.Find("BlueGhostWeaponEffect").GetComponent<Text>();
        weaponEffect.text = "Effect: Move";
    }

    public void WeaponInfo3()
    {
        weaponName = GameObject.Find("BlueGhostWeaponName").GetComponent<Text>();
        weaponName.text = "Blue Hat";
        weaponKind = GameObject.Find("BlueGhostWeaponKind").GetComponent<Text>();
        weaponKind.text = "Kind: Range";
        weaponImpact = GameObject.Find("BlueGhostWeaponImpact").GetComponent<Text>();
        weaponImpact.text = "Impact: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().throwing.ToString();
        weaponDamage = GameObject.Find("BlueGhostWeaponDamage").GetComponent<Text>();
        weaponDamage.text = "Damage:  8-12";
        weaponDamageBonus = GameObject.Find("BlueGhostWeaponDamageBonus").GetComponent<Text>();
        weaponDamageBonus.text = "Damage Bonus: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().damageBonus.ToString();
        weaponEffect = GameObject.Find("BlueGhostWeaponEffect").GetComponent<Text>();
        weaponEffect.text = "Effect: Bleeding";
    }

    public void WeaponInfo4()
    {
        weaponName = GameObject.Find("BlueGhostWeaponName").GetComponent<Text>();
        weaponName.text = "Blue Colt";
        weaponKind = GameObject.Find("BlueGhostWeaponKind").GetComponent<Text>();
        weaponKind.text = "Kind: Range";
        weaponImpact = GameObject.Find("BlueGhostWeaponImpact").GetComponent<Text>();
        weaponImpact.text = "Impact: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().shoot.ToString();
        weaponDamage = GameObject.Find("BlueGhostWeaponDamage").GetComponent<Text>();
        weaponDamage.text = "Damage:  10-16";
        weaponDamageBonus = GameObject.Find("BlueGhostWeaponDamageBonus").GetComponent<Text>();
        weaponDamageBonus.text = "Damage Bonus: " + GameObject.Find("BlueGhost").GetComponent<StatisticsBlueGhost>().damageBonus.ToString();
        weaponEffect = GameObject.Find("BlueGhostWeaponEffect").GetComponent<Text>();
        weaponEffect.text = "Effect: Bleeding. Ammo: 8";
    }
}
