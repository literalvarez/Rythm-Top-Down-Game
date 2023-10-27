using UnityEngine;
using System.Collections.Generic;

public class ShootingEnemyManager : MonoBehaviour
{
    private static ShootingEnemyManager _instance;
    public static ShootingEnemyManager Instance { get { return _instance; } }

    private List<ShootingEnemy> enemyList = new List<ShootingEnemy>();

    private bool CanShootDelay = false;

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

    public void RegisterEnemy(ShootingEnemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void UnregisterEnemy(ShootingEnemy enemy)
    {
        enemyList.Remove(enemy);
    }

    // Method to make all ShootingEnemy instances shoot
    public void MakeEnemiesShoot()
    {
        if (CanShootDelay == true) 
        { 
            foreach (ShootingEnemy enemy in enemyList)
            {
                enemy.EnemyShoot();
            }
            CanShootDelay = false;
        }
        CanShootDelay = true;
}
}
