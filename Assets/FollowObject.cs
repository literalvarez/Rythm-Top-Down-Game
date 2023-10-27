using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float offsetX = 0f; // Distance in X axis from the target
    public float offsetY = 0f; // Distance in Y axis from the target

    void Update()
    {
        if (target != null)
        {
            // Get the target's position
            Vector3 targetPosition = target.position;

            // Calculate the new position with offset
            Vector3 newPosition = new Vector3(targetPosition.x + offsetX, targetPosition.y + offsetY, transform.position.z);

            // Move the object to the new position
            transform.position = newPosition;
        }
        else
        {
           // Debug.LogError("Target object is not assigned!");
        }
    }
}