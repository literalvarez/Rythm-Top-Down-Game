using UnityEngine;
using DG.Tweening;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // Serialized field for dash distance
    public float dashDuration = 0.5f; // Serialized field for dash duration
    private bool canDash = false; // Private variable to control dashing
    [SerializeField] private Ease typeOfEase;

    void Update()
    {
        // Dash logic
        if (canDash && Input.GetMouseButtonDown(1))
        {
            Vector2 dashDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            Dash(dashDirection);
        }
    }

    public void EnableDash()
    {
        canDash = true;
        Invoke("DisableDash", 0.15f); // Turn off shooting after 100ms (0.1 seconds)
    }

    public void DisableDash()
    {
        canDash = true;
    }

    private void Dash(Vector2 dashDirection)
    {
        Vector2 dashEndPos = (Vector2)transform.position + dashDirection * dashDistance;
        transform.DOMove(dashEndPos, dashDuration).SetEase(typeOfEase).OnComplete(OnDashComplete);
    }

    private void OnDashComplete()
    {
        canDash = false;
    }
}
