using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatisticsCharacter : MonoBehaviour
{
    [Header("PROFILE")]
    public string characterName;
    public string characterConcept;
    //[SerializeField]
    //public GameObject characterAvatar;

    [Header("CHARACTERISTICS")]
    public int constitution;
    public int dexterity;
    public int intelligence;
    public int power;
    public int size;
    public int strength;

    [Header("DERIVED FROM CHARACTERISTICS")]
    [Range(-6, 60)]
    public int damageBonus;
    public int dodge;
    public int hitPoints;
    public int hitPointsMax;

    [Header("SANITY")]
    public int sanity;
    public int sanityMax;

    [Header("HABILITIES")]
    public int fist;
    public int kick;
    public int medicine;
    public int throwing;
    public int shot;

    [Header("DAMAGES")]
    [Range(4, 9)]
    public int fistDamage;
    [Range(4, 10)]
    public int kickDamage;
    [Range(10, 12)]
    public int handGunDamage;
    [Range(8, 10)]
    public int hatDamage;

    [Header("HIT EFFECTS")]
    public bool bleeding = false; // causa más daño por asalto, resultado < 10% tirada
    public bool criticalHit = false; // causa máximo daño si hace crítico, resultado < 10% tirada
    public bool move = false; // mover, si el enemigo sale de la distancia de ataque, tiene que mover
    public bool stun = false;
}
