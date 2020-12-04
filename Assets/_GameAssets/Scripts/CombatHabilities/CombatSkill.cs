using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSkill : MonoBehaviour
{
    protected int ammo; // if -1 = infinite
    protected int attackRoll;
    protected int criticalMod; 
    protected int damage; 
    protected int distance;
    protected int hitEffect; // 1 = bleeding, 2 = criticalHit, 3 = move, 4 = stun
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
