using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSkills : MonoBehaviour
{
    public Animator animator;
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
    protected int impact;
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
    // It choose between the two options of defending an atttack
    public string[] defenseChoosing = new string[] { "Defense1", "Defense2" };
    public string defenseChosen;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        // Capturing Interactive GameObjects
        textEvent1 = GameObject.Find("TextEvent1");
        textEvent2 = GameObject.Find("TextEvent2");
        panelEnemy = GameObject.Find("PanelEnemy");
        panelHero = GameObject.Find("PanelHero");

        canThrow = true;
        canShoot = true;
    }
    public abstract void Attack();

    public void DefenseChoosing()
    {
        print("LENGTH " + defenseChoosing.Length);
        defenseChosen = defenseChoosing[Random.Range(0, 1)];
        if (defenseChosen == "Defense1")
        {
            Defense1();
        }
        else
        {
            Defense2();
        }
    }

    public void Damage()
    {
        animator.SetBool("Damage", true);
        StartCoroutine(DamageEnds(2));
    }

    IEnumerator DamageEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Damage", false);
    }

    // Enemies only have a defense animation
    public void Defense()
    {
        animator.SetBool("Defense", true);
        StartCoroutine(DefenseEnds(2));
    }

    IEnumerator DefenseEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Defense", false);
    }

    // Blue Ghost has two defense animations
    public void Defense1() {
        print("EN DEFENSE1");
        animator.SetBool("Defense1", true);
        StartCoroutine(Defense1Ends(2));
    }

    IEnumerator Defense1Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Defense1", false);
    }

    public void Defense2()
    {
        animator.SetBool("Defense2", true);
        StartCoroutine(Defense2Ends(2));
    }

    IEnumerator Defense2Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        print("Defense2Ends(float time)");
        animator.SetBool("Defense2", false);
    }

    public void Died()
    {
        animator.SetBool("Dead", true);
        StartCoroutine(DiedEnds(3));
    }

    IEnumerator DiedEnds(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Dead", false);
    }
    public void Melee1()
    {
        animator.SetBool("Fist", true);
        StartCoroutine(Melee1Ends(2));
    }

    IEnumerator Melee1Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Fist", false);
    }

    public void Melee2()
    {
        animator.SetBool("Kick", true);
        StartCoroutine(Melee2Ends(2));
    }

    IEnumerator Melee2Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Kick", false);
    }

    public void Range1()
    {
        animator.SetBool("Throw", true);
        StartCoroutine(Range1Ends(2));
    }

    IEnumerator Range1Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Throw", false);
    }

    public void Range2()
    {
        animator.SetBool("Shoot", true);
        StartCoroutine(Range2Ends(2));
    }

    IEnumerator Range2Ends(float time)
    {
        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        animator.SetBool("Shoot", false);
    }
}
