using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public bool enemyBullet;
    public float maxTravelDistance = 10f; // Set your maximum travel distance here

    private float traveledDistance = 0f;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

        // Update the traveled distance
        traveledDistance += bulletSpeed * Time.deltaTime;

        // Destroy the bullet if it goes offscreen or exceeds the maximum travel distance
        if (!GetComponent<Renderer>().isVisible || traveledDistance >= maxTravelDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet hits an enemy (or any other object you want to damage)
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("RangedEnemy") && !enemyBullet)
        {
            // Deal damage to the enemy
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && enemyBullet)
        {
            // Destroy the player
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && !enemyBullet)
        {

        }
        else if (other.CompareTag("Bullet"))
        {

        }
        else if (other.CompareTag("RangedEnemy") && enemyBullet)
        {

        }
        else if (other.CompareTag("Boss") && !enemyBullet)
        {
            // Get the SpawnCopys component attached to the boss object
            SpawnCopys spawnCopys = other.GetComponent<SpawnCopys>();

            // Check if the SpawnCopys component is not null
            if (spawnCopys != null)
            {
                // Call the SpawnCopyAndDestroy method from the SpawnCopys component
                spawnCopys.SpawnCopyAndDestroy();
            }

            // Destroy the bullet after it collides with the boss
            Destroy(gameObject);
        }
        else
        {
            // Destroy the bullet if it hits something else (e.g., wall)
            Destroy(gameObject);
        }

    }
}
