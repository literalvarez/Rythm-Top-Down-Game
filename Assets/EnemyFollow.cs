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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the enemy collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player
            Destroy(collision.gameObject);

            // Pause the game for 5 seconds
            Invoke("RestartScene", 5f);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
