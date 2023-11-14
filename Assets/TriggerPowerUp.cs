using UnityEngine;
using UnityEngine.Events;

public class TriggerPowerUp : MonoBehaviour
{
    // Unity Event to be invoked when the Player enters the trigger zone
    public UnityEvent onPlayerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has the tag "Player"
        if (other.CompareTag("Player") || other.CompareTag("Shield"))
        {
            // Invoke the Unity Event
            onPlayerEnter.Invoke();

            // Disable the game object
            gameObject.SetActive(false);
        }
    }
}
