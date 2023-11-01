using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DashEnemy : MonoBehaviour
{
    public bool DashMore = true;
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    [SerializeField] private Ease typeOfEase;
    private Transform playerTransform;
    private DashEnemyManager enemyManager;
    private bool shouldDash = true; // Variable to toggle between dashing and not dashing

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene. Make sure the player object is tagged as 'Player'.");
        }

        enemyManager = FindObjectOfType<DashEnemyManager>();
        if (enemyManager != null)
        {
            enemyManager.RegisterEnemy(this);
        }
        else
        {
            Debug.LogError("DashEnemyManager not found in the scene.");
        }
    }

    public void EnemyDash()
    {
         
        if (DashMore || shouldDash )
        {
            Vector2 dashDirection = (playerTransform.position - transform.position).normalized;
            Vector2 dashEndPos = (Vector2)transform.position + dashDirection * dashDistance;
            transform.DOMove(dashEndPos, dashDuration).SetEase(typeOfEase);
            shouldDash = false; // Toggle shouldDash to false to prevent dashing next time
        }
        else
        {
            shouldDash = true; // If shouldDash is false, allow dashing next time
        }
    }

    private void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.UnregisterEnemy(this);
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
