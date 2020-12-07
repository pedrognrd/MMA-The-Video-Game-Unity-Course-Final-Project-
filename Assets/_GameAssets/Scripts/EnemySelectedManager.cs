using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectedManager : MonoBehaviour
{
    GameObject panelEnemyManager;
    GameObject blueGhost;

    public void EnemySelected(GameObject enemySelected)
    {
        // Sending enemySelected data to BlueGhost
        blueGhost = GameObject.Find("BlueGhost");
        blueGhost.GetComponent<BlueGhostAttackMelee1>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostAttackMelee2>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostWeaponRange1>().UpdatingEnemySelected(enemySelected);
        blueGhost.GetComponent<BlueGhostWeaponRange2>().UpdatingEnemySelected(enemySelected);
        // Sending enemySelected data to PanelEnemy
        panelEnemyManager = GameObject.Find("PanelEnemy");
        panelEnemyManager.GetComponent<PanelEnemyManager>().UpdateEnemyPanel(enemySelected);

    }
}
