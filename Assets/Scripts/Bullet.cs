using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasCollided = false;

    public float bulletSpeed = 10f;
    public bool enemyBullet;
    public float maxTravelDistance = 10f; // Set your maximum travel distance here

    public int maxBonuces = 0;
    private int currentBonuces = 0;

    private float traveledDistance = 0f;

    public AudioSource hitSFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set the initial velocity of the bullet
        rb.velocity = transform.right * bulletSpeed;
    }

    void Update()
    {
        // Update the traveled distance
        traveledDistance += bulletSpeed * Time.deltaTime;

        // Destroy the bullet if it exceeds the maximum travel distance
        if (traveledDistance >= maxTravelDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the "Boss" tag and is not an enemy bullet
        if (collision.gameObject.CompareTag("Boss") && !enemyBullet)
        {
            // Get the SpawnCopys component attached to the boss object
            SpawnCopys spawnCopys = collision.gameObject.GetComponent<SpawnCopys>();

            // Check if the SpawnCopys component is not null
            if (spawnCopys != null)
            {
                // Call the SpawnCopyAndDestroy method from the SpawnCopys component
                spawnCopys.SpawnCopyAndDestroy();
            }

            // Destroy the bullet after it collides with the boss
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy") && !enemyBullet)
        {         
                // Deal damage to the enemy
                Destroy(collision.gameObject);
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
        else if (other.CompareTag("Shield") && enemyBullet)
        {
            // Destroy the player
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall") && !enemyBullet)
        {
            hitSFX.Play();


            if (currentBonuces == maxBonuces)
            { 
                Destroy(gameObject);             
            }
            currentBonuces++;
        }
        else if (other.CompareTag("Player") && !enemyBullet)
        {

        }
        else if (other.CompareTag("Shield") && !enemyBullet)
        {
            
        }
        else if (other.CompareTag("Bullet"))
        {

        }
        else if (other.CompareTag("PlayerPower"))
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
