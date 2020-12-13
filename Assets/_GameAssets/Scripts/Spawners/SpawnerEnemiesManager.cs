using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemiesManager : MonoBehaviour
{
    // THIS CLASS CONTROLS IF HERO IS CLOSE TO SPAWNERS POINTS TO INSTANTIATE DEEPONES
    private float distanceToPlayer;
    public int spawnNumber;
    private bool spawning = true;
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("BlueGhost");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (spawning) 
        {
            if (distanceToPlayer < 18)
            {
                GetComponent<SpawnerEnemies>().SpawnEnemies(spawnNumber);
                spawning = false;
            }
        }
    }
}
