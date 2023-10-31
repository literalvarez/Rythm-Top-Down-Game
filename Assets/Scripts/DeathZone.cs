using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("RangedEnemy") || other.CompareTag("Bullet") || other.CompareTag("Boss"))
        {
            Destroy(other.gameObject);
        }
    }
}
