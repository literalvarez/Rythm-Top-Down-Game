using UnityEngine;
using System.Collections.Generic;

public class DashEnemyManager : MonoBehaviour
{
    private static DashEnemyManager _instance;
    public static DashEnemyManager Instance { get { return _instance; } }

    private List<DashEnemy> enemyList = new List<DashEnemy>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterEnemy(DashEnemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void UnregisterEnemy(DashEnemy enemy)
    {
        enemyList.Remove(enemy);
    }

    // Method to make all DashEnemy instances dash
    public void MakeEnemiesDash()
    {
        foreach (DashEnemy enemy in enemyList)
        {
            enemy.EnemyDash();
        }
    }
}
