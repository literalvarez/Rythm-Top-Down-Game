using UnityEngine;
using DG.Tweening;

public class ShootingEnemy : MonoBehaviour
{
    public Transform firePoint; // Public reference to the fire point transform
    public GameObject bulletPrefab; // Prefab of the bullet to shoot
    private ShootingEnemyManager enemyManager; // Reference to the ShootingEnemyManager

    void Start()
    {
        enemyManager = FindObjectOfType<ShootingEnemyManager>(); // Find the ShootingEnemyManager in the scene
        if (enemyManager != null)
        {
            enemyManager.RegisterEnemy(this); // Register this shooting enemy with the manager
        }
        else
        {
            Debug.LogError("ShootingEnemyManager not found in the scene.");
        }
    }

    public void EnemyShoot()
    {
        // Instantiate a bullet at the fire point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.UnregisterEnemy(this); 
        }
    }
}
