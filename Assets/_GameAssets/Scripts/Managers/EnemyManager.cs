using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // It controls if random attack can be the throwing attack
    public bool canThrow;
    // It controls if random attack can be the shoot/summon attack
    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
