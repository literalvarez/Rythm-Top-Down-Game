using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DashEnemy : MonoBehaviour
{
    public float dashDistance = 5f; // Serialized field for dash distance
    public float dashDuration = 0.5f; // Serialized field for dash duration
    [SerializeField] private Ease typeOfEase;
    private Transform playerTransform; // Reference to the player's transform
    private DashEnemyManager enemyManager; // Reference to the DashEnemyManager

    void Start()
    {
        // Assuming the player is tagged as "Player". Adjust the tag accordingly.
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene. Make sure the player object is tagged as 'Player'.");
        }

        enemyManager = FindObjectOfType<DashEnemyManager>(); // Find the DashEnemyManager in the scene
        if (enemyManager != null)
        {
            enemyManager.RegisterEnemy(this); // Register this enemy with the manager
        }
        else
        {
            Debug.LogError("DashEnemyManager not found in the scene.");
        }
    }

    public void EnemyDash()
    {
        Vector2 dashDirection = (playerTransform.position - transform.position).normalized;  

        Vector2 dashEndPos = (Vector2)transform.position + dashDirection * dashDistance;
        transform.DOMove(dashEndPos, dashDuration).SetEase(typeOfEase);

    }

    private void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.UnregisterEnemy(this); // Unregister this enemy from the manager
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the enemy collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player
            Destroy(collision.gameObject);
        }
    }
}
