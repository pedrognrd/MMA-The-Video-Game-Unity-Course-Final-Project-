using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingHat : CombatSkill
{
    protected void Awake()
    {
        ammo = -1; // if -1 = infinite
        criticalMod = -5;
        damage = 8; // a medida que blue ghost suba de nivel, hará mas daño
        distance = 10; // a medida que blue ghost suba de nivel, lo lanzará más lejos
        hitEffect = 0; // 0 = none, 1 = bleeding, 2 = criticalHit, 3 = move, 4 = stun
        impact = 60;
        kind = 2; // 1 = melee, 2 = distance, 3 = magic
    }

    // Start is called before the first frame update
    void Start()
    {
        if (impact < character.GetComponent<StatisticsCharacter>().throwing) {
            impact = character.GetComponent<StatisticsCharacter>().throwing;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        // Se hace una tirada:
        attackRoll = Random.Range(1, 100);
        print("impact " + impact);
        // Se compara con la habilidad de impactar para ver si el ataque ha tenido éxito
        if (attackRoll < impact)
        {
            // Se calcula si ha hecho un ataque crítico
            if (attackRoll < ((impact * 20) / 100) + criticalMod) {
                print("hace critico");
                // Se calcula el daño
                print("vida del profundo " + GameObject.Find("DeepOne").GetComponent<StatisticsDeepOne>().hitPoints);
                damage = Random.Range(8, 12);
                print("damage " + damage);
                GameObject.Find("DeepOne").GetComponent<StatisticsDeepOne>().hitPoints -= damage;
                print("vida del profundo tras golpe" + GameObject.Find("DeepOne").GetComponent<StatisticsDeepOne>().hitPoints);
            }
            //character.GetComponent<StatisticsCharacter>().criticalHit;
        }
        else {
            print("Ataque fallado " + attackRoll);
        }
        /*
        - Se hace una tirada usando:
            - impact o throwing (lo que sea mayor)
            - se calcula el crítico con criticalHit + criticalMod
            - el enemigo esquiva si escogió esquivar
        - Si se impacta
            - Se causa daño
                - Normal o crítico
                - Se evalua si ha muerto el enemigo
            - Se aplican efectos
            - Se resta ammo

        */

    }
}
