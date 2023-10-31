using UnityEngine;

public class LaserSight : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxLaserRange = 20f; // Maximum range of the laser sight
    public Gradient laserColorGradient; // Gradient to define the laser's color
    public LayerMask ignoreLayer; // Set this in the Inspector to the layer you want to ignore (e.g., "Bullet" layer)

    void Start()
    {
        // Set up Line Renderer properties
        lineRenderer.colorGradient = laserColorGradient;
    }

    void Update()
    {
        // Get the end position of the laser sight in local space
        Vector2 endPosition = (Vector2)transform.position + Vector2.right * maxLaserRange;

        // Rotate the end position based on the gun's rotation
        endPosition = RotatePointAroundPivot(endPosition, transform.position, transform.rotation.eulerAngles.z);

        // Perform raycast, excluding collisions with the specified layer (e.g., "Bullet" layer)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (endPosition - (Vector2)transform.position).normalized, maxLaserRange, ~ignoreLayer);

        // Set the Line Renderer's start position to the gun's position
        lineRenderer.SetPosition(0, transform.position);

        // If the ray hits something, set the Line Renderer's end position to the hit point
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        // Clamp the laser's end position within the maximum range
        float distanceToTarget = Vector2.Distance(transform.position, endPosition);
        if (distanceToTarget > maxLaserRange)
        {
            endPosition = (Vector2)transform.position + (endPosition - (Vector2)transform.position).normalized * maxLaserRange;
        }

        // Set the Line Renderer's end position
        lineRenderer.SetPosition(1, endPosition);
    }

    // Rotate a point around a pivot by a specified angle in degrees
    Vector2 RotatePointAroundPivot(Vector2 point, Vector2 pivot, float angle)
    {
        angle = angle * Mathf.Deg2Rad;
        Vector2 rotatedPoint = new Vector2();
        rotatedPoint.x = Mathf.Cos(angle) * (point.x - pivot.x) - Mathf.Sin(angle) * (point.y - pivot.y) + pivot.x;
        rotatedPoint.y = Mathf.Sin(angle) * (point.x - pivot.x) + Mathf.Cos(angle) * (point.y - pivot.y) + pivot.y;
        return rotatedPoint;
    }
}
