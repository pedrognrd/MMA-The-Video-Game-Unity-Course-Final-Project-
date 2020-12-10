using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatisticsCharacter : MonoBehaviour
{
    [Header("PROFILE")]
    public string characterName;
    public string characterConcept;
    [SerializeField]
    public GameObject characterAvatar;

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
    public int shoot;

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

    public GameObject textEvent;
    GameObject gameManager;

    private void Update()
    {
        gameManager = GameObject.Find("GameManager");
        //Update EnemySelectedManager
        characterClicked();
    }
    public void DamageReceived(int damage)
    {
        hitPoints -= damage;
        // Instantiate flying points
        GetComponentInChildren<FlyingPointsManager>().InstantiateFlyingPoints(damage);
        // Is the enemy dead?
        if (hitPoints <= 0)
        {
            textEvent = GameObject.Find("TextEvent1");
            textEvent.GetComponent<PanelTextEventManager>().UpdateText(characterName + " is dead");
            if (gameObject.name == "BlueGhost")
            {
                Destroy(gameObject);
            }
            else 
            {
                GameObject.Find("GameManager").GetComponent<SpawendEnemiesDetector>().enemyDied = true;
                Destroy(gameObject);
            }
        }
    }

    

    public void characterClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;

            //Raycast depends on camera projection mode
            Vector2 origin = Vector2.zero;
            Vector2 dir = Vector2.zero;

            if (cam.orthographic)
            {
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                origin = ray.origin;
                dir = ray.direction;
            }

            RaycastHit2D hit = Physics2D.Raycast(origin, dir);

            //Check if we hit anything
            if (hit)
            {
                if (hit.collider.CompareTag("Enemy")) 
                {
                    string hitName = hit.collider.name;
                    GameObject controlledUnit = hit.transform.gameObject;
                    //gameManager.GetComponent<EnemySelectedManager>().EnemySelected(hitName);
                    gameManager.GetComponent<EnemySelectedManager>().EnemySelected(controlledUnit);
                }
            }
        }
    }
}

