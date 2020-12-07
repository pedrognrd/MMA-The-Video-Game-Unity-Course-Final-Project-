using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectedManager : MonoBehaviour
{
    GameObject panelEnemyManager;
    public void EnemySelected(string hitName) 
    {
        print("enemySelected " + hitName);
        // Show enemySelected data in PanelEnemy
        panelEnemyManager = GameObject.Find("PanelEnemyManager");
        //panelEnemyManager.GetComponent<PanelEnemyManager>().LoadingFromEnemySelectedManager(hitName);

    }
}
