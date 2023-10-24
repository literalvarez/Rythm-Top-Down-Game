using UnityEngine;
using DG.Tweening;

public class MoveDoTween : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private Ease easeType = Ease.Linear;

    private void Start()
    {
        // Example: Move the object by 1 in X every Fixed update with DoTween
        // You can adjust the speed and ease type through the inspector.
        // The object will move continuously in the X-axis direction with the specified speed and ease.
        // You can modify the values in the inspector to achieve the desired movement behavior.

        // Call the MoveObject function in the FixedUpdate method to move the object continuously.
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        // Calculate the new position based on the speed and fixed time step.
        float newX = transform.position.x + speed * Time.fixedDeltaTime;

        // Use DoTween to smoothly move the object to the new position.
        transform.DOMoveX(newX, Time.fixedDeltaTime).SetEase(easeType);
    }
}
