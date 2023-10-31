using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player; // Reference to the player's transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the tag "Player"
    }

    void Update()
    {
        if (player != null)
        {
            // Get the direction from this object to the player
            Vector2 directionToPlayer = player.position - transform.position;
            // Calculate the angle from the object to the player in radians
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            // Set the object's rotation to face the player
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
