using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

        // Destroy the bullet if it goes offscreen
        if (!GetComponent<Renderer>().isVisible)
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
        if (other.CompareTag("Player"))
        {

        }
        else
        {
            // Destroy the bullet if it hits something else (e.g., wall)
            Destroy(gameObject);
        }
    }
}