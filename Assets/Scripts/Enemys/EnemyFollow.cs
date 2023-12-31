using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    public float chaseSpeed = 5f; // Speed at which the enemy chases the player
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Find the player's position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector2 targetPosition = player.transform.position;

            // Calculate the direction to the player
            Vector2 chaseDirection = (targetPosition - (Vector2)transform.position).normalized;

            // Rotate the enemy to look at the player
            float angle = Mathf.Atan2(chaseDirection.y, chaseDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // Cast a ray in the direction of movement to check for obstacles
            RaycastHit2D hit = Physics2D.Raycast(transform.position, chaseDirection, 0.5f);
            if (hit.collider != null && hit.collider.CompareTag("Wall"))
            {
                // If there's a wall in front, find a new direction to move
                Vector2 newDirection = Vector2.Reflect(chaseDirection, hit.normal).normalized;
                rb.velocity = newDirection * chaseSpeed;
            }
            else
            {
                // Move the enemy towards the player if there are no obstacles
                rb.velocity = chaseDirection * chaseSpeed;
            }
        }
        else
        {
            // Handle the case when the player is not found (optional)
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Shield"))
        {
            // Destroy the player
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
