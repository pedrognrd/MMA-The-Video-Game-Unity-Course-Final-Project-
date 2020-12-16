using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSkills : MonoBehaviour
{
    public CharacterSoundManager characterSM;
    protected int ammo; // -1 = infinite
    protected int ammoMax; // -1 = infinite
    protected int attackRoll;
    protected int chargers; // -1 = infinite
    protected int chargersMax; // -1 = infinite
    protected int criticalMod;
    protected int damage; // When the character increase its level, damage will be higer
    protected int damageMax;
    protected int damageMin;
    protected int distance; // When the character increase its level, distance will be higer
    protected int hitEffect; // 0 = none, 1 = bleeding, 2 = move, 3 = stun
    public int impact;
    protected int kind; // 1 = melee, 2 = range, 3 = magic
    [SerializeField]
    protected GameObject character;

    public GameObject textEvent1;
    public GameObject textEvent2;
    public GameObject enemyCharacter;
    public GameObject panelEnemy;
    public GameObject panelHero;

    // It controls if random attack can be the throwing attack
    public bool canThrow;
    // It controls if random attack can be the shoot/summon attack
    public bool canShoot;


    protected virtual void Awake()
    {
        // Capturing Interactive GameObjects
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        panelEnemy = GameObject.Find("PanelEnemy");
        panelHero = GameObject.Find("PanelHero");

        canThrow = true;
        canShoot = true;

        characterSM = GetComponent<CharacterSoundManager>();
    }
    public abstract void Attack();
}
