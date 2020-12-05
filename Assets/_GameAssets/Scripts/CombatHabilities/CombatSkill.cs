using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSkill : MonoBehaviour
{
    protected int ammo; // -1 = infinite
    protected int attackRoll;
    protected int criticalMod; 
    protected int damage; // When the character increase its level, damage will be higer
    protected int damageMax;
    protected int damageMin;
    protected int distance; // When the character increase its level, distance will be higer
    protected int hitEffect; // 0 = none, 1 = bleeding, 2 = criticalHit, 3 = move, 4 = stun
    protected int impact;
    protected int kind; // 1 = melee, 2 = distance, 3 = magic
    [SerializeField]
    protected GameObject character;

    private void Awake()
    {
       
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public abstract void Attack();
}
