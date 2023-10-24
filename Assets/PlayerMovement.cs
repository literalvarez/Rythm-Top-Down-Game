using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f; // Speed of the object
    private float currentSpeed; // Current speed, modified by input
    private Rigidbody2D rb; // Rigidbody component of the GameObject

    public float rotationAngle = 90f; // Rotation angle in degrees
    public float rotationDuration = 0.1f; // Duration of the rotation in seconds
    public Ease rotationEaseType = Ease.Linear; // Ease type for rotation animation

    private CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine virtual camera
    private Transform cameraTarget; // Target object for the Cinemachine camera

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;

        virtualCamera = GetComponent<CinemachineVirtualCamera>(); // Get the Cinemachine virtual camera component

        // Create an empty GameObject as the camera target
        cameraTarget = new GameObject().transform;
        cameraTarget.name = "CameraTarget";
        cameraTarget.position = transform.position;

        // Make the Cinemachine camera follow and look at the camera target
        virtualCamera.Follow = cameraTarget;
        virtualCamera.LookAt = cameraTarget;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // If D is pressed, rotate player and camera
            RotatePlayer(-rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // If A is pressed, rotate player and camera
            RotatePlayer(rotationAngle);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);
    }

    void RotatePlayer(float angle)
    {
        // Rotate the player object
        transform.DORotate(new Vector3(0, 0, transform.rotation.eulerAngles.z + angle), rotationDuration)
            .SetEase(rotationEaseType);

        // Rotate the camera target
        cameraTarget.DORotate(new Vector3(0, 0, cameraTarget.rotation.eulerAngles.z + angle), rotationDuration)
            .SetEase(rotationEaseType);
    }

    // Clean up the camera target when the script is destroyed
    void OnDestroy()
    {
        Destroy(cameraTarget.gameObject);
    }
}
