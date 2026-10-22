using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // Serialized field for dash distance
    public float dashDuration = 0.5f; // Serialized field for dash duration
    private bool canDash = false; // Private variable to control dashing
    [SerializeField] private Ease typeOfEase;
    public AudioSource DashSFX;
    private Coroutine dashWindowCoroutine;

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
        // Restart the window so an older beat's timer can't close this one early
        StopDashWindow();
        dashWindowCoroutine = StartCoroutine(DisableDashingCoroutine());
    }

    private IEnumerator DisableDashingCoroutine()
    {
        yield return new WaitForSeconds(0.22f); // Wait for 0.2 seconds

        canDash = false;
        dashWindowCoroutine = null;
    }

    private void StopDashWindow()
    {
        if (dashWindowCoroutine != null)
        {
            StopCoroutine(dashWindowCoroutine);
            dashWindowCoroutine = null;
        }
    }

    private void Dash(Vector2 dashDirection)
    {
        DashSFX.Play();
        Vector2 dashEndPos = (Vector2)transform.position + dashDirection * dashDistance;
        transform.DOMove(dashEndPos, dashDuration).SetEase(typeOfEase);
        canDash = false;
        StopDashWindow();
    }

    private void OnDestroy()
    {
        // Stop the dash tween so it doesn't move a destroyed player
        transform.DOKill();
    }

    public void IncreaseDashRange()
    {
        dashDistance *= 1.2f; // Increase dash distance by 20%
    }
}
